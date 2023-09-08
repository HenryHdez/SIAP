using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaExperto.Models;

namespace SistemaExperto.Controllers
{
    public class ArchivoController : Controller
    {
        //
        // GET: /Archivo/

        public ActionResult Index()
        {
            return View();
        }

        //Guardar archivo en directorio del servidor
        //1. Cultivo
        //2. Estación
        //3. Zona
        public string GuardarArchivo(int codigo, HttpPostedFileBase imagenAdjunta, int clasificacion)
        {
            string rutaArchivo = "";

            //Registro de imagen adjunta
            if (imagenAdjunta != null && imagenAdjunta.ContentLength != 0)
            {
                //Validación de existencia de directorio del Conjunto, si no existe SistemaExperto crea
                string ubicacionDirectorio = Server.MapPath("~/Content/archivos/" + codigo);
                CrearDirectorio(ubicacionDirectorio);

                //Almacenamiento de imagen en el servidor
                string rutaImagen = Path.Combine(ubicacionDirectorio, Path.GetFileName(imagenAdjunta.FileName));
                imagenAdjunta.SaveAs(rutaImagen);

                //Modificación del valor Ruta en Conjunto
                rutaArchivo = "/Content/archivos/" + codigo + "/" + Path.GetFileName(imagenAdjunta.FileName);
            }

            return rutaArchivo;
        }

        //Creación de directorio en el servidor, en caso de que no exista
        private bool CrearDirectorio(string ruta)
        {
            bool resultado = true;
            if (!Directory.Exists(ruta))
            {
                try
                {
                    Directory.CreateDirectory(ruta);
                }
                catch (Exception)
                {
                    //Manejo de la excepción
                    resultado = false;
                }
            }
            return resultado;
        }
        //Guardar archivo en directorio del servidor

        public string GuardarArchivoExcel(HttpPostedFileBase excelAdjunto)
        {
            string rutaArchivo = "";

            //Registro de excel adjunto
            if (excelAdjunto != null && excelAdjunto.ContentLength != 0)
            {
                string ruta = null;
                ruta = "Content\\ExcelCargue";

                if (ruta != null)
                {
                    //Validación de existencia de directorio del Conjunto
                    string ubicacionDirectorio = Path.Combine(HttpRuntime.AppDomainAppPath, ruta);

                    //Almacenamiento de Archivo en el servidor
                    //string rutaImagen = Path.Combine(ubicacionDirectorio, imagenAdjunta.FileName+Path.GetExtension(imagenAdjunta.FileName));
                    string rutaArchivoServer = Path.Combine(ubicacionDirectorio, cadenaAleatoria(12)+".xlsx");
                    excelAdjunto.SaveAs(rutaArchivoServer);
                    rutaArchivo = rutaArchivoServer;
                }
            }

            return rutaArchivo;
        }

        private static Random random = new Random();
        public static string cadenaAleatoria(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
