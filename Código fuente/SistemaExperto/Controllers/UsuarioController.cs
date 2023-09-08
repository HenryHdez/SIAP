using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Helpers;
using SistemaExperto.Models;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Text;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;

namespace SistemaExperto.Controllers
{
    public class UsuarioController : Controller
    {
        //Log
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(UsuarioController));

        private SEEntities db = new SEEntities();

        //
        // GET: /Usuario/

        //public ActionResult Index()
        //{
            // var usuario = db.Usuario.Include(i => i.UsuarioId);
            //return View(db.Usuario.ToList());
        //    return View();
        //}


        // GET: /Usuario/Crear
        public ActionResult Crear()
        {
            ViewBag.ActividadId = new SelectList(db.Actividad, "ActividadId", "Nombre");
            ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre");
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre");
            return View();
        }

        // POST: /Usuario/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "UsuarioId,Nombre,Apellidos,NumeroIdentificacion,Contrasena,Contrasena,Correo,Administrador,Activo,ActividadId,Institucion,PaisId,DepartamentoId")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                string claveCifrada = Crypto.HashPassword(usuario.Contrasena);
                usuario.Contrasena = claveCifrada;
                usuario.Contrasena = claveCifrada;
                usuario.UltimoLogin = DateTime.Now;

                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActividadId = new SelectList(db.Actividad, "ActividadId", "Nombre", usuario.ActividadId);
            ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre", usuario.PaisId);
            ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", usuario.DepartamentoId);

            return View(usuario);
        }


        [HttpPost]
        //public ActionResult Registrar(string nombre, string apellido, string identificacion, string correo_registro, string clave_registro)
        public ActionResult Registrar(Usuario usuario)
        {
            TempData["MensajeRegistrar"] = "";

            //Verifica si el correo no ha sido registrado
            if (db.Usuario.Any(c => c.Correo == usuario.Correo))
            {
                TempData["MensajeRegistrar"] = "La dirección de correo ya se encuentra registrada";
            }
            else if (usuario.Correo == null)
            {
                TempData["MensajeRegistrar"] = "Digite el correo";
            }
            else
            {
                //Se limpia el modelo para el manejo de hash de clave
                ModelState.Clear();

                //Si el correo es de Corpoica, valida contra el servicio web del Directorio Activo
                //Si no lo es, registra la contraseña en BD
                string claveCifrada = "";
                if (usuario.Correo.Contains("corpoica.org.co"))
                {
                    if (AutenticarUsuarioCorpoica(usuario.Correo.Replace("@corpoica.org.co", ""), usuario.Contrasena))
                    {
                        claveCifrada = Crypto.HashPassword("123456"); //Contraseña temporal
                        usuario.Contrasena = claveCifrada;
                        usuario.Activo = true;
                        usuario.Administrador = false;
                    }
                    if (AutenticarUsuarioCorpoica(usuario.Correo.Replace("@agrosavia.co", ""), usuario.Contrasena))
                    {
                        claveCifrada = Crypto.HashPassword("123456"); //Contraseña temporal
                        usuario.Contrasena = claveCifrada;
                        usuario.Activo = true;
                        usuario.Administrador = false;
                        
                    }
                    else
                    {
                        TempData["MensajeRegistrar"] = "El correo o contraseña no coinciden con los de AGROSAVIA";
                        return RedirectToAction("Index", "Inicio");
                    }
                }
                else
                {
                    //Hash de clave y definición de usuario activo y no administrador por defecto
                    claveCifrada = Crypto.HashPassword(usuario.Contrasena);
                    usuario.Contrasena = claveCifrada;
                    usuario.Activo = true;
                    usuario.Administrador = false;
                }
                usuario.UltimoLogin = DateTime.Now;
                usuario.PerfilId = 1;
                //Luego del procedimiento se evalúa nuevamente el estado del modelo usuario
                TryValidateModel(usuario);

                //Se crea el registro en base de datos
                if (ModelState.IsValid)
                {
                    if (usuario.PaisId != 1)
                    {
                        usuario.DepartamentoId = null;
                    }
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    Session["advertenciaMostrada"] = "False";
                    FormsAuthentication.SetAuthCookie(usuario.Nombre + "|" + usuario.Administrador + "|true" + "|" + usuario.UsuarioId, false);
                    TempData["MensajeRegistrar"] = "usuario registrado";
                    return RedirectToAction("Submenu", "Inicio", new { modal = "true" });
                }
                else
                {
                    TempData["MensajeRegistrar"] = "Ocurrio un error al registrar";

                }
            }

            return RedirectToAction("Index", "Inicio");
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]

        public ActionResult CambiarClave(string correo_registro, string clave_registro, string nueva_clave_registro)
        {
            TempData["MensajeCambiarClave"] = "";

            Usuario usuario1 = ConsultarUsuario(correo_registro);
            if (usuario1 != null)
            {
                if (ValidarCredenciales(correo_registro, clave_registro))
                {
                    if (ModelState.IsValid)
                    {
                        string hash = Crypto.HashPassword(nueva_clave_registro);

                        usuario1.Contrasena = hash;
                        usuario1.Contrasena = hash;
                        db.Entry(usuario1).State = EntityState.Modified;
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                        {

                            Exception raise = dbEx;
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    string message = string.Format("{0}:{1}",
                                        validationErrors.Entry.Entity.ToString(),
                                        validationError.ErrorMessage);
                                    raise = new InvalidOperationException(message, raise);
                                }
                            }
                            throw raise;


                        }
                        TempData["MensajeCambiarClave"] = "Clave modificada con éxito";
                        return RedirectToAction("Index", "Inicio");
                    }

                    ////Registro de cookie con valores de autenticación
                    //FormsAuthentication.SetAuthCookie(usuario.Nombre + "|" + usuario.Administrador, false);
                    TempData["MensajeCambiarClave"] = "usuario modificado";
                    return RedirectToAction("Index", "Inicio");
                }
                else
                {
                    //Error al validar credenciales
                    TempData["MensajeCambiarClave"] = "Verifique correo y/o contraseña actual";
                }
            }
            else
            {
                //Consulta de correo sin resultados
                TempData["MensajeCambiarClave"] = "El correo digitado no está registrado";
            }
            return RedirectToAction("Index", "Inicio");


        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarClave(string correo_registro)
        {
            TempData["MensajeCambiarClave"] = "";
            string nueva_clave_aleatoria = "";
            Usuario usuario1 = ConsultarUsuario(correo_registro);

            if (usuario1 != null)
            {
                if (!correo_registro.ToLower().Contains("corpoica") || !correo_registro.ToLower().Contains("agrosavia"))
                {
                    if (usuario1 != null)
                    {
                        if (ModelState.IsValid)
                        {
                            nueva_clave_aleatoria = generaClaveAleatoria();
                            string hash = Crypto.HashPassword(nueva_clave_aleatoria);
                            usuario1.Contrasena = hash;
                            string respEnvio = EnviarCorreo(nueva_clave_aleatoria, correo_registro, usuario1.Nombre);
                            if (respEnvio == "Correo Enviado")
                            {
                                db.Entry(usuario1).State = EntityState.Modified;
                                try
                                {
                                    db.SaveChanges();
                                }
                                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                                {

                                    Exception raise = dbEx;
                                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                                    {
                                        foreach (var validationError in validationErrors.ValidationErrors)
                                        {
                                            string message = string.Format("{0}:{1}",
                                                validationErrors.Entry.Entity.ToString(),
                                                validationError.ErrorMessage);
                                            raise = new InvalidOperationException(message, raise);
                                        }
                                    }
                                    throw raise;
                                }
                                TempData["MensajeCambiarClave"] = "Clave enviada con éxito al correo registrado";
                                return RedirectToAction("Index", "Inicio");
                            }
                            else
                            {
                                TempData["MensajeCambiarClave"] = "Se generó un error al enviar el correo: " + respEnvio;
                                return RedirectToAction("Index", "Inicio");
                            }
                        }
                    }
                    else
                    {
                        //Consulta de correo sin resultados
                        TempData["MensajeCambiarClave"] = "El correo digitado no está registrado";
                    }
                }
                else
                {
                    TempData["MensajeCambiarClave"] = "El correo " + correo_registro + " es un correo interno. Debe solicitar el cambio de la clave por el proceso definido para usuarios de Corpoica";
                }
            }
            else
            {
                TempData["MensajeCambiarClave"] = "El correo " + correo_registro + " no existe en la base de datos del sistema. Primero debe registrarse";
            }

            return RedirectToAction("Index", "Inicio");


        }

        public string generaClaveAleatoria()
        {
            string resultado = "";
            Random r = new Random(DateTime.Now.Millisecond);
            // Le imponemos un  número de 3 cifras
            int aleatorio3 = r.Next(100, 999);

            //generando randomico de cadena
            int longitudCaracter = 4;
            StringBuilder s = new StringBuilder(longitudCaracter);
            for (int i = 1; i <= longitudCaracter; i++)
            {
                // El valor debe ser un carácter válido,
                // desde la letra a minúscula (97)
                // hasta la letra z en minúsculas (122)
                char c = (char)(r.Next(97, 123));
                // lo añadimos a la cadena
                s.Append(c);
            }
            resultado = s.ToString() + aleatorio3.ToString();
            return resultado;
        }

        public string EnviarCorreo(string clave, string correo, string nombre)
        {
            MailMessage mensaje = new MailMessage();
            SmtpClient clienteCorreo = new SmtpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            string textoCodigoDocumento = nombre;

            //lectura de parametros de la base de datos
            var parametros = db.Parametros;
            string host = parametros.Where(p => p.NombreBD == "hostCorreo").Select(p => p.Valor).FirstOrDefault();
            string puerto = parametros.Where(p => p.NombreBD == "puertocorreo").Select(p => p.Valor).FirstOrDefault();
            string cuentacorreoadmin = parametros.Where(p => p.NombreBD == "cuentacorreoadmin").Select(p => p.Valor).FirstOrDefault();
            string clavecorreoadmin = parametros.Where(p => p.NombreBD == "clavecorreoadmin").Select(p => p.Valor).FirstOrDefault();
            string cuentacorreofrom = parametros.Where(p => p.NombreBD == "cuentacorreofrom").Select(p => p.Valor).FirstOrDefault();
            string nombrecuentacorreofrom = parametros.Where(p => p.NombreBD == "nombrecuentacorreofrom").Select(p => p.Valor).FirstOrDefault();
            string asuntoolvidoclave = parametros.Where(p => p.NombreBD == "asuntoolvidoclave").Select(p => p.Valor).FirstOrDefault();
            Console.WriteLine(clave);
            if (host != null && puerto != null && cuentacorreoadmin != null && clavecorreoadmin != null && cuentacorreofrom != null && nombrecuentacorreofrom != null && asuntoolvidoclave != null)
            {
                try
                {
                    mensaje.From = new MailAddress(cuentacorreofrom, nombrecuentacorreofrom);
                    mensaje.To.Add(new MailAddress(correo, "Usuario sistema experto"));
                    mensaje.Subject = asuntoolvidoclave;
                    mensaje.IsBodyHtml = true;
                    mensaje.Body = "Notificación de cambio de clave para el usuario " + correo;

                    string textoMensaje = "<html><body><h1>Cordial saludo " + textoCodigoDocumento + "</h1><br/>" +
                        "<p>Según su solicitud se ha generado una contraseña temporal para el Sistema Experto, por favor ingrese al sistema con la siguiente contraseña:"
                        + clave + "</br><p>Es recomendable cambiar su clave una vez haya accedido.</p></body></html>";
                    AlternateView vistaAlterna = AlternateView.CreateAlternateViewFromString(textoMensaje, null, MediaTypeNames.Text.Html);
                    mensaje.AlternateViews.Add(vistaAlterna);

                    clienteCorreo.Host = host;
                    clienteCorreo.Port = Int32.Parse(puerto);
                    clienteCorreo.Credentials = new System.Net.NetworkCredential(cuentacorreoadmin, clavecorreoadmin);
                    clienteCorreo.EnableSsl = false;
                    clienteCorreo.Send(mensaje);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //Console.ReadLine();
                }
                return "Correo Enviado";
            }
            return "Parametros no configurados";
        }
        // GET: /Usuario/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: /Usuario/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Autenticar(string correo, string clave)
        {
            /*Usuario usuario = ConsultarUsuario("CORPORATIVO@CORPORATIVO.CO");
            FormsAuthentication.SetAuthCookie("a" + "|" + "b" + "|" + "c" + "|" + "d", false);
            return RedirectToAction("Submenu", "Inicio");*/

            TempData["MensajeAutenticar"] = null;
            TempData["MensajeCambiarClave"] = null;
            TempData["MensajeRegistrar"] = null;
            bool ingresoReciente = false;
            TempData["MensajeAutenticar"] = "";
            correo = "CORPORATIVO@CORPORATIVO.CO";
            clave = "12345";
            Usuario usuario = ConsultarUsuario(correo);
            //Usuario usuario = ConsultarUsuario(correo);
            //Console.WriteLine(clave);
            /*string correo2 = correo;
            string clave2 = clave;

            if ((correo2.Contains("@corpoica.org.co") || correo2.Contains("@agrosavia.co")) && ValidarCredenciales(correo, clave)){
                clave2 = "12345";
                usuario = ConsultarUsuario("CORPORATIVO@CORPORATIVO.CO");
            }*/

            if (usuario != null)
            {
                if (ValidarCredenciales(correo, clave))
                {
                    //Registro de cookie con valores de autenticación
                    Session["advertenciaMostrada"] = "False";
                    if (correo.Contains("@corpoica.org.co") || correo.Contains("@agrosavia.co"))
                    {
                        FormsAuthentication.SetAuthCookie(correo + "|" + usuario.Administrador + "|" + ingresoReciente + "|" + usuario.UsuarioId, false);
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(usuario.Nombre + "|" + usuario.Administrador + "|" + ingresoReciente + "|" + usuario.UsuarioId, false);
                    }
                    log.Info("Autenticación de usuario: " + correo);
                    TempData["MensajeAutenticar"] = "usuario autenticado";

                    db.Entry(usuario).State = EntityState.Modified;
                    usuario.UltimoLogin = DateTime.Now;
                    db.SaveChanges();

                    return RedirectToAction("Submenu", "Inicio");
                }
                else
                {
                    //Error al validar credenciales
                    TempData["MensajeAutenticar"] = "Verifique correo y/o contraseña";
                }
            }
            else
            {
                //Consulta de correo sin resultados
                TempData["MensajeAutenticar"] = "El correo digitado no está registrado";
            }
            //return RedirectToAction("Submenu", "Inicio");
            return RedirectToAction("Index", "Inicio");
        }

        //Consulta de usuario por número de identificación
        public Usuario ConsultarUsuario(string correo)
        {
            Usuario usuarioAutenticado = db.Usuario.FirstOrDefault(u => u.Correo == correo || u.LoginUsuario == correo);
            return usuarioAutenticado;
        }

        //Cerrar sesión del usuario autenticado
        public ActionResult Salir()
        {
            TempData["Salir"] = "salir";
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Inicio");
        }

        //Validación de credenciales de usuario
        private bool ValidarCredenciales(string correo, string clave)
        {
            bool validacion = false;
            using (var db = new SEEntities())
            {
                //Consultar el primer registro con el email del usuario
                var usuario = db.Usuario.FirstOrDefault(u => u.Correo == correo || u.LoginUsuario == correo);
                Console.WriteLine(usuario);
                Console.WriteLine(clave);
                Console.WriteLine(correo);
                //hoyz272
                if (usuario != null || correo.Contains("@corpoica.org.co") || correo.Contains("@agrosavia.co"))
                {
                    if (correo.Contains("@corpoica.org.co"))
                    {
                        validacion = AutenticarUsuarioCorpoica(correo.Replace("@corpoica.org.co", ""), clave);
                    }
                    else if (correo.Contains("@agrosavia.co"))
                    {
                        validacion = AutenticarUsuarioCorpoica(correo.Replace("@agrosavia.co", ""), clave);
                    }
                    else
                    {
                        var claveCifrada = usuario.Contrasena;
                        //Verificar password del usuario
                        if (Crypto.VerifyHashedPassword(claveCifrada, clave) && usuario.Activo)
                        {
                            //Si la clave es la almacenada en BD y el usuario está activo
                            validacion = true;
                        }
                        Console.WriteLine(validacion);
                    }
                }
            }
            Console.WriteLine(validacion);
            return validacion;
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Usuario> filteredCompanies = db.Usuario;

            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Usuario
                         .Where(c =>
                         c.Nombre.Contains(param.sSearch)
                          || c.Cedula.Contains(param.sSearch)
                                     //|| Convert.ToString(c.Administrador).Contains(param.sSearch)
                                     );
            }
            else
            {
                filteredCompanies = db.Usuario;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Usuario, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Nombre : sortColumnIndex == 2 ? c.Cedula : Convert.ToString(c.Administrador));

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
            // fin para orden
            var displayedCompanies = filteredCompanies
                        .Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);


            var result = displayedCompanies
                .Select(c => new { c.UsuarioId, c.Nombre, c.Cedula, c.Administrador });
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Usuario.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        // GET: /Usuario/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Nombre", usuario.TipoIdentificacionId);
            ViewBag.ActividadId = new SelectList(db.Actividad, "ActividadId", "Nombre", usuario.ActividadId);
            ViewBag.PaisId = new SelectList(db.Pais.OrderBy(p => p.Nombre), "PaisId", "Nombre", usuario.PaisId);
            ViewBag.DepartamentoId = new SelectList(db.Departamento.OrderBy(p => p.Nombre), "DepartamentoId", "Nombre", usuario.DepartamentoId);
            return View(usuario);
        }

        // POST: /Usuario/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "UsuarioId,Nombre,Apellido,Cedula,Celular,Contrasena,LoginUsuario,Correo,Direccion,Administrador,Activo,TipoUsuario, Actividad, ActividadId, Institucion, DepartamentoId,Telefono, PaisId, TipoIdentificacionId")] Usuario usuario)
        {

            if (!this.ModelState.IsValid) {
                ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Nombre", usuario.TipoIdentificacionId);
                ViewBag.ActividadId = new SelectList(db.Actividad, "ActividadId", "Nombre", usuario.ActividadId);
                ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre", usuario.PaisId);
                ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", usuario.DepartamentoId);
                return (ActionResult)this.View((object)usuario);
            }
            else{
                string hash = Crypto.HashPassword(usuario.Contrasena);
                if (usuario.PaisId != 1){usuario.DepartamentoId = null;}
                //ha@sdaasd.com
                usuario.Contrasena = hash;
                usuario.UltimoLogin = DateTime.Now;
                usuario.PerfilId = 1;
                //usuario.TipoIdentificacionId = 1;
                //Luego del procedimiento se evalúa nuevamente el estado del modelo usuario
                this.db.Entry<Usuario>(usuario).State = EntityState.Modified;
                TryValidateModel(usuario);

                try{
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx){
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
                usuario = db.Usuario.Find(usuario.UsuarioId);
                if (usuario == null){return HttpNotFound();}
                ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Nombre", usuario.TipoIdentificacionId);
                ViewBag.ActividadId = new SelectList(db.Actividad, "ActividadId", "Nombre", usuario.ActividadId);
                ViewBag.PaisId = new SelectList(db.Pais, "PaisId", "Nombre", usuario.PaisId);
                ViewBag.DepartamentoId = new SelectList(db.Departamento, "DepartamentoId", "Nombre", usuario.DepartamentoId);
                return View(usuario);
            }
        }

        private bool AutenticarUsuarioCorpoica(string usuario, string password)
        {
            bool resultado = false;

            SE.ADCorpoica.Wcf_AuthUsersSoapClient servicioAutenticacion = new SE.ADCorpoica.Wcf_AuthUsersSoapClient();
            string respuesta = servicioAutenticacion.validarUsuario(usuario, password);
            Console.Write(respuesta);
            if (respuesta.Contains("#1#1"))
            {
                log.Info("Autenticación de usuario: " + usuario);
                resultado = true;
            }

            return resultado;
        }

    }
}