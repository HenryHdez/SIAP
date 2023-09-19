using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;
using System.Net.Mail;
using Microsoft.Exchange.WebServices.Data;
using System.Data.Entity.Infrastructure;

namespace SistemaExperto.Controllers
{
    public class InicioController : Controller
    {
        private SEEntities db = new SEEntities();

        public ActionResult Index(string mensaje)
        {
            if (TempData["Salir"] != null && TempData["Salir"].Equals("salir"))
            {
                TempData["Salir"] = null;
                TempData["MensajeAutenticar"] = null;
                TempData["MensajeCambiarClave"] = null;
                TempData["MensajeRegistrar"] = null;
            }

            ViewBag.PaisId = new SelectList(db.Pais.OrderBy(p => p.Nombre), "PaisId", "Nombre");
            ViewBag.DepartamentoId = new SelectList(db.Departamento.OrderBy(p => p.Nombre), "DepartamentoId", "Nombre");
            ViewBag.ActividadId = new SelectList(db.Actividad.OrderBy(p => p.Nombre), "ActividadId", "Nombre");
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion.OrderBy(p => p.Nombre), "TipoIdentificacionId", "Nombre");
            ViewBag.MensajeRegistro = TempData["Registro"];
            ViewBag.MensajeAutenticar = mensaje;
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult Submenu()
        {
            DateTime fechaActual = DateTime.Now;
            string fechaString1 = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");

            SITB_RegIng Registro = new SITB_RegIng();
            Registro.Fecha = fechaString1;
            Registro.Ingreso_SIAP = "NO";
            Registro.Modulo_Usalo = "Submenu";
            try
            {
                db.SITB_RegIng.Add(Registro);  // Esta es la línea que faltaba
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contacto(string correoContacto, string mensajeContacto)
        {
            string resultado = "";
            //Definición de variables para envío
            MailMessage mensaje = new MailMessage();
            SmtpClient clienteCorreo = new SmtpClient();

            string cuentaCorreo = db.Parametros.Where(p => p.NombreBD == "cuentacorreoadmin").FirstOrDefault().Valor;
            string servidorCorreo = db.Parametros.Where(p => p.NombreBD == "hostcorreo").FirstOrDefault().Valor;
            string claveCorreo = db.Parametros.Where(p => p.NombreBD == "clavecorreoadmin").FirstOrDefault().Valor;
            int puertoCorreo = int.Parse(db.Parametros.Where(p => p.NombreBD == "puertocorreo").FirstOrDefault().Valor);
            string host = db.Parametros.Where(p => p.NombreBD == "hostCorreo").Select(p => p.Valor).FirstOrDefault();

            //Encabezados de correo
            mensaje.From = new MailAddress(cuentaCorreo, "Formulario de contacto");
            mensaje.To.Add(new MailAddress(cuentaCorreo));
            mensaje.Subject = "Formulario de contacto - Sistema Experto MAPA";
            mensaje.IsBodyHtml = true;

            //Creación de texto para mensaje de correo
            mensaje.Body = "<html><body>" +
                "<p>Correo:" + correoContacto + "</p>" +
                "<p>" + mensajeContacto + "</p>" +
                "</body></html>";

            //Datos de conexión y credenciales para envío de correo
            clienteCorreo.UseDefaultCredentials = false;
            clienteCorreo.Host = host;
            clienteCorreo.Port = puertoCorreo;
            clienteCorreo.EnableSsl = true;
            clienteCorreo.DeliveryMethod = SmtpDeliveryMethod.Network;
            clienteCorreo.Credentials = new System.Net.NetworkCredential(cuentaCorreo, claveCorreo);
            clienteCorreo.Timeout = 20000;
            try
            {
                //Envío de mensaje
                clienteCorreo.Send(mensaje);

                //Si no se presenta una excepción se envía un mensaje de notificación exitoso
                resultado = "Notificación enviada";
            }
            catch (SmtpException ex)
            {
                //Para una excepción se envía el mensaje del error
                resultado = ex.Message;
            }

            ViewBag.MensajeContacto = resultado;

            return RedirectToAction("Index", "Inicio");
        }

        public ActionResult Error()
        {
            return View();
        }
        public ActionResult Versionamiento()
        {
            return View();
        }

        private static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // The default for the validation callback is to reject the URL.
            bool result = false;

            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            if (redirectionUri.Scheme == "https")
            {
                result = true;
            }
            result = true;
            return result;
        }

    }
}