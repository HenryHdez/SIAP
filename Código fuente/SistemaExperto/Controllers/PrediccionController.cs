using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;

namespace SistemaExperto.Controllers
{
    public class PrediccionController : Controller
    {
        private SEEntities db = new SEEntities();

        // GET: /Prediccion/
        public ActionResult Index()
        {
            var prediccion = db.Prediccion.Include(d => d.ZonaEstacion);
            return View(prediccion.ToList());
        }

        // GET: /Prediccion/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prediccion prediccion = db.Prediccion.Find(id);
            if (prediccion == null)
            {
                return HttpNotFound();
            }
            return View(prediccion);
        }

        // GET: /Prediccion/Crear
        public ActionResult Crear()
        {
            ViewBag.ZonaEstacionId = new SelectList(db.ZonaEstacion, "ZonaEstacionId", "Zona.Nombre");
            return View();
        }

        // POST: /Prediccion/Crear
        // Cálculo de valores de predicción para la zona y le fecha seleccionadas.
        // Los registros SistemaExperto almacenan en base de datos por cada estación relacionada con la zona
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "PrediccionId,ZonaEstacionId,Fecha,R,L,S,PR,PL,ETr,RO,PRO,d,Z,X")] Prediccion prediccion)
        {
            ZonaEstacion zonaestacion = db.ZonaEstacion.Find(prediccion.ZonaEstacionId);

            ZonaMensual zonamensual = (from zm in db.ZonaMensual
                                       where zm.ZonaId == zonaestacion.ZonaId && zm.Fecha.Month == prediccion.Fecha.Month && zm.Fecha.Year == prediccion.Fecha.Year
                                       select zm).FirstOrDefault();

            if (zonamensual != null)
            {

                //validacion de si la estacion tiene Eto(requerido para la prediccion)
                EstacionMensual datosestacion = (from de in db.EstacionMensual
                                                 where de.EstacionId == zonaestacion.EstacionId && de.Fecha.Month == zonamensual.Fecha.Month && de.Fecha.Year == zonamensual.Fecha.Year
                                                 select de).FirstOrDefault();


                if (datosestacion.ETo != null)
                {

                    prediccion = CalcularPrediccion(zonaestacion, zonamensual, prediccion);
                    //sumatotal = sumatotal + (prediccion.X * item.Porcentaje) / 100;
                    if (ModelState.IsValid)
                    {
                        db.Prediccion.Add(prediccion);
                        db.SaveChanges();
                        //return RedirectToAction("/Detalles/" + prediccion.PrediccionId);
                        return RedirectToAction("/Index");
                    }
                }
                else
                {
                    ViewBag.MensajeError = "La estacion para la fecha seleccionada no tiene ETo Calculado, por tanto no puede tener predicción. Favor verifique";
                }
            }
            else
            {
                ViewBag.MensajeError = "Debe registrar primero los datos de la zona seleccionada para el mes " + prediccion.Fecha.Month;
            }

            ViewBag.ZonaEstacionId = new SelectList(db.ZonaEstacion, "ZonaEstacionId", "ZonaEstacionId", prediccion.ZonaEstacionId);
            return View(prediccion);
        }

        // GET: /Prediccion/Editar/5
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prediccion prediccion = db.Prediccion.Find(id);
            if (prediccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ZonaEstacionId = new SelectList(db.ZonaEstacion, "ZonaEstacionId", "ZonaEstacionId", prediccion.ZonaEstacionId);
            return View(prediccion);
        }

        // POST: /Prediccion/Editar/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "PrediccionId,ZonaEstacionId,Fecha,R,L,S,PR,PL,ETr,RO,PRO,d,Z,X")] Prediccion prediccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prediccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ZonaEstacionId = new SelectList(db.ZonaEstacion, "ZonaEstacionId", "ZonaEstacionId", prediccion.ZonaEstacionId);
            return View(prediccion);
        }

        // GET: /Prediccion/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prediccion prediccion = db.Prediccion.Find(id);
            if (prediccion == null)
            {
                return HttpNotFound();
            }
            return View(prediccion);
        }

        // POST: /Prediccion/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prediccion prediccion = db.Prediccion.Find(id);
            db.Prediccion.Remove(prediccion);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /*Cálculo de Prediccion hídricos*/
        public Prediccion CalcularPrediccion(ZonaEstacion zonaestacion, ZonaMensual zonamensual, Prediccion prediccion)
        {
            double ls = 0;
            double lu = 0;
            double Ss = 0;
            double Su = 0;
            double Rs = 0;
            double Ru = 0;
            double AWCs = 0;
            double AWCu = 0;

            Estacion estacion = db.Estacion.Find(zonaestacion.EstacionId);

            EstacionMensual datosestacion = (from de in db.EstacionMensual
                                             where de.EstacionId == zonaestacion.EstacionId && de.Fecha.Month == zonamensual.Fecha.Month && de.Fecha.Year == zonamensual.Fecha.Year
                                             select de).FirstOrDefault();

            //Definición de mes para obtener los diferentes valores según el mes de la predicción
            int mes = prediccion.Fecha.Month;

            //Definición de arreglos para coeficientes y K, constantes para cada mes del año
            double[] valoresET = Array.ConvertAll(zonaestacion.CadenaET.Split(';'), Double.Parse);
            double[] valoresPE = Array.ConvertAll(zonaestacion.CadenaPE.Split(';'), Double.Parse);
            double[] valoresRO = Array.ConvertAll(zonaestacion.CadenaRO.Split(';'), Double.Parse);
            double[] valoresPRO = Array.ConvertAll(zonaestacion.CadenaPRO.Split(';'), Double.Parse);
            double[] valoresR = Array.ConvertAll(zonaestacion.CadenaR.Split(';'), Double.Parse);
            double[] valoresPR = Array.ConvertAll(zonaestacion.CadenaPR.Split(';'), Double.Parse);
            double[] valoresL = Array.ConvertAll(zonaestacion.CadenaL.Split(';'), Double.Parse);
            double[] valoresPL = Array.ConvertAll(zonaestacion.CadenaPL.Split(';'), Double.Parse);
            double[] valoresK = Array.ConvertAll(zonaestacion.CadenaKs.Split(';'), Double.Parse);

            //Prediccion prediccion = new Prediccion();

            /* Cálculo de precipitación efectiva Peff
             */
            double peff = 0;
            if (datosestacion.Precipitacion < 250)
            {
                peff = datosestacion.Precipitacion * ((125 - (0.2 * datosestacion.Precipitacion)) / 125);
            }
            else
            {
                peff = 125 + (0.1 * datosestacion.Precipitacion);
            }

            /* Cálculo PSDI_Bal
             * % AWC:               Capacidad máxima de almacenamiento de agua en el suelo, (mm/m)
             * % AWCs:              Capacidad de almacenamiento de agua en el suelo en la capa superior, (mm)
             * % AWCu:              Capacidad de almacenamiento de agua en el suelo en la capa inferior, (mm)
             * % Ss0:               Condición de humedad inicial del suelo en el mes(i-1) capa superior, (mm)
             * % Su0:               Condición de humedad inicial del suelo en el mes(i-1) capa inferior, (mm)
             * % Precipitacion:     Precipitación, (mm/mes).
             * % ETo:               Evapotranspiración del cultivo de referencia, (mm/mes).
             */

            double AWC = (zonaestacion.Zona.CC - zonaestacion.Zona.PMP) * 1000;

            if (AWC <= 25)
            {
                AWCs = AWC;
            }
            else
            {
                AWCs = 25;
                AWCu = AWC - 25;
            }

            if (peff <= datosestacion.ETo)
            {
                /* Balance seco */
                if (zonamensual.Ss0 <= datosestacion.ETo - peff)
                {
                    ls = zonamensual.Ss0;
                }
                else
                {
                    ls = (double)datosestacion.ETo - peff;
                }
                Ss = zonamensual.Ss0 - ls;
                if (Ss <= 0)
                {
                    double condicion1 = ((double)datosestacion.ETo - peff - ls) * zonamensual.Su0 / AWC;
                    if (condicion1 >= zonamensual.Su0)
                    {
                        lu = zonamensual.Su0;
                    }
                    else
                    {
                        lu = condicion1;
                    }
                }
                Su = zonamensual.Su0 - lu;
            }
            else
            {
                /* Balance húmedo */
                double condicion2 = AWCs - zonamensual.Ss0;
                double condicion3 = peff - (double)datosestacion.ETo;
                if (condicion2 <= condicion3)
                {
                    Rs = condicion2;
                }
                else
                {
                    Rs = condicion3;
                }
                Ss = zonamensual.Ss0 + Rs;
                if (Ss >= AWCs)
                {
                    double condicion4 = peff - (double)datosestacion.ETo - Rs;
                    double condicion5 = AWCu - zonamensual.Su0;
                    if (condicion4 <= condicion5)
                    {
                        Ru = condicion4;
                    }
                    else
                    {
                        Ru = condicion5;
                    }
                }
                Su = zonamensual.Su0 + Ru;
            }

            /* Cálculo de prediccion
             *  S(k) = Ss(k + 1) + Su(k + 1);
             *  PR(k) = AWC - (Ss(k) + Su(k)); % Recarga potencial total
             *  PLs(k) = min(ETo(k) , Ss(k)); % Pérdida potencial capa superior
             *  PLu(k) = (ETo(k) - PLs(k)) * (Su(k) / AWC); % Pérdida potencial capa inferior
             *  PL(k) = PLs(k) + PLu(k); % Pérdida potencial total
             *  R(k) = Rs(k) + Ru(k); % Recarga total
             *  L(k) = Ls(k) + Lu(k); % Pérdida total
             *  PRO(k) = AWC - PR(k); % Escorrentía potencial total
             */

            prediccion.S = Ss + Su;
            prediccion.PR = AWC - (zonamensual.Ss0 + zonamensual.Su0);
            double PLs = Math.Min((double)datosestacion.ETo, zonamensual.Ss0);
            double PLu = ((double)datosestacion.ETo - PLs) * (zonamensual.Su0 / AWC);
            prediccion.PL = PLs + PLu;
            prediccion.R = Rs + Ru;
            prediccion.L = ls + lu;
            prediccion.PRO = AWC - prediccion.PR;

            if (peff >= datosestacion.ETo)
            {
                prediccion.ETr = (double)datosestacion.ETo;
            }
            else
            {
                prediccion.ETr = prediccion.L + peff;
            }

            if ((prediccion.S < AWC) || (prediccion.S == AWC && prediccion.L > 0))
            {
                prediccion.RO = 0;
            }
            else
            {
                prediccion.RO = peff - (double)datosestacion.ETo - prediccion.R;
            }

            int cantidadCoeficientes = zonaestacion.CantidadCadenas;

            // Cálculo de coeficiente Alfa
            valoresET[mes - 1] = agregarValorPromedio(valoresET[mes - 1], prediccion.ETr, cantidadCoeficientes);
            valoresPE[mes - 1] = agregarValorPromedio(valoresPE[mes - 1], (double)datosestacion.ETo, cantidadCoeficientes);
            double alfa = 0;
            if (valoresPE[mes - 1] != 0)
            {
                alfa = valoresET[mes - 1] / valoresPE[mes - 1];
            }
            else
            {
                if (valoresET[mes - 1] == 0) alfa = 1;
            }

            // Cálculo de coeficiente Beta
            valoresR[mes - 1] = agregarValorPromedio(valoresR[mes - 1], prediccion.R, cantidadCoeficientes);
            valoresPR[mes - 1] = agregarValorPromedio(valoresPR[mes - 1], prediccion.PR, cantidadCoeficientes);
            double beta = 0;
            if (valoresPR[mes - 1] != 0)
            {
                beta = valoresR[mes - 1] / valoresPR[mes - 1];
            }
            else
            {
                if (valoresR[mes - 1] == 0) beta = 1;
            }

            // Cálculo de coeficiente Gamma
            valoresRO[mes - 1] = agregarValorPromedio(valoresRO[mes - 1], prediccion.RO, cantidadCoeficientes);
            valoresPRO[mes - 1] = agregarValorPromedio(valoresPRO[mes - 1], prediccion.PRO, cantidadCoeficientes);
            double gamma = 0;
            if (valoresPRO[mes - 1] != 0)
            {
                gamma = valoresRO[mes - 1] / valoresPRO[mes - 1];
            }
            else
            {
                if (valoresRO[mes - 1] == 0) gamma = 1;
            }

            // Cálculo de coeficiente Delta
            valoresL[mes - 1] = agregarValorPromedio(valoresL[mes - 1], prediccion.L, cantidadCoeficientes);
            valoresPL[mes - 1] = agregarValorPromedio(valoresPL[mes - 1], prediccion.PL, cantidadCoeficientes);
            double delta = 0;
            if (valoresPL[mes - 1] != 0)
            {
                delta = valoresL[mes - 1] / valoresPL[mes - 1];
            }
            else
            {
                if (valoresL[mes - 1] == 0) delta = 1;
            }

            if ((mes - 1) == 11)
            {
                zonaestacion.CantidadCadenas = zonaestacion.CantidadCadenas++;
            }

            zonaestacion.CadenaET = nuevaCadena(valoresET);
            zonaestacion.CadenaPE = nuevaCadena(valoresPE);
            zonaestacion.CadenaRO = nuevaCadena(valoresRO);
            zonaestacion.CadenaPRO = nuevaCadena(valoresPRO);
            zonaestacion.CadenaR = nuevaCadena(valoresR);
            zonaestacion.CadenaPR = nuevaCadena(valoresPR);
            zonaestacion.CadenaL = nuevaCadena(valoresL);
            zonaestacion.CadenaPL = nuevaCadena(valoresPL);

            if (ModelState.IsValid)
            {
                db.Entry(zonaestacion).State = EntityState.Modified;
                db.SaveChanges();
            }

            double pDelta = alfa * (double)datosestacion.ETo + beta * prediccion.PR + gamma * prediccion.PRO - delta * prediccion.PL;

            prediccion.d = peff - pDelta;

            prediccion.Z = Math.Round((prediccion.d * valoresK[mes - 1]), 4);

            VariablesPDSI vpdsi = new VariablesPDSI();

            vpdsi = CalcularIndice(prediccion.Z, zonaestacion.ZonaEstacionId, mes - 1, zonamensual.Fecha.Year);

            if (vpdsi.X != null)
            {

                prediccion.X = Math.Round(vpdsi.X.Last(), 4);

                ZonaMensual nuevaZonaMensual = new ZonaMensual();
                nuevaZonaMensual.ZonaId = zonamensual.ZonaId;
                nuevaZonaMensual.Ss0 = Ss;
                nuevaZonaMensual.Su0 = Su;
                nuevaZonaMensual.Fecha = new DateTime(zonamensual.Fecha.Year, zonamensual.Fecha.Month, 15).AddMonths(1);
                db.ZonaMensual.Add(nuevaZonaMensual);
                db.SaveChanges();
            }

            return prediccion;
        }

        public class VariablesPDSI
        {
            public double[] Ud { get; set; }
            public double[] Uw { get; set; }
            public double[] Ze { get; set; }
            public double Q { get; set; }
            public double PV { get; set; }
            public double[] PX1 { get; set; }
            public double[] PX2 { get; set; }
            public double[] PX3 { get; set; }
            public double[] PPe { get; set; }
            public double[] X { get; set; }
            public double[] BT { get; set; }
        }

        public VariablesPDSI CalcularIndice(double ultimaZ, int codigoZonaEstacion, int mes, int anho)
        {
            //Buscar registro de la relación Zona - Estación correspondiente
            ZonaEstacion zonaestacion = db.ZonaEstacion.Find(codigoZonaEstacion);

            //Listar registros de Zona - Estación - Mensual para la Zona - Estación seleccionada
            IEnumerable<ZonaEstacionMensual> zonaestacionmensual = db.ZonaEstacionMensual.Where(zem => zem.ZonaEstacionId == codigoZonaEstacion);

            //Ordenar los registros por año y mes
            zonaestacionmensual = zonaestacionmensual.OrderBy(zem => zem.Anho).ThenBy(zem => zem.Mes);

            //Buscar registro de la estación correspondiente
            Estacion estacion = db.Estacion.Find(zonaestacion.EstacionId);

            int cantidadRegistros = zonaestacionmensual.Count() + 1;
            VariablesPDSI mp = new VariablesPDSI();

            if (cantidadRegistros >= 12)
            {

                double[] Z = new double[cantidadRegistros];
                double[] X1 = new double[cantidadRegistros];
                double[] X2 = new double[cantidadRegistros];
                double[] X3 = new double[cantidadRegistros];

                int contadorRegistros = 0;

                foreach (ZonaEstacionMensual zem in zonaestacionmensual)
                {
                    X1[contadorRegistros] = zem.X1;
                    X2[contadorRegistros] = zem.X2;
                    X3[contadorRegistros] = zem.X3;
                    Z[contadorRegistros] = zem.Z;
                    contadorRegistros++;
                }

                X1[contadorRegistros] = 0;
                X2[contadorRegistros] = 0;
                X3[contadorRegistros] = 0;
                Z[contadorRegistros] = ultimaZ;

                //VariablesHistoricas variablesHistoricas = db.VariablesHistoricas.Find(1);
                db.Entry(estacion).State = EntityState.Modified;
                db.SaveChanges();

                double Pe = 0;
                double V = 0;
                double nX1 = 0;
                double nX2 = 0;
                double nX3 = 0;
                double Q = 0;

                double l = Z.Length;

                //Para todo el año
                double[] BT = new double[cantidadRegistros];
                double[] X = new double[cantidadRegistros];
                double[] PPe = new double[cantidadRegistros];
                double[] Ze = new double[cantidadRegistros];
                double[] Uw = new double[cantidadRegistros];
                double[] Ud = new double[cantidadRegistros];

                mp.PX1 = new double[cantidadRegistros];
                mp.PX2 = new double[cantidadRegistros];
                mp.PX3 = new double[cantidadRegistros];


                mp.PPe = PPe;
                mp.X = X;
                mp.Uw = Uw;
                mp.Ud = Ud;
                mp.BT = BT;
                mp.Ze = Ze;

                for (int k = 0; k <= contadorRegistros; k++)
                {

                    mp.PX1[k] = 0;
                    mp.PX2[k] = 0;
                    mp.PX3[k] = 0;

                    if (Pe == 100 || Pe == 0)
                    {
                        if (Math.Abs(nX3) <= 0.5)
                        {
                            double PV = 0;
                            PPe[k] = 0;
                            mp.PV = PV;
                            mp.Q = Q;
                            mp = Main(Z, k, nX1, nX2, mp);
                        }
                        else if (nX3 > 0.5)
                        {
                            if (Z[k] >= 0.15)
                            {
                                mp = Between0s(k, Z, nX3, mp);
                            }
                            else
                            {
                                mp = Function_Ud(k, Z, V, Pe, mp, nX1, nX2, nX3);
                            }
                        }
                        else if (nX3 < -0.5)
                        {
                            if (Z[k] <= -0.15)
                            {
                                mp = Between0s(k, Z, nX3, mp);
                            }
                            else
                            {
                                mp = Function_Uw(k, Z, V, Pe, mp, nX1, nX2, nX3);
                            }
                        }
                    }
                    else
                    {
                        if (nX3 > 0)
                        {
                            mp = Function_Ud(k, Z, V, Pe, mp, nX1, nX2, nX3);
                        }
                        else
                        {
                            mp = Function_Uw(k, Z, V, Pe, mp, nX1, nX2, nX3);
                        }
                    }

                    V = mp.PV;
                    Pe = mp.PPe[k];
                    nX1 = mp.PX1[k];
                    nX2 = mp.PX2[k];
                    nX3 = mp.PX3[k];

                    if (k > 1)
                    {
                        if (mp.PX3[k] == 0 && mp.BT[k] == 0)
                        {
                            int r = 0;
                            for (int c = k; c >= 1; c--)
                            {
                                if (mp.BT[c] != 0)
                                {
                                    r = c + 1;
                                    break;
                                }
                            }


                            for (int count0 = k - 1; count0 > r; count0--)
                            {
                                mp.BT[count0] = mp.BT[count0 + 1];
                                if (mp.BT[count0] == 2)
                                {
                                    if (mp.PX2[count0] == 0)
                                    {
                                        X[count0] = mp.PX1[count0];
                                        mp.BT[count0] = 1;
                                        continue;
                                    }
                                    else
                                    {
                                        X[count0] = mp.PX2[count0];
                                        mp.BT[count0] = 2;
                                        continue;
                                    }
                                }
                                else if (mp.BT[count0] == 1)
                                {
                                    if (mp.PX1[count0] == 0)
                                    {
                                        mp.X[count0] = mp.PX2[count0];
                                        mp.BT[count0] = 2;
                                        continue;
                                    }
                                    else
                                    {
                                        mp.X[count0] = mp.PX1[count0];
                                        mp.BT[count0] = 1;
                                        continue;
                                    }
                                }
                            }
                        }
                    }

                    if (mp.PX3[k] == 0 && mp.X[k] == 0)
                    {
                        if (Math.Abs(mp.PX1[k]) > Math.Abs(mp.PX2[k]))
                        {
                            X[k] = mp.PX1[k];
                        }
                        else
                        {
                            X[k] = mp.PX2[k];
                        }
                    }

                }

                string nuevoX = "";

                for (int i = 0; i <= 11; i++)
                {
                    nuevoX = nuevoX + Math.Round(X[i], 4) + ";";
                }

                nuevoX = nuevoX.Substring(0, nuevoX.Length - 1);

                contadorRegistros = 0;
                foreach (ZonaEstacionMensual zem in zonaestacionmensual)
                {
                    if (zem.X1 != Math.Round(mp.PX1[contadorRegistros], 4))
                    {
                        zem.X1 = Math.Round(mp.PX1[contadorRegistros], 4);
                        if (ModelState.IsValid)
                        {
                            db.Entry(zem).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    if (zem.X2 != Math.Round(mp.PX2[contadorRegistros], 4))
                    {
                        zem.X2 = Math.Round(mp.PX2[contadorRegistros], 4);
                        if (ModelState.IsValid)
                        {
                            db.Entry(zem).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }

                    if (zem.X3 != Math.Round(mp.PX3[contadorRegistros], 4))
                    {
                        zem.X3 = Math.Round(mp.PX3[contadorRegistros], 4);
                        if (ModelState.IsValid)
                        {
                            db.Entry(zem).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                    contadorRegistros++;
                }

                ZonaEstacionMensual nuevoRegistro = new ZonaEstacionMensual()
                {
                    X1 = nX1,
                    X2 = nX2,
                    X3 = nX3,
                    Z = Z[contadorRegistros],
                    Anho = anho,
                    Mes = mes + 1,
                    ZonaEstacionId = zonaestacion.ZonaEstacionId
                };

                if (ModelState.IsValid)
                {
                    db.ZonaEstacionMensual.Add(nuevoRegistro);
                    db.SaveChanges();
                }

                mp.X = X;

                db.Entry(estacion).State = EntityState.Modified;
                db.SaveChanges();
            }

            return mp;
        }

        public VariablesPDSI Main(double[] Z, int k, double X1, double X2, VariablesPDSI mp)
        {
            //Definición de posibles valores para X (PX1 y PX2)
            mp.PX1[k] = Math.Max(0, 0.897 * X1 + (Z[k] / 3));
            mp.PX2[k] = Math.Min(0, 0.897 * X2 + (Z[k] / 3));

            if (mp.PX1[k] >= 1 && mp.PX3[k] == 0)
            {
                mp.X[k] = mp.PX1[k];
                mp.PX3[k] = mp.PX1[k];
                mp.PX1[k] = 0;
                mp.BT[k] = 1;
                // Llamado a la función de Backtrack para ajuste del índice
                mp = BackTrack(k, mp);
                return mp;
            }

            if (mp.PX2[k] <= -1 && mp.PX3[k] == 0)
            {
                mp.X[k] = mp.PX2[k];
                mp.PX3[k] = mp.PX2[k];
                mp.PX2[k] = 0;
                mp.BT[k] = 2;
                // Llamado a la función de Backtrack para ajuste del índice
                mp = BackTrack(k, mp);
                return mp;
            }


            if (mp.PX3[k] == 0)
            {
                if (mp.PX1[k] == 0)
                {
                    mp.X[k] = mp.PX2[k];
                    mp.BT[k] = 2;
                    mp = BackTrack(k, mp);
                    return mp;
                }
                else if (mp.PX2[k] == 0)
                {
                    mp.X[k] = mp.PX1[k];
                    mp.BT[k] = 1;
                    mp = BackTrack(k, mp);
                    return mp;
                }

            }

            mp.X[k] = mp.PX3[k];
            return mp;
        }

        public VariablesPDSI BackTrack(int k, VariablesPDSI mp)
        {
            int r = 0;
            for (int c = k; c >= 1; c--)
            {
                if (mp.PPe[c] == 0)
                {
                    r = c;
                    break;
                }
            }

            for (int count = k; count >= r + 1; count--)
            {
                if (mp.PPe[count] == 100 && Math.Abs(mp.PX3[count]) > 1)
                {
                    mp.X[count] = mp.PX3[count];
                    if (mp.PX3[count] < 0)
                    {
                        mp.BT[count - 1] = 2;
                    }
                    else
                    {
                        mp.BT[count - 1] = 1;
                    }
                    continue;
                }

                if (mp.BT[count] == 2)
                {
                    if (mp.PX2[count] == 0)
                    {
                        mp.X[count] = mp.PX1[count];
                        mp.BT[count] = 1;
                        mp.BT[count - 1] = 1;
                        continue;
                    }
                    else
                    {
                        mp.X[count] = mp.PX2[count];
                        mp.BT[count - 1] = 2;
                        continue;
                    }
                }
                else if (mp.BT[count] == 1)
                {
                    if (mp.PX1[count] == 0)
                    {
                        mp.X[count] = mp.PX2[count];
                        mp.BT[count] = 2;
                        mp.BT[count - 1] = 2;
                        continue;
                    }
                    else
                    {
                        mp.X[count] = mp.PX1[count];
                        mp.BT[count - 1] = 1;
                        continue;
                    }
                }
            }
            return mp;
        }

        public VariablesPDSI Between0s(int k, double[] Z, double X3, VariablesPDSI mp)
        {
            mp.PV = 0;
            mp.PX1[k] = 0;
            mp.PX2[k] = 0;
            mp.PPe[k] = 0;
            mp.PX3[k] = 0.897 * X3 + (Z[k] / 3);
            mp.X[k] = mp.PX3[k];
            mp.BT[k] = 3;

            int r = 0;

            for (int count1 = k; count1 >= 1; count1--)
            {
                if (mp.PPe[count1] == 0)
                {
                    r = count1;
                    break;
                }
            }

            for (int count = k; count >= r; count--)
            {
                if (mp.BT[count] == 3)
                {
                    mp.X[count] = mp.PX3[count];
                    if (count != r)
                    {
                        mp.BT[count - 1] = 3;
                    }
                }
            }

            return mp;
        }

        public VariablesPDSI Function_Uw(int k, double[] Z, double V, double Pe, VariablesPDSI mp, double X1, double X2, double X3)
        {
            mp.Uw[k] = Z[k] + 0.15;
            mp.PV = mp.Uw[k] + Math.Max(V, 0);

            if (mp.PV <= 0)
            {
                mp.Q = 0;
                mp = Between0s(k, Z, X3, mp);
            }
            else
            {
                mp.Ze[k] = -2.691 * X3 - 1.5;
                if (Pe == 100)
                {
                    mp.Q = mp.Ze[k];
                }
                else
                {
                    mp.Q = mp.Ze[k] + V;
                }

                mp.PPe[k] = (mp.PV / mp.Q) * 100;

                if (mp.PPe[k] >= 100)
                {
                    mp.PPe[k] = 100;
                    mp.PX3[k] = 0;
                }
                else
                {
                    mp.PX3[k] = 0.897 * X3 + (Z[k] / 3);
                }

                mp = Main(Z, k, X1, X2, mp);
            }
            return mp;
        }

        public VariablesPDSI Function_Ud(int k, double[] Z, double V, double Pe, VariablesPDSI mp, double X1, double X2, double X3)
        {
            mp.Ud[k] = Z[k] - 0.15;
            mp.PV = mp.Ud[k] + Math.Min(V, 0);

            if (mp.PV >= 0)
            {
                mp.Q = 0;
                mp = Between0s(k, Z, X3, mp);
            }
            else
            {
                mp.Ze[k] = -2.691 * X3 + 1.5;
                if (Pe == 100)
                {
                    mp.Q = mp.Ze[k];
                }
                else
                {
                    mp.Q = mp.Ze[k] + V;
                }
            }

            mp.PPe[k] = (mp.PV / mp.Q) * 100;

            if (mp.PPe[k] >= 100)
            {
                mp.PPe[k] = 100;
                mp.PX3[k] = 0;
            }
            else
            {
                mp.PX3[k] = 0.897 * X3 + (Z[k] / 3);
            }

            mp = Main(Z, k, X1, X2, mp);
            return mp;
        }

        //Calcula el nuevo valor del promedio, teniendo en cuenta el nuevo registro a agregar
        public double agregarValorPromedio(double valorPromedioAnterior, double nuevoValor, int cantidadPromedio)
        {
            double resultado = ((valorPromedioAnterior * cantidadPromedio) + nuevoValor) / (cantidadPromedio + 1);
            return resultado;
        }

        public ActionResult AjaxHandler(jQueryDataTableParamModel param)
        {

            IEnumerable<Prediccion> filteredCompanies = db.Prediccion;

            //if(item.X >= -0.99 && item.X <= 0.99)
            //                        {
            //                            < span > Normal </ span >
            //                        }
            //                        else if (item.X >= 1 && item.X <= 2.99)
            //{
            //                            < span > Húmeda </ span >
            //                        }
            //else if (item.X >= 3)
            //{
            //                            < span > Muy húmeda </ span >
            //                        }
            //else if (item.X >= -2.99 && item.X <= -1)
            //{
            //                            < span > Seca </ span >
            //                        }
            //else if (item.X <= -3)
            //{
            //                            < span > Muy seca </ span >
            //                        }

            //para que funcione el filtro:
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var filtro =
                filteredCompanies = db.Prediccion
                         .Where(c =>
                           c.Fecha.Year.ToString().Contains(param.sSearch) ||
                          c.Fecha.Month.ToString().Contains(param.sSearch) || c.ZonaEstacion.Zona.Cultivo.Nombre.Contains(param.sSearch) ||
                          c.ZonaEstacion.Estacion.Nombre.Contains(param.sSearch) 
                                     );

            }
            else
            {
                filteredCompanies = db.Prediccion;
            }
            //fin filtro
            // para ordenamiento
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<Prediccion, string> orderingFunction = (c => sortColumnIndex == 1 ? Convert.ToString(c.Fecha.Year) :
                                                                    sortColumnIndex == 2 ? Convert.ToString(c.Fecha.Month) :
                                                                    sortColumnIndex == 3 ? c.ZonaEstacion.Zona.Cultivo.Nombre :
                                                                c.ZonaEstacion.Estacion.Nombre);

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
                  .Select(c => new { c.PrediccionId, c.Fecha.Date.Year, c.Fecha.Date.Month,Cultivo= c.ZonaEstacion.Zona.Cultivo.Nombre, c.ZonaEstacion.Estacion.Nombre });

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = db.Prediccion.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },
                                     JsonRequestBehavior.AllowGet);
        }

        // Agrega los nuevos valores del arreglo a la cadena de 12 elementos en String para
        // almacenar en base decimal datos
        public string nuevaCadena(double[] vectorValores)
        {
            string nuevaCadena = "";
            for (int i = 0; i < 12; i++)
            {
                nuevaCadena = nuevaCadena + Math.Round(vectorValores[i], 4) + ";";
            }
            nuevaCadena = nuevaCadena.Substring(0, nuevaCadena.Length - 1);
            return nuevaCadena;
        }
    }
}
