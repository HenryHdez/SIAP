﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using SistemaExperto.Models;
using System.Web.Helpers;

namespace SistemaExperto
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AntiForgeryConfig.SuppressXFrameOptionsHeader = true;
            AreaRegistration.RegisterAllAreas();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Sin creación de BD
            Database.SetInitializer<SistemaExperto.Models.SEEntities>(null);

            //Para BD semilla
            //Database.SetInitializer<SistemaExperto.Models.SEEntities>(new CrearBD());

            //Para BD en blanco
            //Database.SetInitializer<SistemaExperto.Models.SEEntities>(new DropCreateDatabaseAlways<SistemaExperto.Models.SEEntities>());
        }

        public class CrearBD : DropCreateDatabaseAlways<SistemaExperto.Models.SEEntities>
        {
            protected override void Seed(SistemaExperto.Models.SEEntities contexto)
            {
                //Usuario
                contexto.Usuario.Add(new Usuario
                {
                    //Nombre = "Edwin Oswaldo Rojas",
                    Nombre = "Edwin",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //////ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "erojas@corpoica.org.co",
                    Activo = true,
                    Administrador = false
                });

                contexto.Usuario.Add(new Usuario
                {
                    //Nombre = "Diego Fernando Alzate",
                    Nombre = "Diego",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "dfalzate@corpoica.org.co",
                    Activo = true,
                    Administrador = false
                });

                contexto.Usuario.Add(new Usuario
                {
                    //Nombre = "Fabio Ernesto Martínez",
                    Nombre = "Fabio",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "femartinez@corpoica.org.co",
                    Activo = true,
                    Administrador = false
                });

                contexto.Usuario.Add(new Usuario
                {
                    //Nombre = "Leidy Yibeth Deantonio",
                    Nombre = "Leidy",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "ldeantonio@corpoica.org.co",
                    Activo = true,
                    Administrador = false
                });

                contexto.Usuario.Add(new Usuario
                {
                    //Nombre = "Douglas Andrés Gómez",
                    Nombre = "Douglas",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "dagomez@corpoica.org.co",
                    Activo = true,
                    Administrador = true
                });

                contexto.Usuario.Add(new Usuario
                {
                    //Nombre = "Gustavo Alfonso Araujo",
                    Nombre = "Gustavo",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "garaujo@corpoica.org.co",
                    Activo = true,
                    Administrador = false
                });

                contexto.Usuario.Add(new Usuario
                {
                    Nombre = "Eduardo",
                    Cedula = "13871422",
                    Contrasena = "AOj3OrDE98ayIrwxNUNiIZ2/DOwv8HDTlgQetx7sflhU/PC6XoC9J8nhEqPnINzOsw==",
                    //ConfirmarClave = "AOj3OrDE98ayIrwxNUNiIZ2/DOwv8HDTlgQetx7sflhU/PC6XoC9J8nhEqPnINzOsw==",
                    Correo = "eduardo.gonzalez@sistencial.com",
                    Activo = true,
                    Administrador = true
                });

                contexto.Usuario.Add(new Usuario
                {
                    Nombre = "Andrea",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "arodriguezr@corpoica.org.co",
                    Activo = true,
                    Administrador = true
                });

                contexto.Usuario.Add(new Usuario
                {
                    Nombre = "Juan Carlos",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "jcmartinezm@corpoica.org.co",
                    Activo = true,
                    Administrador = true
                });

                contexto.Usuario.Add(new Usuario
                {
                    Nombre = "Jeimy",
                    Cedula = "123456",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "jjimenezs@corpoica.org.co",
                    Activo = true,
                    Administrador = true
                });

                contexto.Usuario.Add(new Usuario
                {
                    Nombre = "Carolina",
                    Cedula = "13871422",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "dmalagon@corpoica.org.co",
                    Activo = true,
                    Administrador = true
                });

                contexto.Usuario.Add(new Usuario
                {
                    Nombre = "Yaritza",
                    Cedula = "40047926",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "yaritz@gmail.com",
                    Activo = true,
                    Administrador = true
                });

                contexto.Usuario.Add(new Usuario
                {
                    Nombre = "Mónica",
                    Cedula = "52415773",
                    Contrasena = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    //ConfirmarClave = "ALa5qJEvZx0U+19iz3O8+zyKds/Sd7lGgxMOM7Tz3CRKsCAMYoD42yBGJoBaxnhYuw==",
                    Correo = "psicopepi@yahoo.com",
                    Activo = true,
                    Administrador = false
                });

                //Departamento
                contexto.Departamento.Add(new Departamento { Nombre = "Atlántico", CodigoDane = "08" });
                contexto.Departamento.Add(new Departamento { Nombre = "Norte de Santander", CodigoDane = "54" });

                contexto.SaveChanges();

                //Municipios
                contexto.Municipio.Add(new Municipio { Nombre = "Repelón", DepartamentoId = 1, RutaImagen = "/Content/Imagenes/municipio-repelon.png", CodigoDane = "08606", Box = "-8375607.237959557,1164001.4406208904,-8351438.725088336,1187720.6227150431" });

                contexto.Municipio.Add(new Municipio { Nombre = "Suán", DepartamentoId = 1, RutaImagen = "/Content/Imagenes/municipio-repelon.png", CodigoDane = "08770", Box = "-8375607.237959557,1164001.4406208904,-8351438.725088336,1187720.6227150431" });

                contexto.Municipio.Add(new Municipio { Nombre = "Manatí", DepartamentoId = 1, RutaImagen = "/Content/Imagenes/municipio-repelon.png", CodigoDane = "08436", Box = "-8375607.237959557,1164001.4406208904,-8351438.725088336,1187720.6227150431" });

                contexto.Municipio.Add(new Municipio { Nombre = "Campo de la Cruz", DepartamentoId = 1, RutaImagen = "/Content/Imagenes/municipio-repelon.png", CodigoDane = "08137", Box = "-8375607.237959557,1164001.4406208904,-8351438.725088336,1187720.6227150431" });

                contexto.Municipio.Add(new Municipio { Nombre = "Candelaria", DepartamentoId = 1, RutaImagen = "/Content/Imagenes/municipio-repelon.png", CodigoDane = "08141", Box = "-8375607.237959557,1164001.4406208904,-8351438.725088336,1187720.6227150431" });

                contexto.Municipio.Add(new Municipio { Nombre = "Santa Lucía", DepartamentoId = 1, RutaImagen = "/Content/Imagenes/municipio-repelon.png", CodigoDane = "08675", Box = "-8375607.237959557,1164001.4406208904,-8351438.725088336,1187720.6227150431" });

                contexto.Municipio.Add(new Municipio { Nombre = "Ábrego", DepartamentoId = 2, RutaImagen = "/Content/Imagenes/municipio-repelon.png", CodigoDane = "54003", Box = "-8375607.237959557,1164001.4406208904,-8351438.725088336,1187720.6227150431" });

                contexto.EstacionTipo.Add(new EstacionTipo
                {
                    Tipo = "Montaña",
                    Radio = 4
                });

                contexto.EstacionTipo.Add(new EstacionTipo
                {
                    Tipo = "Valle",
                    Radio = 6
                });

                contexto.SaveChanges();

                //Cultivo
                contexto.Cultivo.Add(new Cultivo
                {
                    Nombre = "Tomate",
                    RutaImagen = "/Content/Imagenes/cultivo-tomate_",
                    TiempoInicial = 20,
                    TiempoDesarrollo = 30,
                    TiempoMedia = 60,
                    TiempoFinal = 20,
                    KInicial = 0.5,
                    KMedia = 0.85,
                    KFinal = 0.65,
                    ACInicial = 0.25,
                    ACMedia = 0.25,
                    ACFinal = 0.4,
                    ZrMin = 0.17,
                    ZrMax = 0.5,
                    JMin = 1,
                    JMax = 50
                });
                contexto.Cultivo.Add(new Cultivo
                {
                    Nombre = "Aji",
                    RutaImagen = "/Content/Imagenes/cultivo-tomate_",
                    TiempoInicial = 27,
                    TiempoDesarrollo = 105,
                    TiempoMedia = 126,
                    TiempoFinal = 21,
                    KInicial = 0.3,
                    KMedia = 1,
                    KFinal = 0.85,
                    ACInicial = 0.3,
                    ACMedia = 0.3,
                    ACFinal = 0.4,
                    ZrMin = 25,
                    ZrMax = 70,
                    JMin = 0,
                    JMax = 27
                });
                contexto.Cultivo.Add(new Cultivo
                {
                    Nombre = "Pasto",
                    RutaImagen = "/Content/Imagenes/cultivo-tomate_",
                    TiempoInicial = 20,
                    TiempoDesarrollo = 30,
                    TiempoMedia = 60,
                    TiempoFinal = 20,
                    KInicial = 0.5,
                    KMedia = 0.85,
                    KFinal = 0.65,
                    ACInicial = 0.25,
                    ACMedia = 0.25,
                    ACFinal = 0.4,
                    ZrMin = 0.17,
                    ZrMax = 0.5,
                    JMin = 1,
                    JMax = 50,
                });

                contexto.SaveChanges();

                //Ciclos de cultivo para tomate en Repelón
                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 1,
                    Nombre = "Ventana de análisis I",
                    CultivoId = 1,
                    MunicipioId = 1
                });

                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 2,
                    Nombre = "Ventana de análisis II",
                    CultivoId = 1,
                    MunicipioId = 1
                });

                //Ciclos de cultivo para ají en Suán
                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 3,
                    Nombre = "Ventana de análisis I",
                    CultivoId = 2,
                    MunicipioId = 2
                });

                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 4,
                    Nombre = "Ventana de análisis II",
                    CultivoId = 2,
                    MunicipioId = 2
                });

                //Ciclos de cultivo para pasto en Candelaria
                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 5,
                    Nombre = "Ventana de análisis I",
                    CultivoId = 3,
                    MunicipioId = 5
                });

                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 6,
                    Nombre = "Ventana de análisis II",
                    CultivoId = 3,
                    MunicipioId = 5
                });

                //Ciclos de cultivo para tomate en Campo de la Cruz
                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 7,
                    Nombre = "Ventana de análisis I",
                    CultivoId = 1,
                    MunicipioId = 4
                });

                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 8,
                    Nombre = "Ventana de análisis II",
                    CultivoId = 1,
                    MunicipioId = 4
                });

                //Ciclos de cultivo para ají en Santa Lucía
                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 9,
                    Nombre = "Ventana de análisis I",
                    CultivoId = 2,
                    MunicipioId = 6
                });

                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 10,
                    Nombre = "Ventana de análisis II",
                    CultivoId = 2,
                    MunicipioId = 6
                });

                //Ciclos de cultivo para pasto en Manatí
                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 11,
                    Nombre = "Ventana de análisis I",
                    CultivoId = 3,
                    MunicipioId = 3
                });

                contexto.CultivoCiclo.Add(new CultivoCiclo
                {
                    CultivoCicloId = 12,
                    Nombre = "Ventana de análisis II",
                    CultivoId = 3,
                    MunicipioId = 3
                });

                contexto.SaveChanges();

                //Etapas del cultivo
                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 1,
                    Nombre = "Transplante",
                    Clase = "escenario-azul",
                    Orden = 1,
                    RutaIcono = "/Content/imagenes/Etapas/EtapaCiclo1.png"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 2,
                    Nombre = "Floración",
                    Clase = "escenario-verde",
                    Orden = 2,
                    RutaIcono = "/Content/imagenes/Etapas/EtapaCiclo2.png"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 3,
                    Nombre = "Fructificación",
                    Clase = "escenario-naranja",
                    Orden = 3,
                    RutaIcono = "/Content/imagenes/Etapas/EtapaCiclo3.png"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 4,
                    Nombre = "Recolección",
                    Clase = "escenario-cafe",
                    Orden = 4,
                    RutaIcono = "/Content/imagenes/Etapas/EtapaCiclo4.png"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 5,
                    Nombre = "Pastoreo",
                    Clase = "escenario-verde",
                    Orden = 5,
                    RutaIcono = "/Content/imagenes/Etapas/EtapaCiclo5.png"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 6,
                    Nombre = "Período de descanso",
                    Clase = "escenario-cafe",
                    Orden = 6,
                    RutaIcono = "/Content/imagenes/Etapas/EtapaCiclo6.png"
                });

                contexto.SaveChanges();

                //Etapas en cada ciclo de cultivo para tomate en Repelón
                //Ciclo 1
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 1,
                    CultivoCicloId = 1,
                    CultivoEtapaId = 1,
                    MesInicio = 10,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 2,
                    CultivoCicloId = 1,
                    CultivoEtapaId = 2,
                    MesInicio = 11,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 3,
                    CultivoCicloId = 1,
                    CultivoEtapaId = 3,
                    MesInicio = 12,
                    Duracion = 2
                });

                //Ciclo 2
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 4,
                    CultivoCicloId = 2,
                    CultivoEtapaId = 1,
                    MesInicio = 11,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 5,
                    CultivoCicloId = 2,
                    CultivoEtapaId = 2,
                    MesInicio = 12,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 6,
                    CultivoCicloId = 2,
                    CultivoEtapaId = 3,
                    MesInicio = 1,
                    Duracion = 2
                });

                //Etapas en cada ciclo de cultivo para ají en Suán
                //Ciclo I
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 7,
                    CultivoCicloId = 3,
                    CultivoEtapaId = 2,
                    MesInicio = 10,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 8,
                    CultivoCicloId = 3,
                    CultivoEtapaId = 3,
                    MesInicio = 11,
                    Duracion = 3
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 9,
                    CultivoCicloId = 3,
                    CultivoEtapaId = 4,
                    MesInicio = 11,
                    Duracion = 3
                });

                //Ciclo II
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 10,
                    CultivoCicloId = 4,
                    CultivoEtapaId = 2,
                    MesInicio = 11,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 11,
                    CultivoCicloId = 4,
                    CultivoEtapaId = 3,
                    MesInicio = 12,
                    Duracion = 3
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 12,
                    CultivoCicloId = 4,
                    CultivoEtapaId = 4,
                    MesInicio = 12,
                    Duracion = 3
                });

                //Etapas en cada ciclo de cultivo para pasto en Candelaria
                //Ciclo I
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 13,
                    CultivoCicloId = 5,
                    CultivoEtapaId = 5,
                    MesInicio = 5,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 14,
                    CultivoCicloId = 5,
                    CultivoEtapaId = 6,
                    MesInicio = 6,
                    Duracion = 2
                });


                //Ciclo II
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 15,
                    CultivoCicloId = 6,
                    CultivoEtapaId = 5,
                    MesInicio = 7,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 16,
                    CultivoCicloId = 6,
                    CultivoEtapaId = 6,
                    MesInicio = 9,
                    Duracion = 1
                });

                //Etapas en cada ciclo de cultivo para tomate en Campo de la Cruz
                //Ciclo 1
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 17,
                    CultivoCicloId = 7,
                    CultivoEtapaId = 1,
                    MesInicio = 10,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 18,
                    CultivoCicloId = 7,
                    CultivoEtapaId = 2,
                    MesInicio = 11,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 19,
                    CultivoCicloId = 7,
                    CultivoEtapaId = 3,
                    MesInicio = 12,
                    Duracion = 2
                });

                //Ciclo 2
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 20,
                    CultivoCicloId = 8,
                    CultivoEtapaId = 1,
                    MesInicio = 11,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 21,
                    CultivoCicloId = 8,
                    CultivoEtapaId = 2,
                    MesInicio = 12,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 22,
                    CultivoCicloId = 8,
                    CultivoEtapaId = 3,
                    MesInicio = 1,
                    Duracion = 2
                });

                //Etapas en cada ciclo de cultivo para ají en Santa Lucía
                //Ciclo I
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 23,
                    CultivoCicloId = 9,
                    CultivoEtapaId = 2,
                    MesInicio = 10,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 24,
                    CultivoCicloId = 9,
                    CultivoEtapaId = 3,
                    MesInicio = 11,
                    Duracion = 3
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 25,
                    CultivoCicloId = 9,
                    CultivoEtapaId = 4,
                    MesInicio = 11,
                    Duracion = 3
                });

                //Ciclo II
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 26,
                    CultivoCicloId = 10,
                    CultivoEtapaId = 2,
                    MesInicio = 11,
                    Duracion = 1
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 27,
                    CultivoCicloId = 10,
                    CultivoEtapaId = 3,
                    MesInicio = 12,
                    Duracion = 3
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 28,
                    CultivoCicloId = 10,
                    CultivoEtapaId = 4,
                    MesInicio = 12,
                    Duracion = 3
                });

                //Etapas en cada ciclo de cultivo para pasto en Manatí
                //Ciclo I
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 29,
                    CultivoCicloId = 11,
                    CultivoEtapaId = 5,
                    MesInicio = 5,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 30,
                    CultivoCicloId = 11,
                    CultivoEtapaId = 6,
                    MesInicio = 6,
                    Duracion = 2
                });


                //Ciclo II
                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 31,
                    CultivoCicloId = 12,
                    CultivoEtapaId = 5,
                    MesInicio = 7,
                    Duracion = 2
                });

                contexto.CultivoTipoEtapa.Add(new CultivoTipoEtapa
                {
                    CultivoTipoEtapaId = 32,
                    CultivoCicloId = 12,
                    CultivoEtapaId = 6,
                    MesInicio = 9,
                    Duracion = 1
                });


                //Estacion Repelón
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Campo de la Cruz",
                    CodigoIdeam = "2904025",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 4,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Rabon El Hda",
                    CodigoIdeam = "2904027",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 4,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "San Pedrito Alerta",
                    CodigoIdeam = "2904031",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 8,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Tiogollo",
                    CodigoIdeam = "2905001",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 41,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Normal Manatí",
                    CodigoIdeam = "2903508",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 10,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Limón El",
                    CodigoIdeam = "2903512",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 7,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Candelaria",
                    CodigoIdeam = "2904026",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 4,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Pto. Giraldo",
                    CodigoIdeam = "2904030",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 5,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Salamina",
                    CodigoIdeam = "2905002",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 15,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Campanos Los",
                    CodigoIdeam = "2904029  ",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 100,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "San Estanislao",
                    CodigoIdeam = "2903005",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 20,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "San José",
                    CodigoIdeam = "2903014",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 20,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Loma Grande",
                    CodigoIdeam = "2903027",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 15,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Cabecera Bartolo",
                    CodigoIdeam = "2903039",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 10,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Casa de Bombas",
                    CodigoIdeam = "2903041",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 10,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Cabecera Henequen",
                    CodigoIdeam = "2903064",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 9,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Repelón",
                    CodigoIdeam = "2903507",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 10,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });
                contexto.Estacion.Add(new Estacion
                {
                    Nombre = "Lena",
                    CodigoIdeam = "2904029",
                    Longitud = -75.119167,
                    Latitud = 10.500276,
                    Altitud = 45,
                    RutaImagen = "/Content/archivos/1/estacionIATLNTIC3.png",
                    EstacionTipoId = 2
                });

                //Estacion Manatí

                contexto.SaveChanges();
                //****
                contexto.EstacionTipoConstante.Add(new EstacionTipoConstante
                {
                    EstacionTipoConstanteId = 1,
                    Etiqueta = "A",
                    Nombre = "A"
                });
                contexto.EstacionTipoConstante.Add(new EstacionTipoConstante
                {
                    EstacionTipoConstanteId = 2,
                    Etiqueta = "α",
                    Nombre = "Alfa"
                });
                contexto.EstacionTipoConstante.Add(new EstacionTipoConstante
                {
                    EstacionTipoConstanteId = 3,
                    Etiqueta = "β",
                    Nombre = "Beta"
                });
                contexto.EstacionTipoConstante.Add(new EstacionTipoConstante
                {
                    EstacionTipoConstanteId = 4,
                    Etiqueta = "n",
                    Nombre = "n"
                });
                contexto.EstacionTipoConstante.Add(new EstacionTipoConstante
                {
                    EstacionTipoConstanteId = 5,
                    Etiqueta = "m",
                    Nombre = "m"
                });
                contexto.EstacionTipoConstante.Add(new EstacionTipoConstante
                {
                    EstacionTipoConstanteId = 6,
                    Etiqueta = "q",
                    Nombre = "q"
                });
                contexto.EstacionTipoConstante.Add(new EstacionTipoConstante
                {
                    EstacionTipoConstanteId = 7,
                    Etiqueta = "p",
                    Nombre = "p"
                });
                contexto.SaveChanges();

                contexto.EstacionValores.Add(new EstacionValores
                {
                    EstacionValoresId = 1,
                    Enero = 1.18415598502391f,
                    Febrero = 0.64483593498179f,
                    Marzo = 0.679088851029681f,
                    Abril = 0.306585840507165f,
                    Mayo = 0.122393278570947f,
                    Junio = 0.165677556346858f,
                    Julio = 0.341281682493418f,
                    Agosto = 0.105311470178347f,
                    Septiembre = 0.0666264039489182f,
                    Octubre = 0.138544391753503f,
                    Noviembre = 0.275084930611689f,
                    Diciembre = 0.647436681454873f

                });
                contexto.EstacionValores.Add(new EstacionValores
                {
                    EstacionValoresId = 2,
                    Enero = 0.550157143144212f,
                    Febrero = 0.916410609364992f,
                    Marzo = 0.876314281717506f,
                    Abril = 1.78328592518976f,
                    Mayo = 4.24556268641573f,
                    Junio = 3.17626754378865f,
                    Julio = 1.61615128473701f,
                    Agosto = 4.90901485618252f,
                    Septiembre = 7.66765330694851f,
                    Octubre = 3.7685594856586f,
                    Noviembre = 1.97129448499717f,
                    Diciembre = 0.913220097596551f
                });
                contexto.EstacionValores.Add(new EstacionValores
                {
                    EstacionValoresId = 3,
                    Enero = 21.0719015236313f,
                    Febrero = 18.7532904028935f,
                    Marzo = 24.7408603090168f,
                    Abril = 28.7863960988407f,
                    Mayo = 29.3541773387907f,
                    Junio = 33.1137486216113f,
                    Julio = 50.5309284911958f,
                    Agosto = 22.1212917828583f,
                    Septiembre = 13.6718818396498f,
                    Octubre = 42.137287630541f,
                    Noviembre = 54.6563442550059f,
                    Diciembre = 32.1484609974336f
                });
                contexto.EstacionValores.Add(new EstacionValores
                {
                    EstacionValoresId = 4,
                    Enero = 14f,
                    Febrero = 14f,
                    Marzo = 26f,
                    Abril = 32f,
                    Mayo = 32f,
                    Junio = 32f,
                    Julio = 32f,
                    Agosto = 32f,
                    Septiembre = 32f,
                    Octubre = 32f,
                    Noviembre = 32f,
                    Diciembre = 29f
                });
                contexto.EstacionValores.Add(new EstacionValores
                {
                    EstacionValoresId = 5,
                    Enero = 18f,
                    Febrero = 18f,
                    Marzo = 6f,
                    Abril = 0f,
                    Mayo = 0f,
                    Junio = 0f,
                    Julio = 0f,
                    Agosto = 0f,
                    Septiembre = 0f,
                    Octubre = 0f,
                    Noviembre = 0f,
                    Diciembre = 3f
                });
                contexto.EstacionValores.Add(new EstacionValores
                {
                    EstacionValoresId = 6,
                    Enero = 0.5625f,
                    Febrero = 0.5625f,
                    Marzo = 0.1875f,
                    Abril = 0f,
                    Mayo = 0f,
                    Junio = 0f,
                    Julio = 0f,
                    Agosto = 0f,
                    Septiembre = 0f,
                    Octubre = 0f,
                    Noviembre = 0f,
                    Diciembre = 0.09375f
                });
                contexto.EstacionValores.Add(new EstacionValores
                {
                    EstacionValoresId = 7,
                    Enero = 0.4375f,
                    Febrero = 0.4375f,
                    Marzo = 0.8125f,
                    Abril = 1f,
                    Mayo = 1f,
                    Junio = 1f,
                    Julio = 1f,
                    Agosto = 1f,
                    Septiembre = 1f,
                    Octubre = 1f,
                    Noviembre = 1f,
                    Diciembre = 0.90625f
                });


                contexto.SaveChanges();

                contexto.EstacionConstantes.Add(new EstacionConstantes
                {
                    EstacionConstantesId = 1,
                    EstacionId = 17,
                    //EstacionTipoConstanteId = 1,
                    EstacionValoresId = 1

                });
                contexto.EstacionConstantes.Add(new EstacionConstantes
                {
                    EstacionConstantesId = 2,
                    EstacionId = 17,
                    //EstacionTipoConstanteId = 2,
                    EstacionValoresId = 2

                });
                contexto.EstacionConstantes.Add(new EstacionConstantes
                {
                    EstacionConstantesId = 3,
                    EstacionId = 17,
                   // EstacionTipoConstanteId = 3,
                    EstacionValoresId = 3

                });
                contexto.EstacionConstantes.Add(new EstacionConstantes
                {
                    EstacionConstantesId = 4,
                    EstacionId = 17,
                    //EstacionTipoConstanteId = 4,
                    EstacionValoresId = 4

                });
                contexto.EstacionConstantes.Add(new EstacionConstantes
                {
                    EstacionConstantesId = 5,
                    EstacionId = 17,
                   // EstacionTipoConstanteId = 5,
                    EstacionValoresId = 5

                });
                contexto.EstacionConstantes.Add(new EstacionConstantes
                {
                    EstacionConstantesId = 6,
                    EstacionId = 17,
                    //EstacionTipoConstanteId = 6,
                    EstacionValoresId = 6

                });
                contexto.EstacionConstantes.Add(new EstacionConstantes
                {
                    EstacionConstantesId = 7,
                    EstacionId = 17,
                   // EstacionTipoConstanteId = 7,
                    EstacionValoresId = 7

                });

                contexto.SaveChanges();

                //****

                //VariablesHistoricas
                contexto.VariablesHistoricas.Add(new VariablesHistoricas
                {
                    PX1 = "0;0;0;0;0;0;0;0;0;0",
                    PX2 = "0;0;0;0;0;0;0;0;0;0",
                    PX3 = "0;0;0;0;0;0;0;0;0;0",
                    Ze = "0;0;0;0;0;0;0;0;0;0",
                    X = "0;0;0;0;0;0;0;0;0;0",
                    Uw = "0;0;0;0;0;0;0;0;0;0",
                    Ud = "0;0;0;0;0;0;0;0;0;0"
                });

                contexto.SaveChanges();

                //Zona

                //Tomate
                contexto.Zona.Add(new Zona
                {
                    Nombre = "Tomate",
                    MunicipioId = 1,
                    CultivoId = 1,
                    CC = 0.4,
                    PMP = 0.12,
                    Latitud = 10.461917,
                    Longitud = -75.151528,
                    TasaMax = 40
                });

                //Ají
                contexto.Zona.Add(new Zona
                {
                    Nombre = "Ají",
                    MunicipioId = 2,
                    CultivoId = 2,
                    CC = 0.53,
                    PMP = 0.35,
                    Latitud = 10.32755,
                    Longitud = -74.88938,
                    TasaMax = 40
                });

                //Pastos
                contexto.Zona.Add(new Zona
                {
                    Nombre = "Pastos 1",
                    MunicipioId = 5,
                    CultivoId = 3,
                    CC = 0.53,
                    PMP = 0.35,
                    Latitud = 10.491500,
                    Longitud = -74.874167,
                    TasaMax = 40
                });
                contexto.Zona.Add(new Zona
                {
                    Nombre = "Pastos 2",
                    MunicipioId = 5,
                    CultivoId = 3,
                    CC = 0.53,
                    PMP = 0.35,
                    Latitud = 10.560467,
                    Longitud = -74.864183,
                    TasaMax = 40
                });

                contexto.SaveChanges();

                //Datos iniciales de ZonaMensual

                //Repelón - Tomate
                contexto.ZonaMensual.Add(new ZonaMensual
                {
                    Fecha = new DateTime(2012, 01, 15),
                    Ss0 = 0,
                    Su0 = 0,
                    ZonaId = 1
                });

                contexto.ZonaMensual.Add(new ZonaMensual
                {
                    Fecha = new DateTime(2015, 04, 15),
                    Ss0 = 0,
                    Su0 = 0,
                    ZonaId = 1
                });
                //
                contexto.CategoriaProbabilidad.Add(new CategoriaProbabilidad
                {
                    CategoriaProbabilidadId = 1,
                    Descripcion = "Debajo de lo Normal"
                });
                contexto.CategoriaProbabilidad.Add(new CategoriaProbabilidad
                {
                    CategoriaProbabilidadId = 2,
                    Descripcion = "Sobre lo Normal"
                });
                contexto.CategoriaProbabilidad.Add(new CategoriaProbabilidad
                {
                    CategoriaProbabilidadId = 3,
                    Descripcion = "Dentro de lo Normal"
                });
                contexto.SaveChanges();
                contexto.CategoriaProbabilidad.Add(new CategoriaProbabilidad
                {
                    CategoriaProbabilidadId = 4,
                    Descripcion = "Dato no calculado"
                });
                contexto.SaveChanges();

                //Datos iniciales de estación Repelón 12/2011
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 17,
                    Fecha = new DateTime(2011, 12, 15),
                    Tmin = 21,
                    Tmax = 34,
                    Precipitacion = 0,
                    ETo = 132,

                    Viento = 2.5,
                    //pptDebajo = 52.5329878335,
                    //pptDentro =0,
                    //pptSobre=47.4670121665,
                    SPI = 1
                });

                //Datos iniciales de estación Repelón 01/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 17,
                    Fecha = new DateTime(2012, 01, 15),
                    Tmin = 22.284375,
                    Tmax = 33.734375,
                    Precipitacion = 0,
                    ETo = 141.854552651607,

                    Viento = 2.5,
                    //pptDebajo = 13.4808903894,
                    //pptDentro = 19.2007578179,
                    //pptSobre = 67.3183517927,
                    SPI = 1
                });

                //Datos iniciales de estación Repelón 02/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 17,
                    Fecha = new DateTime(2012, 02, 15),
                    Tmin = 22.9875,
                    Tmax = 33.58755,
                    Precipitacion = 0,
                    ETo = 135.721165044803,

                    Viento = 2.5,
                    SPI = 1
                });

                //Datos iniciales de estación Repelón 03/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 17,
                    Fecha = new DateTime(2012, 03, 15),
                    Tmin = 23.540625,
                    Tmax = 33.203125,
                    Precipitacion = 21.6,
                    ETo = 145.257899216653,

                    Viento = 2.5,
                    SPI = 1
                });

                //Datos iniciales de estación Repelón 04/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 17,
                    Fecha = new DateTime(2012, 04, 15),
                    Tmin = 23.540625,
                    Tmax = 33.203125,
                    Precipitacion = 21.6,
                    ETo = 145.257899216653,

                    Viento = 2.5,
                    SPI = 1
                });

                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 17,
                    Fecha = new DateTime(2015, 03, 15),
                    Tmin = 23.540625,
                    Tmax = 33.203125,
                    Precipitacion = 21.6,
                    ETo = 145.257899216653,
                    Viento = 2.5,
                    SPI = 1
                });

                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 17,
                    Fecha = new DateTime(2015, 04, 15),
                    Tmin = 23.540625,
                    Tmax = 33.203125,
                    Precipitacion = 21.6,
                    ETo = 145.257899216653,
                    Viento = 2.5,
                    SPI = 1
                });

                //Manatí
                contexto.ZonaMensual.Add(new ZonaMensual
                {
                    Fecha = new DateTime(2012, 01, 15),
                    Ss0 = 0,
                    Su0 = 16.9855,
                    ZonaId = 2
                });

                //Datos iniciales de estación Manatí 12/2011
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2011, 12, 15),
                    Tmin = 21,
                    Tmax = 34,
                    Precipitacion = 0,
                    ETo = 132,
                    Viento = 2.5,
                    SPI = 1
                });

                //Datos iniciales de estación Manatí 01/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2012, 01, 15),
                    Tmin = 22.284375,
                    Tmax = 33.734375,
                    Precipitacion = 0,
                    ETo = 141.854552651607,
                    Viento = 2.5
                });

                //Datos iniciales de estación Manatí 02/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2012, 02, 15),
                    Tmin = 22.9875,
                    Tmax = 33.58755,
                    Precipitacion = 0,
                    ETo = 135.721165044803,
                    Viento = 2.5
                });

                //Datos iniciales de estación Manatí 03/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2012, 03, 15),
                    Tmin = 23.540625,
                    Tmax = 33.203125,
                    Precipitacion = 21.6,
                    ETo = 145.257899216653,
                    Viento = 2.5
                });

                //Datos iniciales de estación Manatí 04/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2012, 04, 15),
                    Tmin = 24.3,
                    Tmax = 32.525,
                    Precipitacion = 40,
                    ETo = 131.1202,
                    Viento = 2.5
                });

                //Datos iniciales de estación Manatí 05/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2012, 05, 15),
                    Tmin = 24.303125,
                    Tmax = 31.8218745,
                    Precipitacion = 134.3,
                    ETo = 126.6231,
                    Viento = 2.5
                });

                //Datos iniciales de estación Manatí 06/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2012, 06, 15),
                    Tmin = 24.246875,
                    Tmax = 32.071875,
                    Precipitacion = 94.3,
                    ETo = 124.1942,
                    Viento = 2.5
                });

                //Datos iniciales de estación Manatí 07/2012
                contexto.EstacionMensual.Add(new EstacionMensual
                {
                    EstacionId = 2,
                    Fecha = new DateTime(2012, 07, 15),
                    Tmin = 24,
                    Tmax = 32.2875,
                    Precipitacion = 110.3,
                    ETo = 132.9871,
                    Viento = 2.5
                });

                //ZonaEstacion

                //Repelón - Tomate
                contexto.ZonaEstacion.Add(new ZonaEstacion
                {
                    ZonaId = 1,
                    EstacionId = 17,
                    Porcentaje = 100,
                    CadenaPE = "13,8866;15;22,0991;68,6871;100,8694;97,6494;84,0757;98,9188;100,9886;103,4464;73,4089;39,2142",
                    //Eto
                    CadenaET = "141,7070;132;144,8895;130,9877;126,4608;124,1136;132,8182;133,5900;124,0034;120,1770;113,2364;126,6724",
                    CadenaRO = "0,0000;0;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000",
                    CadenaPRO = "9,6788;1;0,4139;0,0440;0,3959;4,6908;4,4965;2,2652;4,5210;7,8904;11,8418;13,0425",
                    CadenaR = "0,0000;0;0,0000;0,3733;4,6708;3,7386;1,1763;2,6018;4,8775;7,0868;6,0219;0,3311",
                    CadenaPR = "170,3212;179;179,5861;179,9560;179,6041;175,3092;175,5035;177,7348;175,4790;172,1096;168,1582;166,9575",
                    CadenaL = "3,0591;1;0,3700;0,0214;0,3758;3,9329;3,4075;0,3460;1,5081;3,1354;4,8212;8,7890",
                    CadenaPL = "3,1075;1;0,3758;0,0315;0,3876;4,6366;4,3626;1,9893;3,9558;6,5600;9,2040;9,5527",
                    CantidadCadenas = 32,
                    CadenaKs = "0,0809;0,0726;0,0696;0,0594;0,0565;0,0567;0,0569;0,0552;0,0560;0,0578;0,0428;0,0579",
                    CadenaZs = "-0,194031649519384;0,708358154237920;1,57126559774297;1,44636815221088;1,13827193809734;1,10145203328923;2,50034397576852;1,29962627527063;0,795520799951849;1,11496135443437;2,85819278611814;4,07603121416745",
                    CadenaX1s = "0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000",
                    CadenaX2s = "-0,0655;0;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000",
                    CadenaX3s = "2,0897;2,1229;2,4391;2,6923;2,8035;2,8978;3,4472;3,5364;3,4461;3,4752;4,0782;4,9595"
                });


                //Manatí - Tomate
                contexto.ZonaEstacion.Add(new ZonaEstacion
                {
                    ZonaId = 2,
                    EstacionId = 2,
                    Porcentaje = 100,
                    CadenaPE = "13,8866;15;22,0991;68,6871;100,8694;97,6494;84,0757;98,9188;100,9886;103,4464;73,4089;39,2142",
                    //Eto
                    CadenaET = "141,7070;132;144,8895;130,9877;126,4608;124,1136;132,8182;133,5900;124,0034;120,1770;113,2364;126,6724",
                    CadenaRO = "0,0000;0;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000",
                    CadenaPRO = "9,6788;1;0,4139;0,0440;0,3959;4,6908;4,4965;2,2652;4,5210;7,8904;11,8418;13,0425",
                    CadenaR = "0,0000;0;0,0000;0,3733;4,6708;3,7386;1,1763;2,6018;4,8775;7,0868;6,0219;0,3311",
                    CadenaPR = "170,3212;179;179,5861;179,9560;179,6041;175,3092;175,5035;177,7348;175,4790;172,1096;168,1582;166,9575",
                    CadenaL = "3,0591;1;0,3700;0,0214;0,3758;3,9329;3,4075;0,3460;1,5081;3,1354;4,8212;8,7890",
                    CadenaPL = "3,1075;1;0,3758;0,0315;0,3876;4,6366;4,3626;1,9893;3,9558;6,5600;9,2040;9,5527",
                    CantidadCadenas = 32,
                    CadenaKs = "0,0809;0,0726;0,0696;0,0594;0,0565;0,0567;0,0569;0,0552;0,0560;0,0578;0,0428;0,0579",
                    CadenaZs = "-0,194031649519384;0,708358154237920;1,57126559774297;1,44636815221088;1,13827193809734;1,10145203328923;2,50034397576852;1,29962627527063;0,795520799951849;1,11496135443437;2,85819278611814;4,07603121416745",
                    CadenaX1s = "0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000",
                    CadenaX2s = "-0,0655;0;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000;0,0000",
                    CadenaX3s = "2,0897;2,1229;2,4391;2,6923;2,8035;2,8978;3,4472;3,5364;3,4461;3,4752;4,0782;4,9595"
                });

                //Estaciones municipio
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 6
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 11
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 12
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 13
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 14
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 15
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 16
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 1,
                    EstacionId = 17
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 2,
                    EstacionId = 1
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 2,
                    EstacionId = 2
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 2,
                    EstacionId = 3
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 2,
                    EstacionId = 4
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 3,
                    EstacionId = 2
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 3,
                    EstacionId = 5
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 3,
                    EstacionId = 6
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 3,
                    EstacionId = 10
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 4,
                    EstacionId = 1
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 4,
                    EstacionId = 2
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 4,
                    EstacionId = 7
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 4,
                    EstacionId = 8
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 4,
                    EstacionId = 9
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 5,
                    EstacionId = 1
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 5,
                    EstacionId = 7
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 5,
                    EstacionId = 8
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 5,
                    EstacionId = 18
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 6,
                    EstacionId = 1
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 6,
                    EstacionId = 2
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 6,
                    EstacionId = 3
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 6,
                    EstacionId = 5
                });
                contexto.MunicipioEstacions.Add(new MunicipioEstacion
                {
                    MunicipioId = 6,
                    EstacionId = 6
                });

                //Tipos de predicción

                contexto.TipoPrediccion.Add(new TipoPrediccion
                {
                    TipoPrediccionId = 1,
                    Nombre = "Húmedo",
                    Minimo = 1,
                    Maximo = 5
                });

                contexto.TipoPrediccion.Add(new TipoPrediccion
                {
                    TipoPrediccionId = 2,
                    Nombre = "Normal",
                    Minimo = -0.99,
                    Maximo = 0.99
                });

                contexto.TipoPrediccion.Add(new TipoPrediccion
                {
                    TipoPrediccionId = 3,
                    Nombre = "Seco",
                    Minimo = -5,
                    Maximo = -1
                });

                contexto.SaveChanges();

                //Etapas del cultivo

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 1,
                    Nombre = "Inicial"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 2,
                    Nombre = "Desarrollo"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 3,
                    Nombre = "Medio"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 4,
                    Nombre = "Final"
                });

                contexto.CultivoEtapa.Add(new CultivoEtapa
                {
                    CultivoEtapaId = 5,
                    Nombre = "Sin etapa"
                });

                contexto.SaveChanges();

                //Areas tematicas para opciones tecnologicas
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 1,
                    Codigo = 11,
                    Nombre = "Gestión del agua en la finca"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 2,
                    Codigo = 12,
                    Nombre = "Sistema de riego eficiente"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 3,
                    Codigo = 13,
                    Nombre = "Suministro de agua: aguas no convencionales"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 4,
                    Codigo = 14,
                    Nombre = "Captación y almacenamiento de agua"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 5,
                    Codigo = 21,
                    Nombre = "Material vegetal certificado"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 6,
                    Codigo = 22,
                    Nombre = "Material vegetal con potencial genético"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 7,
                    Codigo = 23,
                    Nombre = "Biotecnología animal"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 8,
                    Codigo = 24,
                    Nombre = "Adaptación de materiales"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 9,
                    Codigo = 25,
                    Nombre = "Bancos de germoplasma"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 10,
                    Codigo = 31,
                    Nombre = "Prácticas de siembra (semillero)"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 11,
                    Codigo = 32,
                    Nombre = "Manejo y conservación de suelo"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 12,
                    Codigo = 33,
                    Nombre = "Labranza del suelo"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 13,
                    Codigo = 34,
                    Nombre = "Manejo de la fertilidad del suelo"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 14,
                    Codigo = 35,
                    Nombre = "Manejo de plagas"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 15,
                    Codigo = 36,
                    Nombre = "Manejo de enfermedades"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 16,
                    Codigo = 37,
                    Nombre = "Manejo de arvenses"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 17,
                    Codigo = 38,
                    Nombre = "Cosecha y poscosecha"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 18,
                    Codigo = 39,
                    Nombre = "Recomendaciones técnicas y prácticas de manejo"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 19,
                    Codigo = 310,
                    Nombre = "Sanidad y bienestar animal"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 20,
                    Codigo = 311,
                    Nombre = "Manejo de praderas"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 21,
                    Codigo = 312,
                    Nombre = "Alimentación y nutrición animal"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 22,
                    Codigo = 313,
                    Nombre = "Instalaciones pecuarias y bienestar animal"
                });
                contexto.AreaTematica.Add(new AreaTematica
                {
                    AreaTematicaId = 23,
                    Codigo = 314,
                    Nombre = "Ganadería sostenible"
                });

                contexto.SaveChanges();

                //OpcionTecnologica antes llamada Acciones

                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 1,
                    Nombre = "Optimización del recurso hídrico: Riego por aspersión o riego por goteo",
                    AreaTematicaId = 1
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 2,
                    Nombre = "Cosecha de agua: diseño de reservorios y captación de aguas.",
                    AreaTematicaId = 1
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 3,
                    Nombre = "Manejo y conservación de suelos",
                    AreaTematicaId = 11
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 4,
                    Nombre = "Plan de fertilización y análisis de suelos. Manejo e incorporación de abonos orgánicos",
                    AreaTematicaId = 11
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 5,
                    Nombre = "MIP  (Manejo integrado de plagas)",
                    AreaTematicaId = 14
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 6,
                    Nombre = "Incorporación de materia orgánica al suelo",
                    AreaTematicaId = 10
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 7,
                    Nombre = "Densidad de siembra",
                    AreaTematicaId = 10
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 8,
                    Nombre = "Manejo y selección de material vegetal: semilla",
                    AreaTematicaId = 6
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 9,
                    Nombre = "Plan de manejo agronómico",
                    AreaTematicaId = 10
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 10,
                    Nombre = "Redes de drenajes: Manejo",
                    AreaTematicaId = 2
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 11,
                    Nombre = "Prácticas culturales: podas",
                    AreaTematicaId = 18
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 12,
                    Nombre = "Manejo y selección de material vegetal ",
                    AreaTematicaId = 5
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 13,
                    Nombre = "Manejo de praderas",
                    AreaTematicaId = 20
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 14,
                    Nombre = "Biofertilización en plantulación - Micorrizas",
                    AreaTematicaId = 10
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 15,
                    Nombre = "Opciones de alimentaciones (ensilaje, henolaje, BMN, hornos forrajeros)",
                    AreaTematicaId = 18
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 16,
                    Nombre = "Selección y establecimiento de pastos y forrajes",
                    AreaTematicaId = 20
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 17,
                    Nombre = "Plan sanitario",
                    AreaTematicaId = 19
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 18,
                    Nombre = "BPG",
                    AreaTematicaId = 20
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 19,
                    Nombre = "Uso de polisombras",
                    AreaTematicaId = 18
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 20,
                    Nombre = "Aplicación de lombriabono como enmienda orgánica ",
                    AreaTematicaId = 11
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 21,
                    Nombre = "Sistemas de riego por goteo",
                    AreaTematicaId = 1
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 22,
                    Nombre = "Construcción de reservorios de agua como fuente disponible para riego",
                    AreaTematicaId = 4
                });
                contexto.OpcionTecnologica.Add(new OpcionTecnologica
                {
                    OpcionTecnologicaId = 23,
                    Nombre = "Aplicación de enmiendas y abonos orgánicos e inorgánicos. ",
                    AreaTematicaId = 13
                });


                contexto.SaveChanges();
                contexto.TipoOferta.Add(new TipoOferta
                {
                    TipoOfertaId = 1,
                    Nombre = "Gestión del agua"

                });
                contexto.TipoOferta.Add(new TipoOferta
                {
                    TipoOfertaId = 2,
                    Nombre = "Prácticas de manejo"

                });
                contexto.TipoOferta.Add(new TipoOferta
                {
                    TipoOfertaId = 3,
                    Nombre = "Recursos genéticos"

                });
                contexto.SaveChanges();

                //ListaOpciones - OT
               contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =1,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=1,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =1,
                    EstadoDesarrolloCultivo = "Plantulación",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =2,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=1,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =2,
                    EstadoDesarrolloCultivo = "Plantulación",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =3,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =3,
                    EstadoDesarrolloCultivo = "Crecimiento",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =4,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =4,
                    EstadoDesarrolloCultivo = "Crecimiento",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =5,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =5,
                    EstadoDesarrolloCultivo = "Crecimiento",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =6,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =6,
                    EstadoDesarrolloCultivo = "Plantulación",
                    IndicadorLocal=false
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =7,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=3,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =8,
                    EstadoDesarrolloCultivo = "Floración",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =8,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=1,
                    TipoPrediccionId=1,
                     OpcionTecnologicaId =10,
                    EstadoDesarrolloCultivo = "Fructificación",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =9,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=1,
                     OpcionTecnologicaId =5,
                    EstadoDesarrolloCultivo = "Cosecha",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =10,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=1,
                     OpcionTecnologicaId =11,
                    EstadoDesarrolloCultivo = "Cosecha",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =11,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=3,
                    TipoPrediccionId=1,
                     OpcionTecnologicaId =12,
                    EstadoDesarrolloCultivo = "No aplica",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =12,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=1,
                    TipoPrediccionId=2,
                     OpcionTecnologicaId =9,
                    EstadoDesarrolloCultivo = "No aplica",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =13,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=2,
                     OpcionTecnologicaId =9,
                    EstadoDesarrolloCultivo = "No aplica",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =14,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=3,
                    TipoPrediccionId=2,
                     OpcionTecnologicaId =9,
                    EstadoDesarrolloCultivo = "No aplica",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =15,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=1,
                     OpcionTecnologicaId =19,
                    EstadoDesarrolloCultivo = "No aplica",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =16,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=1,
                     OpcionTecnologicaId =20,
                    EstadoDesarrolloCultivo = "Crecimiento",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =17,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=1,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =21,
                    EstadoDesarrolloCultivo = "Todas",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =18,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=1,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =22,
                    EstadoDesarrolloCultivo = "No aplica",
                    IndicadorLocal=true
                });
contexto.ListaOpciones.Add(new ListaOpciones
                { ListaOpcionesId =19,
                    CultivoId = 1,
                    MunicipioId = 1,
                    TipoOfertaId=2,
                    TipoPrediccionId=3,
                     OpcionTecnologicaId =23,
                    EstadoDesarrolloCultivo = "No aplica",
                    IndicadorLocal=true
                });


                contexto.SaveChanges();

                //Fichas Opcion OT
              
                //Efectos

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "Si la planta se encuentra en estado de desarrollo vegetativo y  ya está establecida, se podría presentar un crecimiento limitado pudiendo causar enanismo."
                });

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "Si la planta se encuentra periodo de floración, puede presentar caída de flores y pudrición de los órganos florales. Asimismo al inicio de la fase se puede presentar una reducción en la formación de flores."
                });

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "Si la planta se encuentra en periodo de fructificación, estará más susceptible a la de problemas fitosanitarios y por tanto, disminución en la calidad de los frutos, aparición de signos del desarrollo de patógeno, deformación."
                });

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "Se presentará una disminución de la germinación. Es así como en la fase de plantulación se presentará un alto porcentaje de muerte."
                });

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "Si la planta ya se encuentra establecida, se puede presentar amarillamiento y senescencia. Desprendimiento de las hojas y su enrollamiento. También se presenta disminución de la expansión foliar y el aumento del crecimiento radicular."
                });

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "Si la planta se encuentra en su fase productiva se presentaría caída de flores y aborto de frutos."
                });

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "También se presentará disminución en el número de flores y frutos, en la masa promedio de los frutos, formas irregulares de los mismos y del porcentaje de fructificación."
                });

                contexto.Efectos.Add(new Efectos
                {
                    Nombre = "Asimismo se verá afectada la producción con una disminución de la producción y malformaciones de los órganos reproductivos. En esta fase se presenta una aceleración de la senescencia."
                });

                contexto.SaveChanges();

                //Ofertas

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 1,
                    TipoPrediccionId = 1,
                    EfectoId = 1
                });

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 2,
                    TipoPrediccionId = 1,
                    EfectoId = 2
                });

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 2,
                    TipoPrediccionId = 1,
                    EfectoId = 3
                });

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 1,
                    TipoPrediccionId = 3,
                    EfectoId = 4
                });

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 3,
                    TipoPrediccionId = 3,
                    EfectoId = 5
                });

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 3,
                    TipoPrediccionId = 3,
                    EfectoId = 6
                });

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 4,
                    TipoPrediccionId = 3,
                    EfectoId = 7
                });

                contexto.Ofertas.Add(new Ofertas
                {
                    CultivoId = 1,
                    CultivoEtapaId = 4,
                    TipoPrediccionId = 3,
                    EfectoId = 8
                });

                contexto.SaveChanges();

                //Acciones - Efectos

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 2,
                    AccionId = 1
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 2,
                    AccionId = 2
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 2,
                    AccionId = 3
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 3,
                    AccionId = 1
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 3,
                    AccionId = 2
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 3,
                    AccionId = 3
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 1,
                    AccionId = 5
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 1,
                    AccionId = 6
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 4,
                    AccionId = 1
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 4,
                    AccionId = 2
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 4,
                    AccionId = 3
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 5,
                    AccionId = 1
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 5,
                    AccionId = 2
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 5,
                    AccionId = 3
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 6,
                    AccionId = 1
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 6,
                    AccionId = 2
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 6,
                    AccionId = 3
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 7,
                    AccionId = 4
                });

                contexto.EfectosAcciones.Add(new EfectosAcciones
                {
                    EfectoId = 6,
                    AccionId = 3
                });

                contexto.SaveChanges();

                //Opciones tecnológicas

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 1,
                    Nombre = "Riego",
                    Resumen = "Para decidir cuándo y cuánto regar hay que conocer la cantidad de agua que requieren los cultivos en cada momento de su desarrollo y realizar un balance entre la oferta de agua disponible y la cantidad requerida por las plantas. Por lo tanto, se recomienda suplir los requerimientos hídricos del cultivo de tomate, en distintas etapas fenológicas y estrategias de sistemas de riego.",
                    Explicacion = "<p class='textoDetalle'><b>¿Por qué utilizar un sistema de riego?</b></p><p class='textoDetalle'>Los sistemas de riego establecidos teniendo en cuenta las necesidades de los cultivos en las distintas etapas fenológicas, ayuda a mitigar los efectos negativos por estrés hídrico, que en muchas ocasiones puede llegar a ocasionar aborto floral, diminución en la calidad y rendimiento de la producción.</p><p class='textoDetalle'><b>Beneficios del uso adecuado de un sistema de riego </b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Ayuda a optimizar el uso de los recursos hídricos y medio ambientales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Aumenta la posibilidad de producir de manera programada de acuerdo a los volúmenes requeridos para cada etapa del cultivo, así como el incremento de la producción y el mejoramiento de la calidad.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Ayuda a controlar y manejar problemas fitosanitarios, siempre y cuando se emplee el sistema de riego adecuado para cada sistema de producción.</li></ul><p class='textoDetalle'><b>Posibles limitantes de la instalación y uso del sistema de riego</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Costos y disponibilidad de los materiales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mantenimiento adecuado del sistema.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Para las propiedades de cada suelo (textura) la distribución de agua en el suelo va a ser distinta.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Disponibilidad y calidad de agua para riego y energía para su funcionamiento.</li></ul><p class='textoDetalle'><b>Instalación de un sistema de riego</b></p><p class='textoDetalle'>La selección del tipo de sistema de riego a instalar va a depender del sistema productivo, disponibilidad y calidad del agua, tipo de suelo, edad del cultivo, costo de la inversión, entre otros factores que pueden ser determinantes en el momento de escoger el tipo de riego a instalar. Dentro de los sistemas de riego frecuentemente empleados para el suministro de agua en cultivos agrícolas se encuentran:</p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Riego por goteo. Este sistema de riego tiene la ventaja que el agua se aplica directamente a las raíces de las plantas, lo cual disminuye las pérdidas de agua por evaporación y la proliferación de enfermedades por excesos de humedad. En el riego por goteo se pueden presentar algunas dificultades cuando los goteros se obstruyen por partículas que vienen en el agua de riego.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Fertirriego. Este sistema de riego es empleado para combinar la aplicación de agua y fertilizantes, que ayuda a que sea uniforme la aplicación de agua y nutrientes mediante aplicaciones fraccionadas a lo largo del ciclo del cultivo, lo que además posibilita la adición de ciertos nutrientes, requeridos en etapas específicas del cultivo. El fertirriego demanda el uso de fertilizantes fácilmente solubles; estos fertilizantes en el mercado no tienen suficiente oferta para garantizar la aplicación de todos los nutrientes requeridos por el cultivo.</li></ul>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Cepeda,x F., Ovalle, I., & Garzón, C. (2000). SIEMBRA. Recuperado el 2013, de <a target='_blank' href='http://www.siembra.gov.co/siembra/main.aspx'>http://www.siembra.gov.co/siembra/main.aspx</a></li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Flores, J., Ojeda, W., López, I., Rojano, A., & Salazar, I. (2007). Requerimientos de riego para tomate de invernadero. Universidad Autónoma Chapingo.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Francisco, A., Diaz, T., & Ramirez, M. (2000). SIEMBRA. Recuperado el 2013, de <a target='_blank' href='http://www.siembra.gov.co/siembra/main.aspx'>http://www.siembra.gov.co/siembra/main.aspx</a></li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>González, A., & Hernández, B. (2000). Estimación de las necesidades hídricas del tomate. Instituto Nacional de Investigaciones Forestales, Agrícolas y Pecuarias.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hernandez, R. (2009). Estimación de la evapotranspiración de cultivo y requerimientos hidricos del tomate (Lycopersicon esculentum Mill. Cv El Cid) en invernadero.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Legarda, L., Puentes, G., & Arteaga, G. (2001). Universidad de Nariño. >Recuperado el 2013, de <a target='_blank' href='http://201.234.78.28:8080/jspui/bitstream/123456789/264/1/2006102417222_Sistema%20de%20riego%20por%20exudacion%20Tomate.pdf'>http://201.234.78.28:8080/jspui/bitstream/123456789/264/1/2006102417222_Sistema%20de%20riego%20por%20exudacion%20Tomate.pdf</a></li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Perengüez, O. (2011). Respuesta fisiológica del tomate (Solanum lycopersicon L.) UNAPAL- MARAVILLA, a diferentes láminas de riego y su efecto en la absorción de nutrientes.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Terán, C., Valenzuela, M., Villaneda, E., & Sánchez, G. (2007). Manejo del riego y la fertirrigación en tomate bajo cubierta en la sabana de Bogotá.</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 2,
                    Nombre = "Cobertura de suelo con residuos vegetales",
                    Resumen = "La cobertura de los suelos se emplea para dar solución a diferentes inconvenientes que pueden llegar a presentarse en los cultivos, entre los que se encuentran el crecimiento de malezas o arvenses, disminuir el consumo de agua y de problemas fitosanitarios.",
                    Explicacion = "<p class='textoDetalle'><b>¿Qué tipos de cobertura puedo utilizar?</b></p><p class='textoDetalle'>Los tipos de cobertura están determinados de acuerdo al fin para el cuál se va a disponer la cobertura y disponibilidad de materiales, que interfiere directamente en los costos de instalación. La cobertura del suelo puede hacerse con plásticos (polietileno) o con residuos de vegetal; esta última, además de cumplir el papel de cubrir el suelo, hace parte de la incorporación de materia orgánica al suelo.</p><p class='textoDetalle'><b>Beneficios de la cobertura del suelo</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Reducción de los problemas ocasionados por la presencia de malezas o arvenses, que también pueden ser focos de plagas o enfermedades.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El uso de coberturas incrementa la eficiencia del agua aplicada, porque disminuye sustancialmente la evaporación.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El cubrimiento del suelo con residuos vegetales constituye otra práctica de manejo que atenúa el impacto de la salinidad del suelo en el cultivo, puesto que al reducirse la evaporación desde la superficie del suelo se minimiza el movimiento ascendente de las sales (Goykovic & Saveedra, 2007).</li></ul><p class='textoDetalle'><b>¿Qué materiales puedo emplear como cobertura de suelo?</b></p><p class='textoDetalle'>El uso Mucuna pruriens y Clitoria ternatea como cobertura del suelo y la fertilización reducida de N, P y K produjeron una cantidad similar o mayor en el número de frutos totales y de tamaños grande y mediano, ya sea con o sin acolchado plástico. Las leguminosas aumentan la capacidad de almacenamiento de humedad del suelo, reducen la competencia de malezas, rompen los ciclos de plagas y enfermedades (Villareal, y otros, 2006). Para el control de arvenses, las coberturas más utilizadas recientemente son, Polietileno Calibre 3  plateado.</p>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Abdul-Baki, A., & Teasdale, J. (2007). Sustainable Production of Fresh-Market Tomatoes and Other Vegetables With Cover Crop Mulches. United States Department of Agriculture (USDA).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Goykovic, V., & Saveedra, G. (2007). Algunos efectos de la salinidad en el cultivo del tomate y prácticas agrónomicas para su manejo. Universidad de Tarapaca y INIA.</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 3,
                    Nombre = "Densidad de siembra"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 4,
                    Nombre = " Materia orgánica"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 5,
                    Nombre = "Fertilización y biofertilización",
                    Resumen = "La decisión de fertilizar implica la definición de los tiempos oportunos, las cantidades requeridas y la planeación estratégica del tipo fertilizantes a aplicar, teniendo en cuenta que esta labor va a suplir los nutrientes que no se encuentran disponibles en el suelo para que puedan ser tomados por las plantas. Por lo tanto, se recomienda suplir los requerimientos de nutrientes de los cultivos, en distintas etapas fenológicas a través de un plan de fertilización.",


                    Explicacion = "<p class='textoDetalle'><b>¿Qué tipos de fertilización puedo utilizar?</b></p><p class='textoDetalle'>Los tipos de fertilización están determinados a partir del tipo de cultivo, la edad del cultivo, disponibilidad de recursos, entre otros factores; sin embargo, es importante resaltar que la fertilización es una de las labores determinantes en los rendimientos y calidad de la producción en los cultivos.</p><p class='textoDetalle'>En consecuencia, se puede emplear la fertilización edáfica (suelo) para la aplicación de fertilizantes que van a suplir las deficiencias en los suelos, determinadas con la ayuda de un análisis de suelo; esta puede hacerse mediante la incorporación de los fertilizantes al suelo directamente o a través del fertirriego. La fertilización foliar (hojas), se utiliza para hacer llegar los nutrientes necesarios directamente a la planta y de tal forma haya un óptimo crecimiento y desarrollo de los cultivos; este tipo de aplicaciones son empleadas cuando los cultivos presentan deficiencias nutricionales. Otra forma de poner a disposición de los cultivos los nutrientes necesarios, es la biofertilización, que básicamente emplea microorganismos para que en una relación simbiótica los cultivos puedan desarrollar mejor la labor de captura y absorción de nutrientes.</p><p class='textoDetalle'><b>¿Qué debo tener en cuenta para fertilizar?</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Tipo de cultivo pues no son iguales las necesidades de nutrientes para un cultivo de hortalizas (tomate, cebolla, etc.), que los requerimientos de un cultivo permanente o transitorio como pueden ser el mango o yuca, respectivamente.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Edad del cultivo porque en las etapas iniciales de los cultivos, es decir, siembra y crecimiento, una buena nutrición va a determinar en gran parte de los resultados de la cosecha. Por otra parte, cuando los cultivos se encuentran cercanos al llenado de frutos, es fundamental la fertilización aumentando es suministro de ciertos nutrientes que intervienen en este proceso. Es importante que previo a la siembra y teniendo en cuenta los resultados del análisis de suelo, se deben hacer aplicaciones correctivas al pH o algunos nutrientes que no se encuentren disponibles de acuerdo a los requerimientos del cultivo.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Disponibilidad de mano de obra, maquinaria, tipo de fertilizantes, contenido de nutrientes aportado por fertilizante y calidad del agua (cuando es foliar).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Condiciones climáticas, específicamente cuando la aplicación de fertilizantes es edáfica, es fundamental que hayan precipitaciones para los fertilizantes puedan se incorporen rápidamente al suelo y sean disponibles para las plantas.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Recomendaciones del técnico o agrónomo, para la definición del tipo de fertilizantes a emplear, cantidades y frecuencias para garantizar que las plantas puedan disponer de los nutrientes necesarios para el óptimo crecimiento y desarrollo. Cuando la fertilización es foliar, es fundamental tener precaución y hacer una revisión juiciosa en la mezcla de los fertilizantes con los plaguicidas, pues puede llegar a presentarse inactivación de algunos ingredientes activos.</li></ul><p class='textoDetalle'><b>¿Cómo fertilizar?</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Cuando la fertilización es edáfica se debe definir la cantidad de fertilizante a aplicar por planta o por hectárea. Lo anterior, determinado a partir de los resultados del análisis de suelo y disponibilidad de fertilizantes en la zona.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Cuando la fertilización es foliar se debe tener en cuenta la cantidad de agua por área o por planta (calibración de equipo de aplicación) y la dosis recomendada para cada uno de los fertilizantes a utilizar.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>La biofertilización debe realizarse en plantulación, vivero o semillero y en el momento del trasplante, teniendo en cuenta la dosis recomendada por cada uno de los biofertilizantes a utilizar.</li></ul>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hidalgo, J., Alcantar, G., Baca, G., Sánchez, P., & Escalante, A. (1998). Efecto de la condición nutrimental de las plantas y de la composición, concentración y pH del fertilizante foliar, sobre el rendimiento y calidad en tomate. TERRA.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Orna-Chaves, A. (2009). Evaluacion del efecto de la aplicación de micorrizas en la produccion de tomate riñon (Solanum lycopersicum) bajo invernadero. Escuela Superior Politecnica de Chimborazo.</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 6,
                    Nombre = "Plan de manejo (P6)"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 7,
                    Nombre = "Manejo de residuos orgánicos"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 8,
                    Nombre = "Manejo de residuos inorgánicos",
                    Resumen = "El cultivo del tomate y ají, generan grandes cantidades de residuos agrícolas, compuestos por residuos orgánicos e inorgánicos. Los residuos orgánicos pueden ser reutilizados a través de la incorporación directamente al suelo o a través de procesos como el compostaje, lombricultura o ensilaje. Los inorgánicos; en cambio, tales como plásticos y envases de agroquímicos demandan de un cuidado especial ya que pueden ser considerados como residuos potencialmente peligrosos.",
                    Explicacion = "<p class='textoDetalle'><b>¿Qué prácticas debo evitar en la manipulación de los residuos inorgánicos?</b></p><p class='textoDetalle'>Para el caso de los residuos inorgánicos (envases) es común la práctica de reutilización de envases de agroquímicos de vidrio, plástico o metal, tales como bidones, sacos, cajas, tambores entre otros. No se deben reutilizar para almacenar diferentes productos (semillas, agua, alimentos, otros productos, etc.), puesto que implica un riesgo.</p><p class='textoDetalle'>Las prácticas como la incineración o el entierro en el campo; son inadecuadas y riesgosas para la salud humana y el medio ambiente.</p><p class='textoDetalle'><b>¿Qué debo hacer?</b></p><p class='textoDetalle'>Los envases vacíos deben pasar por el proceso de triple lavado y deben guardarse en una bodega identificados como peligrosos, todo con la finalidad de no ser reutilizado, y poder ser trasladados a un centro de acopio que se encarga de la disposición final (reciclado, entierro o incineración) en forma segura.</p><p class='textoDetalle'>Para el caso de los residuos de plástico como cintas de riego, amarras de conducción, plásticos de cobertura de invernaderos, etc. se recomienda reutilizarlos siempre que se encuentren en buen estado y sanitizados, nunca quemarlos, ya que su combustión libera toxinas peligrosas para el ser humano y el ambiente.</p><p class='textoDetalle'><b>¿Qué importancia tiene realizar esta práctica?</b></p><p class='textoDetalle'>El retiro los envases de agroquímicos vacíos tiene un fuerte impacto positivo en el ambiente, ya que permite disminuir los riesgos a la salud humana, suelo, agua, además de la contaminación visual del lugar. Los nuevos productos generados por los procesos de reciclaje permiten minimizar el uso de los recursos naturales reduciendo los costos de producción.</p>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Comisión Nacional de Buenas Prácticas agrícolas. 2008. Especificaciones técnicas de Buenas Prácticas Agrícolas – cultivo de hortalizas. Disponible en: <a target='_blank' href='http://www.buenaspracticas.cl/index.php?option=com_content&task=view&id=45&Itemid=120'>http://www.buenaspracticas.cl/index.php?option=com_content&task=view&id=45&Itemid=120.</a>Consultado en marzo de 2009.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Jaramillo, J., Rodríguez, V., Guzmán, M., Zapata, M. y Rengifo, T. 2007. Manual técnico Buenas Prácticas Agrícolas en la producción de tomate bajo condiciones protegidas. CTP Print. Medellín, Colombia. 315 p.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Parrado, C. y Ubaque, H. 2004. Buenas Prácticas Agrícolas en sistemas de producción de tomate bajo invernadero. Universidad de Bogotá Jorge Tadeo Lozano. Bogota, Colombia. 35 p.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Loomis, R. A. y Connor D. J. 2002. Ecología de cultivos, productividad y manejo en sistemas agrarios. Mundi-Prensa, Madrid, España. 590 p.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Izquierdo J., Rodríguez M. y Durán M. 2007. Manual de Buenas Prácticas Agrícolas para la agricultura familiar. CTP Print. Medellín, Colombia. 60 p.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Martínez, A. 2008. Envases de agroquímicos, enemigo venenoso y silencioso. Revista Ambiental Catorce 6. Bogotá, Colombia.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Escalona, V., Alvarado, P., Monardes, H. Urbina, C, Martin, A. 2009.  B. Manual de cultivo de tomate (Lycopersicon esculentum Mill.)</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 9,
                    Nombre = " Sales minerales"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 10,
                    Nombre = "Concentrado",
                    Resumen = "El manejo alimenticio de las vacas lecheras es uno de los factores de mayor incidencia y relevancia en la producción. Para realizar correctamente dicha labor, se recomienda que esta sea con base en los requerimientos nutritivos, de acuerdo al peso vivo, nivel de producción y momento de lactancia en que se encuentran los animales",
                    Explicacion = "<p class='textoDetalle'><b>¿Cómo se clasifican los alimentos para ganado?</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Forrajes.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Concentrados (alimentos para energía y proteína).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Minerales y vitaminas.</li></ul><p class='textoDetalle'><b>¿Qué es un concentrado?</b></p><p class='textoDetalle'>Son alimentos con alto contenido de energía y poca fibra. Los granos de los cereales como el trigo, centeno, cebada, avena, maíz y sorgo son los más importantes.</p><p class='textoDetalle'>Cuando el concentrado forma más del 60-70% de la ración puede provocar problemas de salud en el animal.</p><p class='textoDetalle'><b>Beneficio de los concentrados</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Son bajos en fibra y altos en energía.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Tienen alta palatabilidad y usualmente son comidos rápidamente.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>No estimulan la ruminación.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Usualmente fermentan más rápidamente que los forrajes en el rumen.</li></ul><p class='textoDetalle'><b>¿Qué concentrados se encuentran?</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Granos de cereales: (cebada, maíz, sorgo, arroz, trigo) son alimentos de alta energía pero pobres en proteínas. Hay que tener en cuenta que demasiado grano en la dieta reduce la masticación (rumia) y reduce el porcentaje de grasa en leche.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Harina de gluten de maíz.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Subproductos de cervecería y destilería.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Racimos y tubérculos.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Salvados  de granos.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Semillas de leguminosas.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Proteínas de origen animal.</li></ul><p class='textoDetalle'><b>¿Cuál es la importancia de los minerales?</b></p><p class='textoDetalle'>Las deficiencias de minerales afectan la fisiología de crecimiento, reproducción y producción del animal.</p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Calcio: importante en los primeros días de lactancia, puede producir su deficiencia fiebre de leche.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Fosforo: sirve para mantener una buena fertilidad en el hato.</li></ul>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/13Uqgjf'>http://bit.ly/13Uqgjf</a></li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/WGoDmM'>http://bit.ly/WGoDmM (video)</a></li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Albarracín. L; Londoño. C.; (2012). Elaboración de Bloques nutricionales. Tibaitata (Cundinamarca): Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hazard, S.; Alimentación de vacas lecheras. INIA. Carillanca. 52-60.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hinestroza, A. Martinez, J. (1994).  Los bloques multinutricionales su elaboración y consumo en ganado bovino. Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Howard ,W; Terry, Y;  Wattiaux, A. M. Alimentos para vacas lecheras. Instituto Badcock para la investigación y desarrollo internacional de la industria lechera. Universidad de Wisconsin—Madison. pp 21-24.</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 11,
                    Nombre = "Forraje conservado: henificación",
                    Resumen = "Para suplir las necesidades de forraje durante las épocas de sequía o de baja producción, se recomienda realizar su conservación aprovechando los excedentes que se generan en época de sequía, logrando así  mantener la producción de leche constante durante todo el año.",
                    Explicacion = "<p class='textoDetalle'><b>Beneficios de la conservación de forrajes</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Disminuye los efectos negativos del pastoreo y sobrepastoreo en la degradación de los recursos naturales, suelo y agua.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Proporciona forraje de buena calidad durante todo el año, especialmente durante la época de sequias.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Aprovechar los excedentes de forraje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Incrementar la carga animal de la pradera.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejorar el balance de la dieta y los niveles de producción del ganado.</li></ul><p class='textoDetalle'><b>Formas de conservación de forraje</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Ensilaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Henolaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Heno.</li></ul><p class='textoDetalle'><b>Qué es el Heno ó Henificación?</b></p><p class='textoDetalle'>Consiste en el secado rápido de los forrajes verdes al sol o por medio de calentadores, hasta un contenido de humedad de 15% o menos, así se logra que el alimento conserve el valor nutritivo similar al forraje verde.</p><p class='textoDetalle'><b>¿Qué es el Heno ó Henificación?</b></p><p class='textoDetalle'>Las principales características que  afectan la calidad del heno son:</p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El estado de desarrollo de la planta al momento de la cosecha.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>La edad de la planta.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El contenido proporcional de las hojas.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El sistema de curado.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El deterioro causado por el tiempo y el manipuleo.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>La forma física en la cual se suministra a los animales.</li></ul><p class='textoDetalle'><b>Ventajas Del Heno</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Su conservación en el tiempo demanda bajos insumos.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>En la mayoría de los casos puede proveer los nutrientes necesarios.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Se adapta bien a la mayoría de los sistemas de producción.</li></ul><p class='textoDetalle'><b>¿Cómo producir heno?</b></p><p class='textoDetalle'><b>¿Cómo Almacenar?</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Importante tener un terreno elevado.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Sin árboles.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Formar hileras.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Evitar el contacto con el suelo y mantenerle una cobertura.</li></ul>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/13Uqgjf'>http://bit.ly/13Uqgjf</a></li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/WGoDmM'>http://bit.ly/WGoDmM</a> (video)</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Albarracín. L; Londoño. C.; (2012). Elaboración de Bloques nutricionales. Tibaitata (Cundinamarca): Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hazard, S.; Alimentación de vacas lecheras. INIA. Carillanca. 52-60.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hinestroza, A. Martinez, J. (1994).  Los bloques multinutricionales su elaboración y consumo en ganado bovino. Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Howard ,W; Terry, Y;  Wattiaux, A. M. Alimentos para vacas lecheras. Instituto Badcock para la investigación y desarrollo internacional de la industria lechera. Universidad de Wisconsin—Madison. pp 21-24.</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 12,
                    Nombre = "Forraje conservado: henolaje",
                    Resumen = "Para suplir las necesidades de forraje durante las épocas de sequía o de baja producción, se recomienda realizar su conservación aprovechando los excedentes que se generan en época de sequía, logrando así  mantener la producción de leche constante durante todo el año.",
                    Explicacion = "<p class='textoDetalle'><b>Beneficios de la conservación de forrajes</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Disminuye los efectos negativos del pastoreo y sobrepastoreo en la degradación de los recursos naturales, suelo y agua.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Proporciona forraje de buena calidad durante todo el año, especialmente durante la época de sequias.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Aprovechar los excedentes de forraje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Incrementar la carga animal de la pradera.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejorar el balance de la dieta y los niveles de producción del ganado.</li></ul><p class='textoDetalle'><b>Formas de conservación de forraje</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Ensilaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Henolaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Heno.</li></ul><p class='textoDetalle'><b>¿Qué Es El Henolaje o silopack?</b></p><p class='textoDetalle'>El henolaje  es un proceso intermedio entre el ensilaje y la henificación, en el que el forraje se conserva con una humedad del 45 al 55%, en ausencia de oxígeno.</p><p class='textoDetalle'><b>Ventajas del henolaje:</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Un menor riesgo climático debido  a su empaque.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Y una menor perdida de material, es decir se aprovecha mucho mejor,  ya que no se pica la hoja.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Retiene la mayor parte de los nutrientes del forraje verde.</li></ul><p class='textoDetalle'><b>Desventajas del henolaje</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mayor costo de producción por el  tipo de maquinaria q se necesita.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Tiempo inferior de conservación en relación al  ensilaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Se realiza un corte  del material.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Se forma hileras con el material cortado.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Se hace un pre-oreo  para disminuir la cantidad de  humedad en el forraje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Se empaqueta 24 horas después se forra con plástico.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El henolaje viene  en forma de rollos húmedos.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Cuidar de no romper la envoltura en la que se está empacando (humano, ganado u otros animales).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Manejar buenos drenajes.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>El tiempo de duración de  este material varía entre 10 a 12 meses aprox.</li></ul>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hazard, S.; Alimentación de vacas lecheras. INIA. Carillanca. 52-60.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hinestroza, A. Martinez, J. (1994).  Los bloques multinutricionales su elaboración y consumo en ganado bovino. Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Howard ,W; Terry, Y;  Wattiaux, A. M. Alimentos para vacas lecheras. Instituto Badcock para la investigación y desarrollo internacional de la industria lechera. Universidad de Wisconsin—Madison. pp 21-24.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://goo.gl/4SyNF'>http://goo.gl/4SyNF</a> (video)</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 13,
                    Nombre = "Forraje conservado: ensilaje",
                    Resumen = "Para suplir las necesidades de forraje durante las épocas de sequía o de baja producción, se recomienda realizar su conservación aprovechando los excedentes que se generan en época de sequía, logrando así  mantener la producción de leche constante durante todo el año.",
                    Explicacion = "<p class='textoDetalle'><b>Beneficios de la conservación de forrajes</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Disminuye los efectos negativos del pastoreo y sobrepastoreo en la degradación de los recursos naturales, suelo y agua.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Proporciona forraje de buena calidad durante todo el año, especialmente durante la época de sequias.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Aprovechar los excedentes de forraje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Incrementar la carga animal de la pradera.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejorar el balance de la dieta y los niveles de producción del ganado.</li></ul><p class='textoDetalle'><b>Formas de conservación de forraje</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Ensilaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Henolaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Heno.</li></ul><p class='textoDetalle'><b>¿Qué es el ensilaje?</b></p><p class='textoDetalle'>Es un proceso de conservación de pastos y forrajes, basado en una fermentación anaeróbica (sin aire) de la masa forrajera, que permite mantener durante periodos prolongados de tiempo, la calidad que tenía el forraje en el momento de corte.</p><p class='textoDetalle'><b>¿Cómo Ensilar?</b></p> <ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Cortar el forraje a ensilar.</li> <li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Recoger el material.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Picar del forraje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Preparar agua-melaza para el proceso de fermentación.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Utilizar bolsas negras calibre 8, colocar una capa de  forraje  picado y una capa de agua-melaza rociada y así sucesivamente; no olvidar compactar bien el material para  evitar presencia de oxigeno en las bolsas y que se dañe el ensilaje.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Almacenar (mientras se encuentre  cerrado  el producto se puede conserva por mucho tiempo)</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Suministrar a las vacas.</li></ul>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/13Uqgjf'>http://bit.ly/13Uqgjf</a></li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hazard, S.; Alimentación de vacas lecheras. INIA. Carillanca. 52-60.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hinestroza, A. Martinez, J. (1994).  Los bloques multinutricionales su elaboración y consumo en ganado bovino. Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Howard ,W; Terry, Y;  Wattiaux, A. M. Alimentos para vacas lecheras. Instituto Badcock para la investigación y desarrollo internacional de la industria lechera. Universidad de Wisconsin—Madison. pp 21-24.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://goo.gl/cJjLb'>http://goo.gl/cJjLb</a> (video)</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://goo.gl/ptXLy'>http://goo.gl/ptXLy</a> (video)</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://goo.gl/IBc61'>http://goo.gl/IBc61</a> (video)</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://goo.gl/bTfKb'>http://goo.gl/bTfKb</a> (video)</li></ul>"
                });

                contexto.Opciones.Add(new Opciones
                {
                    OpcionId = 14,
                    Nombre = "Bloques multinutricionales",
                    Resumen = "El manejo alimenticio de las vacas lecheras es uno de los factores de mayor incidencia y relevancia en la producción. Para realizar correctamente dicha labor, se recomienda que esta sea con base en los requerimientos nutritivos, de acuerdo al peso vivo, nivel de producción y momento de lactancia en que se encuentran los animales.",



                    Explicacion = "<p class='textoDetalle'><b>¿Qué es un bloque multinutricional?</b></p><p class='textoDetalle'>Un Bloque Multinutricional es un suplemento alimenticio, de alta palatabilidad, en forma sólida, que facilita el suministro de diversas sustancias nutritivas en forma lenta. Además de incorporar Nitrógeno No Proteico (NNP),  que está en la urea o excretas, incorpora otros elementos nutricionales como carbohidratos solubles (azúcares solubles y almidones, principalmente), minerales (macro y micro) y proteína verdadera (aminoácidos).</p><p class='textoDetalle'>Es una técnica de fácil adopción local, de bajo costo, sin desperdicios, con ventajas comparativas sobre el uso de suplementos comerciales; mejora parámetros Zootécnicos en cualquier rumiante que posea la finca, como Bovinos, Ovinos, Caprinos, etc.</p><p class='textoDetalle'><b>Beneficios de los bloques multi nutricionales.</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejora la producción de leche por vaca (10 – 25%) y grasa en leche (0,3 – 0,5%).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Permiten un mejor aprovechamiento de los forrajes de baja calidad y de los residuos fibrosos.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Favorece la actividad de los microorganismos ruminales, permitiendo un aprovechamiento más eficiente de los forrajes de baja calidad.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mantiene la condición corporal y mejora parámetros reproductivos.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejora la ganancia de peso en animales consumiendo pastos tropicales de baja proteína. (Aumento de peso hasta 150 gramos/animal/día).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Reduce el consumo de sal mineralizada en un 25% aproximadamente, por su contenido de minerales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejorar el ecosistema ruminal, estimulando la fermentación e incrementando el consumo y aprovechamiento de forrajes tropicales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Incrementa la degradación y digestión de la fibra; disminuye la degradación de proteína verdadera que entra en el rumen, lo que incrementa la productividad del animal.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Incrementa la degradación y digestión de la fibra; disminuye la degradación de proteína verdadera que entra en el rumen, lo que incrementa la productividad del animal.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejora la ganancia de peso en animales consumiendo pastos tropicales de baja proteína. (Aumento de peso hasta 150gramos/animal/día).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Reduce el consumo de sal mineralizada en un 25% aproximadamente, por su contenido de minerales.</li></ul><p class='textoDetalle'><b>Posibles limitantes de los bloques multinutricionales</b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Costos de los materiales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mala homogenización de los materiales a usar.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Porcentajes de los materiales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Una limitante importante para la implementación de los Bloques Multinutricionales es que los forrajes o pasturas consumidas por los semovientes, no superen el 12% de proteína, para así no tener problemas de intoxicaciones ni timpanismos.</li></ul><p class='textoDetalle'><b>Elaboración de bloques  multinutricionales</b></p><p class='textoDetalle'>Para la preparación de los bloques en forma artesanal se debe tener un sitio, que disponga como mínimo de 3 áreas: un área de almacenamiento de materias primas, una de elaboración o producción y otra para el almacenamiento de los bloques. También se debe utilizar algunos elementos, implementos y herramientas que se deben disponer al momento de elaborarlos: láminas de plástico, balanza de reloj o bascula, baldes plásticos para el pesaje de los materiales y para el moldeo, canecas plásticas grandes, palas, pisón de madera, papel periódico, guantes, tapabocas.</p><p class='textoDetalle'><b>PASO 1</b></p><p class='textoDetalle'>En un recipiente o caneca plástica se realiza la primera mezcla entre la fuente de NNP en forma de Urea, bien sea molida o pulverizada y melaza como fuente de energía.</p><p class='textoDetalle'>Especialmente se debe empezar siempre con la melaza. Como se requiere una distribución uniforme de estos ingredientes se debe realizar una completa homogenización. En caso de no poder pulverizar la urea, se debe hacer la mezcla con anterioridad hasta diluirla completamente.</p><p class='textoDetalle'><b>PASO 2</b></p><p class='textoDetalle'>La segunda mezcla la conforman los demás ingredientes, (harina de arroz, torta de soya, sal mineralizada).</p><p class='textoDetalle'>Con una pala se revuelve vigorosamente hasta homogenizar completamente la mezcla. Se continúa agregando la cal agrícola o el aglutinador (cal apagada, cal viva, yeso etc.) y por último y sin detener el mezclado se adicionan las fibras cortas o largas (heno, residuos agrícolas fibrosos RAF), hasta lograr la contextura deseada.</p><p class='textoDetalle'>La contextura apropiada se logra cuando al tomar una muestra de la mezcla con la mano, cerrando fuertemente el puño, no sale líquido entre los dedos y al abrir la mano queda formada una masa que no se expande.</p><p class='textoDetalle'>Al terminar el proceso, se deposita la mezcla en moldes de material plástico, madera o metal, previamente recubiertos con una tela plástica o papel grueso para evitar que el bloque quede adherido a la pared del recipiente.</p><p class='textoDetalle'><b>Beneficios </b></p><ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejorar el ecosistema ruminal, estimulando la fermentación e incrementando el consumo y aprovechamiento de forrajes tropicales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Incrementa la degradación y digestión de la fibra; disminuye la degradación de proteína verdadera que entra en el rumen, lo que incrementa la productividad del animal.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Incrementa la degradación y digestión de la fibra; disminuye la degradación de proteína verdadera que entra en el rumen, lo que incrementa la productividad del animal.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Mejora la ganancia de peso en animales consumiendo pastos tropicales de baja proteína. (Aumento de peso hasta 150gramos/animal/día).</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Reduce el consumo de sal mineralizada en un 25% aproximadamente, por su contenido de minerales.</li></ul><p class='textoDetalle'><b>Materiales empleados</b></p> <ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Láminas de plástico.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Balanza de reloj o báscula.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Baldes plásticos para el pesaje de los materiales y moldeo de los bloques.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Canecas plásticas grandes para la mezcla de los materiales.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Pala.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Pisón de madera.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Papel periódico.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Guantes.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Tapabocas.</li></ul><p class='textoDetalle'><b>Producción</b></p><p class='textoDetalle'>Mantiene la producción de leche en época de sequía.</p>",
                    InformacionAdicional = "<ul class='list-unstyled' style='float: left'><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Albarracín. L; Londoño. C.; (2012). Elaboración de Bloques nutricionales. Tibaitata (Cundinamarca): Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hazard, S.; Alimentación de vacas lecheras. INIA. Carillanca. 52-60.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Hinestroza, A. Martinez, J. (1994).  Los bloques multinutricionales su elaboración y consumo en ganado bovino. Corpoica.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i>Howard ,W; Terry, Y;  Wattiaux, A. M. Alimentos para vacas lecheras. Instituto Badcock para la investigación y desarrollo internacional de la industria lechera. Universidad de Wisconsin—Madison. pp 21-24.</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/WRXF9D'>http://bit.ly/WRXF9D</a> (ppt)</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/1057hlG'>http://bit.ly/1057hlG</a> (video)</li><li><i class='fa fa-caret-square-o-down' style='color: orange'></i><a target='_blank' href='http://bit.ly/YYHiV3'>http://bit.ly/YYHiV3</a> (video)</li></ul>"
                });

                contexto.SaveChanges();

                //Acciones - Opciones

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 1,
                    AccionId = 1,
                    OpcionId = 1
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 2,
                    AccionId = 1,
                    OpcionId = 2
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 3,
                    AccionId = 1,
                    OpcionId = 3
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 4,
                    AccionId = 1,
                    OpcionId = 4
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 5,
                    AccionId = 5,
                    OpcionId = 9
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 6,
                    AccionId = 5,
                    OpcionId = 10
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 7,
                    AccionId = 5,
                    OpcionId = 11
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 8,
                    AccionId = 5,
                    OpcionId = 12
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 9,
                    AccionId = 5,
                    OpcionId = 13
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 10,
                    AccionId = 5,
                    OpcionId = 14
                });

                contexto.AccionesOpciones.Add(new AccionesOpciones
                {
                    AccionOpcionId = 1,
                    AccionId = 6,
                    OpcionId = 6
                });

                contexto.SaveChanges();

                //  contexto.Capas.Add(new Capas
                //  {
                //      CapaId = 1,
                //      NombreCaracterizacion = "",
                //      IdentificadorCaracterizacion = "",
                //      Concepto = "",
                //      RutaImagen =""
                //});
                contexto.Capas.Add(new Capas
                {
                    CapaId = 1,
                    NombreCaracterizacion = "Subzonas",
                    IdentificadorCaracterizacion = "subzonas",
                    Concepto = "Las subzonas hidrográficas conforman la unidad de análisis del departamento del Atlántico.",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 2,
                    NombreCaracterizacion = "Estaciones",
                    IdentificadorCaracterizacion = "estaciones",
                    Concepto = "Una estación climática se compone de sensores que permiten medir los diferentes elementos climáticos como la lluvia, temperatura, humedad del aire, vientos, radiación solar, entre otros.",
                    RutaImagen = "../Content/imagenes/estacion1.png"
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 3,
                    NombreCaracterizacion = " Precipitación",
                    IdentificadorCaracterizacion = "pre-multianual",
                    Concepto = "La precipitación pluvial o lluvia se mide en milímetros (mm) que equivalen a litros de lluvia registrada en un metro cuadrado de superficie.",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 4,
                    NombreCaracterizacion = "Conglomerados",
                    IdentificadorCaracterizacion = "conglomerados",
                    Concepto = "Los conglomerados son zonas o partes del territorio en donde la distribución y cantidad de lluvias es similar en el año y en escala multianual.",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 5,
                    NombreCaracterizacion = "Temperatura multianual",
                    IdentificadorCaracterizacion = "temp-multianual",
                    Concepto = "La temperatura es una medida del calor o energía térmica de las partículas en el aire y se debe en gran medida al calor emanado desde el suelo, el cual es generado por la radiación solar directa que cae sobre este.",
                    RutaImagen = "../Content/imagenes/temperatura1.png"
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 6,
                    NombreCaracterizacion = "Brillo solar",
                    IdentificadorCaracterizacion = "brillo",
                    Concepto = "El brillo solar es el tiempo total durante el cual incide luz solar directa sobre el territorio, entre el amanecer y el atardecer.",
                    RutaImagen = "../Content/imagenes/brillo1.png"
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 7,
                    NombreCaracterizacion = "Evapotranspiración",
                    IdentificadorCaracterizacion = "evapotranspiracion",
                    Concepto = "La evapotranspiración representa la unión entre la evaporación de agua desde el suelo y la transpiración por parte de la vegetación.",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 8,
                    NombreCaracterizacion = "Humedad relativa",
                    IdentificadorCaracterizacion = "humedad",
                    Concepto = "La humedad relativa hace referencia a la cantidad de vapor de agua presente en la atmósfera respecto de la cantidad total que puede contener. Esta cantidad depende de la temperatura del aire.",
                    RutaImagen = "../Content/imagenes/humedad1.png"
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 9,
                    NombreCaracterizacion = "Variabilidad interanual: Precipitación",
                    IdentificadorCaracterizacion = "anomalia-p",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 10,
                    NombreCaracterizacion = "Variabilidad interanual: Temperatura",
                    IdentificadorCaracterizacion = "anomalia-t",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 11,
                    NombreCaracterizacion = "Riesgo agroclimático: Frecuencia e excesos y déficit",
                    IdentificadorCaracterizacion = "frecuencia",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 12,
                    NombreCaracterizacion = "Riesgo agroclimático: Susceptibilidad a inundaciones",
                    IdentificadorCaracterizacion = "susceptibilidad",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 13,
                    NombreCaracterizacion = "Clima",
                    IdentificadorCaracterizacion = "clima",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 14,
                    NombreCaracterizacion = "Tiempo",
                    IdentificadorCaracterizacion = "tiempo",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 15,
                    NombreCaracterizacion = "Condiciones secas",
                    IdentificadorCaracterizacion = "nvdi",
                    Concepto = "El mapa de condiciones secas se fundamenta en el NDVI, índice de vegetación de amplio uso,  e indicador empleado para analizar territorialmente el comportamiento de condiciones secas.",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 16,
                    NombreCaracterizacion = "Susceptibilidad a inundaciones",
                    IdentificadorCaracterizacion = "inundacion",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 17,
                    NombreCaracterizacion = "Variabilidad interanual: Variabilidad",
                    IdentificadorCaracterizacion = "variabilidad",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 18,
                    NombreCaracterizacion = "Niño y Niña",
                    IdentificadorCaracterizacion = "niño_niña",
                    Concepto = "",
                    RutaImagen = ""
                });

                contexto.Capas.Add(new Capas
                {
                    CapaId = 19,
                    NombreCaracterizacion = "Estaciones",
                    IdentificadorCaracterizacion = "estaciones_mpio",
                    Concepto = "",
                    RutaImagen = ""
                });
                //
                contexto.Capas.Add(new Capas
                {
                    CapaId = 20,
                    NombreCaracterizacion = "Aptitud agroclimática",
                    IdentificadorCaracterizacion = "AptitudAgroclimatica",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 21,
                    NombreCaracterizacion = "Escenarios agroclimáticos",
                    IdentificadorCaracterizacion = "Escenarios",
                    Concepto = "",
                    RutaImagen = ""
                });

                contexto.Capas.Add(new Capas
                {
                    CapaId = 22,
                    NombreCaracterizacion = "Análisis Condiciones secas municipio",
                    IdentificadorCaracterizacion = "nvdi_mcipio",
                    Concepto = "",
                    RutaImagen = ""
                });
                contexto.Capas.Add(new Capas
                {
                    CapaId = 23,
                    NombreCaracterizacion = "Susceptibilidad a inundaciones municipio",
                    IdentificadorCaracterizacion = "inundacion_mcipio",
                    Concepto = "",
                    RutaImagen = ""
                }); 


                contexto.SaveChanges();

                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 1,
                    CapaId = 1,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 2,
                    CapaId = 2,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 3,
                    CapaId = 3,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 4,
                    CapaId = 4,
                    DepartamentoId = 1,
                    ExplicacionMapa = "La información en el mapa permite conocer la distribución y cantidad mensual de lluvia en cada conglomerado."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 5,
                    CapaId = 5,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 6,
                    CapaId = 6,
                    DepartamentoId = 1,
                    ExplicacionMapa = "Muestra la distribución del brillo solar en el territorio por departamento."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 7,
                    CapaId = 7,
                    DepartamentoId = 1,
                    ExplicacionMapa = "El mapa muestra los valores de ETO en el territorio."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 8,
                    CapaId = 8,
                    DepartamentoId = 1,
                    ExplicacionMapa = "El mapa muestra la distribución de la humedad relativa en el territorio."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 9,
                    CapaId = 9,
                    DepartamentoId = 1,
                    ExplicacionMapa = "El mapa muestra la distribución de los promedios anuales de lluvia en el territorio."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 10,
                    CapaId = 10,
                    DepartamentoId = 1,
                    ExplicacionMapa = "El mapa de frecuencia indica cual es la condición histórica de humedad del suelo (exceso o deficiencia de agua) que más se presenta en una determinada región."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 11,
                    CapaId = 11,
                    DepartamentoId = 1,
                    ExplicacionMapa = "El mapa de frecuencia indica cual es la condición histórica de humedad del suelo (exceso o deficiencia de agua) que más se presenta en una determinada región."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 12,
                    CapaId = 12,
                    DepartamentoId = 1,
                    ExplicacionMapa = "El mapa muestra las zonas que debido a sus características de paisaje son susceptibles a recibir aportes de aguas, en épocas de abundantes lluvias, provenientes principalmente por el aumento de los caudales de los ríos que la atraviesan."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 13,
                    CapaId = 13,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 14,
                    CapaId = 14,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 15,
                    CapaId = 1,
                    DepartamentoId = 2,
                    ExplicacionMapa = "Texto Explicacion subzonas norte santander"
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 16,
                    CapaId = 2,
                    DepartamentoId = 2,
                    ExplicacionMapa = "Texto Explicacion 2 norte santander"
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 17,
                    CapaId = 3,
                    DepartamentoId = 2,
                    ExplicacionMapa = "Texto Explicacion 3  norte santander"
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 18,
                    CapaId = 4,
                    DepartamentoId = 2,
                    ExplicacionMapa = "La información en el mapa permite conocer la distribución y cantidad mensual de lluvia en cada conglomerado departamento Norte Santender"
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 19,
                    CapaId = 5,
                    DepartamentoId = 2,
                    ExplicacionMapa = "Texto Explicacion subzonas norte santander"
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 20,
                    CapaId = 6,
                    DepartamentoId = 2,
                    ExplicacionMapa = "Muestra la distribución del brillo solar en el territorio para departamento Norte Santender"
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 21,
                    CapaId = 7,
                    DepartamentoId = 2,
                    ExplicacionMapa = "El mapa muestra los valores de ETO en el territorio."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 22,
                    CapaId = 8,
                    DepartamentoId = 2,
                    ExplicacionMapa = "El mapa muestra la distribución de la humedad relativa en el territorio."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 23,
                    CapaId = 9,
                    DepartamentoId = 2,
                    ExplicacionMapa = "El mapa muestra la distribución de los promedios anuales de lluvia en el territorio."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 24,
                    CapaId = 10,
                    DepartamentoId = 2,
                    ExplicacionMapa = "El mapa de frecuencia indica cual es la condición histórica de humedad del suelo (exceso o deficiencia de agua) que más se presenta en una determinada región."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 25,
                    CapaId = 11,
                    DepartamentoId = 2,
                    ExplicacionMapa = "El mapa de frecuencia indica cual es la condición histórica de humedad del suelo (exceso o deficiencia de agua) que más se presenta en una determinada región."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 26,
                    CapaId = 12,
                    DepartamentoId = 2,
                    ExplicacionMapa = "El mapa muestra las zonas que debido a sus características de paisaje son susceptibles a recibir aportes de aguas, en épocas de abundantes lluvias, provenientes principalmente por el aumento de los caudales de los ríos que la atraviesan."
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 27,
                    CapaId = 13,
                    DepartamentoId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 28,
                    CapaId = 14,
                    DepartamentoId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 29,
                    CapaId = 17,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 30,
                    CapaId = 17,
                    DepartamentoId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 31,
                    CapaId = 18,
                    DepartamentoId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasDepartamentos.Add(new CapasDepartamentos
                {
                    CapaDepartamentoId = 32,
                    CapaId = 18,
                    DepartamentoId = 2,
                    ExplicacionMapa = ""
                });




                contexto.SaveChanges();

                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 1,
                    CapaId = 15,
                    MunicipioId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 2,
                    CapaId = 16,
                    MunicipioId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 3,
                    CapaId = 15,
                    MunicipioId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 4,
                    CapaId = 16,
                    MunicipioId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 5,
                    CapaId = 15,
                    MunicipioId = 3,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 6,
                    CapaId = 16,
                    MunicipioId = 3,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 7,
                    CapaId = 15,
                    MunicipioId = 4,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 8,
                    CapaId = 16,
                    MunicipioId = 4,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 9,
                    CapaId = 15,
                    MunicipioId = 5,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 10,
                    CapaId = 16,
                    MunicipioId = 5,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 11,
                    CapaId = 15,
                    MunicipioId = 6,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 12,
                    CapaId = 16,
                    MunicipioId = 6,
                    ExplicacionMapa = ""
                });

                //capas municipio de estaciones, aptitud agroclimatica y escenarios agroclimaticos:


                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 13,
                    CapaId = 19,
                    MunicipioId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 14,
                    CapaId = 19,
                    MunicipioId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 15,
                    CapaId = 19,
                    MunicipioId = 3,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 16,
                    CapaId = 19,
                    MunicipioId = 4,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 17,
                    CapaId = 19,
                    MunicipioId = 5,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 18,
                    CapaId = 19,
                    MunicipioId = 6,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 19,
                    CapaId = 20,
                    MunicipioId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 20,
                    CapaId = 20,
                    MunicipioId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 21,
                    CapaId = 20,
                    MunicipioId = 3,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 22,
                    CapaId = 20,
                    MunicipioId = 4,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 23,
                    CapaId = 20,
                    MunicipioId = 5,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 24,
                    CapaId = 20,
                    MunicipioId = 6,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 25,
                    CapaId = 21,
                    MunicipioId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 26,
                    CapaId = 21,
                    MunicipioId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 27,
                    CapaId = 21,
                    MunicipioId = 3,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 28,
                    CapaId = 21,
                    MunicipioId = 4,
                    ExplicacionMapa = ""
                });
                // info capas de condiciones secas y susceptibilidad a inundaciones
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 29,
                    CapaId = 21,
                    MunicipioId = 5,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 30,
                    CapaId = 21,
                    MunicipioId = 6,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 31,
                    CapaId = 22,
                    MunicipioId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 32,
                    CapaId = 22,
                    MunicipioId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 33,
                    CapaId = 22,
                    MunicipioId = 3,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 34,
                    CapaId = 22,
                    MunicipioId = 4,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 35,
                    CapaId = 22,
                    MunicipioId = 5,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 36,
                    CapaId = 22,
                    MunicipioId = 6,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 37,
                    CapaId = 23,
                    MunicipioId = 1,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 38,
                    CapaId = 23,
                    MunicipioId = 2,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 39,
                    CapaId = 23,
                    MunicipioId = 3,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 40,
                    CapaId = 23,
                    MunicipioId = 4,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 41,
                    CapaId = 23,
                    MunicipioId = 5,
                    ExplicacionMapa = ""
                });
                contexto.CapasMunicipios.Add(new CapasMunicipios
                {
                    CapaMunicipioId = 42,
                    CapaId = 23,
                    MunicipioId = 6,
                    ExplicacionMapa = ""
                }); 




                contexto.SaveChanges();

                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 1,
                    NombreTipoOpcion = "Ninguna",
                    NombreOpcion = "Opcion Subzona",
                    NombreOpcionJScript = "",
                    CapaId = 1
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 2,
                    NombreTipoOpcion = "Ninguna",
                    NombreOpcion = "Opcion Estacion",
                    NombreOpcionJScript = "",
                    CapaId = 2
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 3,
                    NombreTipoOpcion = "Ninguna",
                    NombreOpcion = "Opcion precipitacion",
                    NombreOpcionJScript = "",
                    CapaId = 3
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 4,
                    NombreTipoOpcion = "Ninguna",
                    NombreOpcion = "Opcion conglomerados",
                    NombreOpcionJScript = "",
                    CapaId = 4
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 5,
                    NombreTipoOpcion = "",
                    //NombreCortoOpcion = "tmin_media_multianual",
                    NombreCortoOpcion ="temperatura-minima",
                    NombreOpcion = "Mínima",
                    NombreOpcionJScript = "cambiarCapa('tmin_media_multianual')",
                    CapaId = 5
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 6,
                    NombreTipoOpcion = "",
                    NombreCortoOpcion = "temperatura-media",
                    NombreOpcion = "Media",
                    NombreOpcionJScript = "cambiarCapa('tmedia_multianual')",
                    CapaId = 5
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 7,
                    NombreTipoOpcion = "",
                    NombreCortoOpcion = "temperatura-maxima",
                    NombreOpcion = "Máxima",
                    NombreOpcionJScript = "cambiarCapa('tmax_media_multianual')",
                    CapaId = 5
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 8,
                    NombreTipoOpcion = "Ninguna",
                    NombreOpcion = "Opcion brillo",
                    NombreCortoOpcion="brillo",
                    NombreOpcionJScript = "cambiarCapa(brillo)",
                    CapaId = 6
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 9,
                    NombreTipoOpcion = "Ninguna",
                    NombreOpcion = "Opcion evotranspiracion",
                    NombreCortoOpcion="evapotranspiracion",
                    NombreOpcionJScript = "cambiarCapa(evapotranspiracion)",
                    CapaId = 7
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 10,
                    NombreTipoOpcion = "Ninguna",
                    NombreOpcion = "Opcion Humedad Relativa",
                    NombreCortoOpcion="humedad_relativa",
                    NombreOpcionJScript = "cambiarCapa(humedad_relativa)",
                    CapaId = 8
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 11,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Niño",
                    NombreCortoOpcion = "anomalia-p-nino",
                    NombreOpcionJScript = "cambiarCapa('anomalia_nino')",
                    CapaId = 9
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 12,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Niña",
                    NombreCortoOpcion="anomalia-p-nina",
                    NombreOpcionJScript = "cambiarCapa('anomalia_nina')",
                    CapaId = 9
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 13,
                    NombreTipoOpcion = "Niña",
                    NombreOpcion = "Mínima",
                    NombreCortoOpcion = "anomalia-t-min-nina",
                    NombreOpcionJScript = "cambiarCapa('anomalia_tmin_nina')",
                    CapaId = 10
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 14,
                    NombreTipoOpcion = "Niña",
                    NombreOpcion = "Máxima",
                    NombreCortoOpcion = "anomalia-t-max-nina",
                    NombreOpcionJScript = "cambiarCapa('anomalia_tmax_nina')",
                    CapaId = 10
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 15,
                    NombreTipoOpcion = "Niño",
                    NombreOpcion = "Mínima",
                    NombreCortoOpcion = "anomalia-t-min-nino",
                    NombreOpcionJScript = "cambiarCapa('anomalia_tmin_nino')",
                    CapaId = 10
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 16,
                    NombreTipoOpcion = "Niño",
                    NombreOpcion = "Máxima",
                    NombreCortoOpcion = "anomalia-t-max-nino",
                    NombreOpcionJScript = "cambiarCapa('anomalia_tmax_nino')",
                    CapaId = 10
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 17,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Exceso",
                    NombreCortoOpcion="frecuencia-exceso",
                    NombreOpcionJScript = "cambiarCapa('exceso')",
                    CapaId = 11
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 18,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Déficit",
                    NombreCortoOpcion="frecuencia-deficit",
                    NombreOpcionJScript = "cambiarCapa('deficit')",
                    CapaId = 11
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 19,
                    NombreTipoOpcion = "Opciones",
                    NombreOpcion = "Susceptibilidad",
                    NombreCortoOpcion="susceptibilidad-inundacion",
                    NombreOpcionJScript = "cambiarCapa('inundacion_susceptibilidad')",
                    CapaId = 12
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 20,
                    NombreTipoOpcion = "Opciones",
                    NombreOpcion = "Inundación",
                    NombreCortoOpcion="susceptibilidad-igac",
                    NombreOpcionJScript = "cambiarCapa('inundacion_2010_2011_igac')",
                    CapaId = 12
                });

                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 21,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Opcion condiciones secas",
                    NombreOpcionJScript = "",
                    CapaId = 15
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 22,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Expansión",
                    NombreOpcionJScript = "cambiarCapa(3)",
                    CapaId = 16
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 23,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Contracción",
                    NombreOpcionJScript = "cambiarCapa(4)",
                    CapaId = 16
                });

                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 24,
                    NombreTipoOpcion = "",
                    NombreOpcion = "SPI",
                    NombreOpcionJScript = "cambiarCapa(4)",
                    CapaId = 19
                });

                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 25,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Probabilidad Ppt",
                    NombreOpcionJScript = "cambiarCapa(4)",
                    CapaId = 19
                });

                //opciones para capas de aptitud agroclimatica y escenarios agroclimaticos:
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 26,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Exceso",
                    NombreOpcionJScript = "",
                    CapaId = 20
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 27,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Normal",
                    NombreOpcionJScript = "",
                    CapaId = 20
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 28,
                    NombreTipoOpcion = "",
                    NombreOpcion = "Déficit",
                    NombreOpcionJScript = "",
                    CapaId = 20
                });

                //opciones escenarios
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 29,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Octubre",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_oct')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 30,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Noviembre",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_nov')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 31,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Diciembre",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_dic')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 32,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Enero",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_ene')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 33,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Febrero",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_feb')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 34,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Marzo",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_mar')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 35,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Abril",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_abr')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 36,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Mayo",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_may')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 37,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Junio",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_jun')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 38,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Julio",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_jul')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 39,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Agosto",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_ago')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 40,
                    NombreTipoOpcion = "Húmedo",
                    NombreOpcion = "Septiembre",
                    NombreOpcionJScript = "cambiarCapa('hum_tom_sep')",
                    CapaId = 21
                });

                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 41,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Octubre",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_oct')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 42,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Noviembre",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_nov')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 43,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Diciembre",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_dic')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 44,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Enero",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_ene')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 45,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Febrero",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_feb')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 46,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Marzo",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_mar')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 47,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Abril",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_abr')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 48,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Mayo",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_may')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 49,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Junio",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_jun')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 50,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Julio",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_jul')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 51,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Agosto",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_ago')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 52,
                    NombreTipoOpcion = "Normal",
                    NombreOpcion = "Septiembre",
                    NombreOpcionJScript = "cambiarCapa('nor_tom_sep')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 53,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Octubre",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_oct')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 54,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Noviembre",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_nov')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 55,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Diciembre",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_dic')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 56,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Enero",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_ene')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 57,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Febrero",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_feb')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 58,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Marzo",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_mar')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 59,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Abril",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_abr')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 60,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Mayo",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_may')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 61,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Junio",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_jun')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 62,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Julio",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_jul')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 63,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Agosto",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_ago')",
                    CapaId = 21
                });
                contexto.OpcionesVisualizacion.Add(new OpcionesVisualizacion
                {
                    OpcionVisualizacionId = 64,
                    NombreTipoOpcion = "Seco",
                    NombreOpcion = "Septiembre",
                    NombreOpcionJScript = "cambiarCapa('sec_tom_sep')",
                    CapaId = 21
                });





                contexto.SaveChanges();

                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 1,
                    NombreIndicador = "Directos al Bajo Magdalena",
                    Color = "rgba(230,201,99,1)",
                    OpcionVisualizacionId = 1,
                    ValorLayer = "Directos al Bajo Magdalena (mi)"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 2,
                    NombreIndicador = "Directos al Mar Caribe",
                    Color = "rgba(189,180,151,1)",
                    OpcionVisualizacionId = 1,
                    ValorLayer = "Arroyos Directos al Caribe"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 3,
                    NombreIndicador = "Bajo Magdalena - Canal del Dique",
                    Color = "rgba(224,215,48,1)",
                    OpcionVisualizacionId = 1,
                    ValorLayer = "Bajo Magdalena - Canal del Dique  2903 (md) - 2909 (mi)"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 4,
                    NombreIndicador = "Sinóptica principal",
                    Color = "rgb(0,128,0)",
                    OpcionVisualizacionId = 2,
                    ValorLayer = "SP"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 5,
                    NombreIndicador = "Climatológica principal",
                    Color = "rgb(255,255,0)",
                    OpcionVisualizacionId = 2,
                    ValorLayer = "CP"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 6,
                    NombreIndicador = " Climatológica ordinaria",
                    Color = "rgb(255,165,0)",
                    OpcionVisualizacionId = 2,
                    ValorLayer = "CO"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 7,
                    NombreIndicador = "Meteorológica especial",
                    Color = "rgb(255,0,0)",
                    OpcionVisualizacionId = 2,
                    ValorLayer = "ME"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 8,
                    NombreIndicador = " Pluviográfica",
                    Color = "rgb(0,0,255)",
                    OpcionVisualizacionId = 2,
                    ValorLayer = "PG"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 9,
                    NombreIndicador = "Pluviométrica",
                    Color = "rgb(128,128,128)",
                    OpcionVisualizacionId = 2,
                    ValorLayer = "PM"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 10,
                    NombreIndicador = " 700 - 900 mm",
                    Color = "rgba(245,122,122,1)",
                    OpcionVisualizacionId = 3,
                    ValorLayer = "700 - 900"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 11,
                    NombreIndicador = " 900 - 1100 mm",
                    Color = "rgba(255,190,190,1)",
                    OpcionVisualizacionId = 3,
                    ValorLayer = "900 - 1100"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 12,
                    NombreIndicador = "1100 - 1300 mm",
                    Color = "rgba(230,76,0,1)",
                    OpcionVisualizacionId = 3,
                    ValorLayer = "1100 - 1300"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 13,
                    NombreIndicador = "1300 - 1500 mm",
                    Color = "rgba(230,152,0,1)",
                    OpcionVisualizacionId = 3,
                    ValorLayer = "1300 - 1500"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 14,
                    NombreIndicador = "1500 - 1750 mm",
                    Color = "rgba(255,211,127,1)",
                    OpcionVisualizacionId = 3,
                    ValorLayer = "1500 - 1750"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 15,
                    NombreIndicador = "Conglomerado 1",
                    Color = "rgba(79,129,189,1)",
                    OpcionVisualizacionId = 4,
                    ValorLayer = "1"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 16,
                    NombreIndicador = "Conglomerado 2",
                    Color = "rgba(230,0,0,1)",
                    OpcionVisualizacionId = 4,
                    ValorLayer = "2"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 17,
                    NombreIndicador = "Conglomerado 3",
                    Color = "rgba(76,230,0,1)",
                    OpcionVisualizacionId = 4,
                    ValorLayer = "3"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 18,
                    NombreIndicador = "22 - 24 ºC",
                    Color = "rgba(255,170,0,1)",
                    OpcionVisualizacionId = 5,
                    ValorLayer = "22 - 24"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 19,
                    NombreIndicador = "> 24 ºC",
                    Color = "rgba(255,0,0,1)",
                    OpcionVisualizacionId = 5,
                    ValorLayer = "> 24"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 20,
                    NombreIndicador = "26 - 28 ºC",
                    Color = "rgba(205,102,102,1)",
                    OpcionVisualizacionId = 6,
                    ValorLayer = "26 - 28"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 21,
                    NombreIndicador = "28 - 30 ºC",
                    Color = "rgba(230,0,0,1)",
                    OpcionVisualizacionId = 6,
                    ValorLayer = "28 - 30"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 22,
                    NombreIndicador = "30 - 32 ºC",
                    Color = "rgba(255,170,0,1)",
                    OpcionVisualizacionId = 7,
                    ValorLayer = "30 - 32"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 23,
                    NombreIndicador = "32 - 34 ºC",
                    Color = "rgba(205,102,102,1)",
                    OpcionVisualizacionId = 7,
                    ValorLayer = "32 - 34"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 24,
                    NombreIndicador = " > 34 ºC",
                    Color = "rgba(230,0,0,1)",
                    OpcionVisualizacionId = 7,
                    ValorLayer = "> 34"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 25,
                    NombreIndicador = "1900 - 2100",
                    Color = " rgba(217,255,102,1)",
                    OpcionVisualizacionId = 8,
                    ValorLayer = "1900 - 2100"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 26,
                    NombreIndicador = " 2100 - 2300",
                    Color = "rgba(255,255,0,1)",
                    OpcionVisualizacionId = 8,
                    ValorLayer = "2100 - 2300"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 27,
                    NombreIndicador = "2300 - 2500",
                    Color = "rgba(255,128,0,1)",
                    OpcionVisualizacionId = 8,
                    ValorLayer = "2300 - 2500"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 28,
                    NombreIndicador = " 2500 - 2700",
                    Color = " rgba(230,76,0,1)",
                    OpcionVisualizacionId = 8,
                    ValorLayer = "2500 - 2700"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 29,
                    NombreIndicador = "1200 - 1400",
                    Color = "rgba(179,214,156,1)",
                    OpcionVisualizacionId = 9,
                    ValorLayer = "1200 - 1400"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 30,
                    NombreIndicador = "1400 - 1600",
                    Color = "rgba(255,255,0,1)",
                    OpcionVisualizacionId = 9,
                    ValorLayer = "1400 - 1600"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 31,
                    NombreIndicador = "1600 - 1800",
                    Color = "rgba(255,170,0,1)",
                    OpcionVisualizacionId = 9,
                    ValorLayer = "1600 - 1800"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 32,
                    NombreIndicador = " 75% - 80%",
                    Color = "rgb(255,255,0)",
                    OpcionVisualizacionId = 10,
                    ValorLayer = "75% - 80%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 33,
                    NombreIndicador = " 80% - 85%",
                    Color = "rgb(0,128,0)",
                    OpcionVisualizacionId = 10,
                    ValorLayer = "80% - 85%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 34,
                    NombreIndicador = "-60% - -40%",
                    Color = "rgba(255,170,0,1)",
                    OpcionVisualizacionId = 11,
                    ValorLayer = "-60% - -40%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 35,
                    NombreIndicador = "-40% - -20%",
                    Color = "rgba(255,211,127,1)",
                    OpcionVisualizacionId = 11,
                    ValorLayer = "-40% - -20%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 36,
                    NombreIndicador = "-20% - 0%",
                    Color = "rgba(255,235,175,1)",
                    OpcionVisualizacionId = 11,
                    ValorLayer = "-20% - 0"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 37,
                    NombreIndicador = "0% - 20%",
                    Color = "rgb(190,255,232)",
                    OpcionVisualizacionId = 12,
                    ValorLayer = "0% - 20%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 38,
                    NombreIndicador = "20% - 40%",
                    Color = "rgb(115,255,223)",
                    OpcionVisualizacionId = 12,
                    ValorLayer = "20% - 40%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 39,
                    NombreIndicador = "40% - 60%",
                    Color = " rgba(0,197,255,1)",
                    OpcionVisualizacionId = 12,
                    ValorLayer = "40% - 60%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 40,
                    NombreIndicador = "60% - 80%",
                    Color = "rgba(0,132,168,1)",
                    OpcionVisualizacionId = 12,
                    ValorLayer = "60% - 80%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 41,
                    NombreIndicador = "80% - 100%",
                    Color = "rgba(0,76,168,1)",
                    OpcionVisualizacionId = 12,
                    ValorLayer = "80% - 100%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 42,
                    NombreIndicador = "> 100%",
                    Color = "rgba(0,38,115,1)",
                    OpcionVisualizacionId = 12,
                    ValorLayer = "> 100%"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 43,
                    NombreIndicador = "-1 °C a -0,5 °C",
                    Color = "rgba(0,230,168,1)",
                    OpcionVisualizacionId = 13,
                    ValorLayer = "-1 - -0,5"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 44,
                    NombreIndicador = " -0,5 °C a -0,25 °C",
                    Color = " rgba(115,255,222,1)",
                    OpcionVisualizacionId = 13,
                    ValorLayer = "-0,5 - -0,25"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 45,
                    NombreIndicador = " -0,25 °C a 0 °C",
                    Color = "rgba(191,255,233,1)",
                    OpcionVisualizacionId = 13,
                    ValorLayer = "-0,25 - 0"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 46,
                    NombreIndicador = "0 °C a 0,25°C",
                    Color = "rgba(234,255,191,1)",
                    OpcionVisualizacionId = 13,
                    ValorLayer = "0 - 0,25"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 47,
                    NombreIndicador = "-1 °C a -0,5 °C",
                    Color = "rgba(0,230,168,1)",
                    OpcionVisualizacionId = 14,
                    ValorLayer = "-1,0 - -0,5"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 48,
                    NombreIndicador = "-0,5 °C a -0,25 °C",
                    Color = "rgba(115,255,222,1)",
                    OpcionVisualizacionId = 14,
                    ValorLayer = "-0,5 - -0,25"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 49,
                    NombreIndicador = " 0,25 °C a 0,5°C",
                    Color = "rgba(255,235,176,1)",
                    OpcionVisualizacionId = 15,
                    ValorLayer = "0,25 - 0,5"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 50,
                    NombreIndicador = " 0,5 °C a 1 °C",
                    Color = "rgba(255,210,128,1)",
                    OpcionVisualizacionId = 15,
                    ValorLayer = "0,5 - 1,0"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 51,
                    NombreIndicador = "  0,5 °C a 1 °C",
                    Color = "rgba(255,210,128,1)",
                    OpcionVisualizacionId = 16,
                    ValorLayer = "0,5 - 1,0"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 52,
                    NombreIndicador = "1 °C a 1,5 °C",
                    Color = "rgba(255,168,128,1)",
                    OpcionVisualizacionId = 16,
                    ValorLayer = "1,0 - 1,5"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 53,
                    NombreIndicador = " Muy baja",
                    Color = "rgb(0,97,0)",
                    OpcionVisualizacionId = 17,
                    ValorLayer = "Muy baja"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 54,
                    NombreIndicador = "Baja",
                    Color = " rgb(122,171,0)",
                    OpcionVisualizacionId = 17,
                    ValorLayer = "Baja"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 55,
                    NombreIndicador = "Medio",
                    Color = "rgb(255,255,0)",
                    OpcionVisualizacionId = 18,
                    ValorLayer = "Media"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 56,
                    NombreIndicador = "Alta",
                    Color = "rgb(255,153,0)",
                    OpcionVisualizacionId = 18,
                    ValorLayer = "Alta"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 57,
                    NombreIndicador = "Muy alta",
                    Color = "rgb(255,34,0)",
                    OpcionVisualizacionId = 18,
                    ValorLayer = "Muy alta"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 58,
                    NombreIndicador = "Alta",
                    Color = "rgb(230,0,0)",
                    OpcionVisualizacionId = 19,
                    ValorLayer = "Alta"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 59,
                    NombreIndicador = "Media",
                    Color = "rgb(255,255,0)",
                    OpcionVisualizacionId = 19,
                    ValorLayer = "Media"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 60,
                    NombreIndicador = "Baja",
                    Color = "rgb(112,168,0)",
                    OpcionVisualizacionId = 19,
                    ValorLayer = "Baja"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 61,
                    NombreIndicador = "Marina",
                    Color = " rgb(0,230,169)",
                    OpcionVisualizacionId = 19,
                    ValorLayer = "Marina"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 62,
                    NombreIndicador = " Cuerpo de agua",
                    Color = "rgb(0,92,230)",
                    OpcionVisualizacionId = 19,
                    ValorLayer = "Cuerpo de agua"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 63,
                    NombreIndicador = " No susceptible",
                    Color = "rgb(240,240,240)",
                    OpcionVisualizacionId = 19,
                    ValorLayer = "No"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 64,
                    NombreIndicador = "Urbano",
                    Color = "rgb(104,104,104)",
                    OpcionVisualizacionId = 19,
                    ValorLayer = "Urbano"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 65,
                    NombreIndicador = " Cuerpos de agua",
                    Color = "rgb(0,92,230)",
                    OpcionVisualizacionId = 20,
                    ValorLayer = "Cuerpos de agua"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 66,
                    NombreIndicador = "Inundación 2010 - 2011",
                    Color = "rgb(255,0,0)",
                    OpcionVisualizacionId = 20,
                    ValorLayer = "Inundación 2010 - 2011"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 67,
                    NombreIndicador = "Inundables periódicamente",
                    Color = "rgb(190,232,255)",
                    OpcionVisualizacionId = 20,
                    ValorLayer = "Zonas inundables periodicamente"
                });

                //convenciones municipio

                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 68,
                    NombreIndicador = "Estable",
                    Color = "rgba(114,176,68,1)",
                    OpcionVisualizacionId = 21,
                    ValorLayer = "Estable"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 69,
                    NombreIndicador = "Muy leve",
                    Color = "rgba(205,245,122,1)",
                    OpcionVisualizacionId = 21,
                    ValorLayer = "Muy leve"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 70,
                    NombreIndicador = "Leve",
                    Color = "rgba(255,255,0,1)",
                    OpcionVisualizacionId = 21,
                    ValorLayer = "Leve"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 71,
                    NombreIndicador = "Moderado",
                    Color = "rgba(230,152,0,1)",
                    OpcionVisualizacionId = 21,
                    ValorLayer = "Moderado"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 72,
                    NombreIndicador = "Severo",
                    Color = "rgba(255,0,0,1)",
                    OpcionVisualizacionId = 21,
                    ValorLayer = "Severo"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 73,
                    NombreIndicador = "Cuerpos de agua",
                    Color = "rgba(0,0,255,1)",
                    OpcionVisualizacionId = 22,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 74,
                    NombreIndicador = "Cuerpos de agua",
                    Color = "rgba(0,0,255,1)",
                    OpcionVisualizacionId = 23,
                    ValorLayer = ""
                });

                //Estaciones SPI - Municipio
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 75,
                    NombreIndicador = "Normal",
                    Color = "green",
                    OpcionVisualizacionId = 24,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 76,
                    NombreIndicador = "Húmedo",
                    Color = "blue",
                    OpcionVisualizacionId = 24,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 77,
                    NombreIndicador = "Seco",
                    Color = "red",
                    OpcionVisualizacionId = 24,
                    ValorLayer = ""
                });

                //Estaciones Probabilidad de Ppt - Municipio
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 78,
                    NombreIndicador = "Por encima",
                    Color = "blue",
                    OpcionVisualizacionId = 25,
                    ValorLayer = "Zonas inundables periodicamente"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 79,
                    NombreIndicador = "Dentro",
                    Color = "green",
                    OpcionVisualizacionId = 25,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 80,
                    NombreIndicador = "Por debajo",
                    Color = "red",
                    OpcionVisualizacionId = 25,
                    ValorLayer = ""
                });
                // para municipios capas de aptitudes agroclimaticas y escenarios:
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 81,
                    NombreIndicador = "Nicho productivo óptimo o con leves restricciones ",
                    Color = "rgba(0,97,0,1)",
                    OpcionVisualizacionId = 26,
                    ValorLayer = "1"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 82,
                    NombreIndicador = "Áreas con suelos óptimos o con leves restricciones y alta exposición a exceso hídrico ",
                    Color = "rgba(255,255,115,1)",
                    OpcionVisualizacionId = 26,
                    ValorLayer = "3"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 83,
                    NombreIndicador = "Áreas condicionadas a prácticas de manejo y/o conservación y alta exposición a exceso hídrico",
                    Color = "rgba(255,170,0,1)",
                    OpcionVisualizacionId = 26,
                    ValorLayer = "6"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 84,
                    NombreIndicador = "Áreas con suelos no aptos y alta exposición a exceso hídrico ",
                    Color = " rgba(230,0,0,1)",
                    OpcionVisualizacionId = 26,
                    ValorLayer = "9"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 152,
                    NombreIndicador = "Nicho productivo condicionado a prácticas de manejo y/o conservación ",
                    Color = "rgba(209,255,115,1)",
                    OpcionVisualizacionId = 26,
                    ValorLayer = "4"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 153,
                    NombreIndicador = "Áreas con suelos no aptos ",
                    Color = "rgba(230,0,0,1)",
                    OpcionVisualizacionId = 26,
                    ValorLayer = "7"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 85,
                    NombreIndicador = "Nicho productivo óptimo o con leves restricciones ",
                    Color = "rgba(0,97,0,1)",
                    OpcionVisualizacionId = 27,
                    ValorLayer = "1"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 86,
                    NombreIndicador = "Nicho productivo condicionado a prácticas de manejo y/o conservación ",
                    Color = "rgba(209,255,115,1)",
                    OpcionVisualizacionId = 27,
                    ValorLayer = "4"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 87,
                    NombreIndicador = "Áreas con suelos no aptos ",
                    Color = "rgba(230,0,0,1)",
                    OpcionVisualizacionId = 27,
                    ValorLayer = "7"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 88,
                    NombreIndicador = "Nicho productivo óptimo o con leves restricciones ",
                    Color = "rgba(0,97,0,1)",
                    OpcionVisualizacionId = 28,
                    ValorLayer = "1"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 89,
                    NombreIndicador = "Áreas con suelos óptimos o con leves restricciones y alta exposición a déficit hídrico ",
                    Color = "rgba(255,255,115,1)",
                    OpcionVisualizacionId = 28,
                    ValorLayer = "2"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 90,
                    NombreIndicador = "Áreas condicionadas a prácticas de manejo y/o conservación y alta exposición a déficit hídrico ",
                    Color = "rgba(255,170,0,1)",
                    OpcionVisualizacionId = 28,
                    ValorLayer = "5"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 91,
                    NombreIndicador = "Áreas con suelos no aptos y alta exposición a déficit hídrico ",
                    Color = "rgba(230,0,0,1)",
                    OpcionVisualizacionId = 28,
                    ValorLayer = "8"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 154,
                    NombreIndicador = "Nicho productivo condicionado a prácticas de manejo y/o conservación ",
                    Color = "rgba(209,255,115,1)",
                    OpcionVisualizacionId = 28,
                    ValorLayer = "4"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 155,
                    NombreIndicador = "Áreas con suelos no aptos ",
                    Color = "rgba(230,0,0,1)",
                    OpcionVisualizacionId = 28,
                    ValorLayer = "7"
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 92,
                    NombreIndicador = "circulo",
                    Color = "green",
                    OpcionVisualizacionId = 29,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 93,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 30,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 94,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 31,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 95,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 31,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 96,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 32,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 97,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 32,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 98,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 33,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 99,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 33,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 100,
                    NombreIndicador = "circulo",
                    Color = "green",
                    OpcionVisualizacionId = 34,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 101,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 35,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 102,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 36,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 103,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 36,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 104,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 37,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 105,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 37,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 106,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 38,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 107,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 38,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 108,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 39,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 109,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 39,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 110,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 40,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 111,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 40,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 112,
                    NombreIndicador = "circulo",
                    Color = "green",
                    OpcionVisualizacionId = 41,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 113,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 42,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 114,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 43,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 115,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 43,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 116,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 44,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 117,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 44,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 118,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 45,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 119,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 45,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 120,
                    NombreIndicador = "circulo",
                    Color = "green",
                    OpcionVisualizacionId = 46,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 121,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 47,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 122,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 48,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 123,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 48,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 124,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 49,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 125,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 49,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 126,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 50,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 127,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 50,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 128,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 51,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 129,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 51,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 130,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 52,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 131,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 52,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 132,
                    NombreIndicador = "circulo",
                    Color = "green",
                    OpcionVisualizacionId = 53,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 133,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 54,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 134,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 55,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 135,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 55,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 136,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 56,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 137,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 56,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 138,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 57,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 139,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 57,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 140,
                    NombreIndicador = "circulo",
                    Color = "green",
                    OpcionVisualizacionId = 58,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 141,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 59,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 142,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 60,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 143,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 60,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 144,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 61,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 145,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 61,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 146,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 62,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 147,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 62,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 148,
                    NombreIndicador = "circulo",
                    Color = "yellow",
                    OpcionVisualizacionId = 63,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 149,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 63,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 150,
                    NombreIndicador = "circulo vacio",
                    Color = "",
                    OpcionVisualizacionId = 64,
                    ValorLayer = ""
                });
                contexto.Convenciones.Add(new Convenciones
                {
                    ConvencionId = 151,
                    NombreIndicador = "circulo",
                    Color = "red",
                    OpcionVisualizacionId = 64,
                    ValorLayer = ""
                });


                contexto.SaveChanges();

                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 1,
                    CapaDepartamentoId = 1,
                    TituloSeccion1 = "Subzonas",
                    InformacionMapa = "Se observan las subzonas hidrográficas que conforman la unidad de análisis del departamento del Atlántico. La forma de la cuenca, su relieve, clima, suelos, cuerpos hídricos, etc., influyen en el riesgo agroclimático, es decir, el expresado por cultivos y sistemas de producción agropecuarios frente a eventos climáticos extremos",
                    NombreMapa = "Subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 2,
                    CapaDepartamentoId = 3,
                    TituloSeccion1 = "Precipitación multianual",
                    InformacionMapa = "Nótese como las mayores lluvias se registran al sur de la unidad de análisis en los departamentos de Bolívar y Sucre (amarillo y verde). Sin embargo en Atlántico, las mayores lluvias se localizan en la parte central del departamento.",
                    NombreMapa = "Precipitación media multianual. Período 1980 - 2011 en subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 3,
                    CapaDepartamentoId = 4,
                    TituloSeccion1 = "Conglomerados de precipitación",
                    InformacionMapa = "Nótese como las mayores lluvias se registran al sur de la unidad de análisis en los departamentos de Bolívar y Sucre (amarillo y verde). Sin embargo en Atlántico, las mayores lluvias se localizan en la parte central del departamento.",
                    NombreMapa = "Delimitación de patrones de precipitación en subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 4,
                    CapaDepartamentoId = 5,
                    TituloSeccion1 = "Temperatura",
                    InformacionMapa = "Nótese como la franja litoral entre Bolívar y Atlántico tiene menores temperaturas máximas medias (color rojo claro) que el resto de la unidad de análisis. Esta temperatura aumenta hacia el interior del departamento. Este comportamiento está asociado con la distancia al océano Atlántico.",
                    NombreMapa = "Temperatura promedio multianual. Período 1980 -2011. Subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 5,
                    CapaDepartamentoId = 6,
                    TituloSeccion1 = "Brillo solar",
                    InformacionMapa = "Nótese como los promedios anuales de brillo solar acumulado tienen correspondencia con los conglomerados de lluvia: La zona norte del litoral presenta un promedio anual entre 2300 y 2500 h/año. La zona central muestra valores entre 2100 a 2300 h/año y la zona sur (conglomerado 1) presenta valores entre 1900 y 2100 h/año.",
                    NombreMapa = "Brillo solar total anual. Promedio multianual período 1980-2011. Subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 6,
                    CapaDepartamentoId = 8,
                    TituloSeccion1 = "Humedad relativa",
                    InformacionMapa = "Nótese como la humedad relativa anual promedio en la unidad de análisis toma valores entre 80 y 85 %, con excepción de la estación ubicada en el municipio Repelón con valores entre el 75 y el 80%",
                    NombreMapa = "Humedad relativa media anual. Promedio multianual período 1980-2011. Subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 7,
                    CapaDepartamentoId = 9,
                    TituloSeccion1 = "Precipitación",
                    InformacionMapa = "Variación porcentual de la lluvia mensual promedio bajo eventos El Niño y La Niña (cuando estos se presentan). Aunque hay una importante relación entre las variaciones en las lluvias de la región y los fenómenos El Niño y La Niña, estos fenómenos no explican completamente todas las variaciones que se presentan en la zona.",
                    NombreMapa = "Anomalía porcentual de la precipitación en subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 8,
                    CapaDepartamentoId = 10,
                    TituloSeccion1 = "Temperatura",
                    InformacionMapa = "La gráfica muestra el efecto de los eventos El Niño y La Niña en las temperaturas mensuales (color azul diminución, color rojo aumento). En general, en la unidad de análisis del departamento de Atlántico la temperatura del aire (media, máxima media y mínima media) aumenta bajo eventos El Niño y disminuye bajo eventos La Niña.",
                    NombreMapa = "Anomalía porcentual de la precipitación en subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 9,
                    CapaDepartamentoId = 11,
                    TituloSeccion1 = "Frecuencia a excesos y déficit",
                    InformacionMapa = "Estas condiciones de exceso y/o déficit se determinan mediante el análisis del índice mensual de Palmer – PDSI  el cual refleja la condición de humedad en función de los registros mensuales de precipitación, la evapotranspiración del cultivo y la capacidad de almacenamiento de agua en el suelo.",
                    NombreMapa = "Frecuencia de exceso y déficit hídrico a partir del PDSI en subzonas hidrográficas del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 10,
                    CapaDepartamentoId = 12,
                    TituloSeccion1 = "Susceptibilidad a inundaciones",
                    InformacionMapa = "La condición alta abarca  zonas que con una periodicidad de al menos una vez al año pueden recibir agua en épocas de aumentos de cauces. La media abarca zonas que pueden recibir agua en épocas de aumentos de cauces, una o varias veces por década. La baja corresponde a las zonas que pueden recibir inundaciones bajo eventos extremos de precipitación que ocurren generalmente en varias décadas.",
                    NombreMapa = "Susceptibilidad a inundación del departamento del Atlántico."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 11,
                    CapaDepartamentoId = 15,
                    TituloSeccion1 = "Subzonas",
                    InformacionMapa = "Se observan las subzonas hidrográficas que conforman la unidad de análisis del departamento  Norte de santander. La forma de la cuenca, su relieve, clima, suelos, cuerpos hídricos, etc., influyen en el riesgo agroclimático, es decir, el expresado por cultivos y sistemas de producción agropecuarios frente a eventos climáticos extremos",
                    NombreMapa = "Subzonas hidrográficas del departamento Norte de santander"
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 12,
                    CapaDepartamentoId = 17,
                    TituloSeccion1 = "Precipitación multianual",
                    InformacionMapa = "Nótese como las mayores lluvias se registran al sur de la unidad de análisis en los departamentos de Bolívar y Sucre (amarillo y verde). Sin embargo en Norte de Santander, las mayores lluvias se localizan en la parte central del departamento.",
                    NombreMapa = "Precipitación media multianual. Período 1980 - 2011 en subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 13,
                    CapaDepartamentoId = 18,
                    TituloSeccion1 = "Conglomerados de precipitación",
                    InformacionMapa = "Nótese como las mayores lluvias se registran al sur de la unidad de análisis en los departamentos de Bolívar y Sucre (amarillo y verde). Sin embargo en Norte de Santander, las mayores lluvias se localizan en la parte central del departamento.",
                    NombreMapa = "Delimitación de patrones de precipitación en subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 14,
                    CapaDepartamentoId = 19,
                    TituloSeccion1 = "Temperatura",
                    InformacionMapa = "Nótese como la franja litoral entre Bolívar y Norte de Santander tiene menores temperaturas máximas medias (color rojo claro) que el resto de la unidad de análisis. Esta temperatura aumenta hacia el interior del departamento. Este comportamiento está asociado con la distancia al océano Norte de Santander.",
                    NombreMapa = "Temperatura promedio multianual. Período 1980 -2011. Subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 15,
                    CapaDepartamentoId = 20,
                    TituloSeccion1 = "Brillo solar",
                    InformacionMapa = "Nótese como los promedios anuales de brillo solar acumulado tienen correspondencia con los conglomerados de lluvia: La zona norte del litoral presenta un promedio anual entre 2300 y 2500 h/año. La zona central muestra valores entre 2100 a 2300 h/año y la zona sur (conglomerado 1) presenta valores entre 1900 y 2100 h/año.",
                    NombreMapa = "Brillo solar total anual. Promedio multianual período 1980-2011. Subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 16,
                    CapaDepartamentoId = 22,
                    TituloSeccion1 = "Humedad relativa",
                    InformacionMapa = "Nótese como la humedad relativa anual promedio en la unidad de análisis toma valores entre 80 y 85 %, con excepción de la estación ubicada en el municipio Repelón con valores entre el 75 y el 80%",
                    NombreMapa = "Humedad relativa media anual. Promedio multianual período 1980-2011. Subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 17,
                    CapaDepartamentoId = 23,
                    TituloSeccion1 = "Precipitación",
                    InformacionMapa = "Variación porcentual de la lluvia mensual promedio bajo eventos El Niño y La Niña (cuando estos se presentan). Aunque hay una importante relación entre las variaciones en las lluvias de la región y los fenómenos El Niño y La Niña, estos fenómenos no explican completamente todas las variaciones que se presentan en la zona.",
                    NombreMapa = "Anomalía porcentual de la precipitación en subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 18,
                    CapaDepartamentoId = 24,
                    TituloSeccion1 = "Temperatura",
                    InformacionMapa = "La gráfica muestra el efecto de los eventos El Niño y La Niña en las temperaturas mensuales (color azul diminución, color rojo aumento). En general, en la unidad de análisis del departamento de Norte de Santander la temperatura del aire (media, máxima media y mínima media) aumenta bajo eventos El Niño y disminuye bajo eventos La Niña.",
                    NombreMapa = "Anomalía porcentual de la precipitación en subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 19,
                    CapaDepartamentoId = 25,
                    TituloSeccion1 = "Frecuencia a excesos y déficit",
                    InformacionMapa = "Estas condiciones de exceso y/o déficit se determinan mediante el análisis del índice mensual de Palmer – PDSI  el cual refleja la condición de humedad en función de los registros mensuales de precipitación, la evapotranspiración del cultivo y la capacidad de almacenamiento de agua en el suelo.",
                    NombreMapa = "Frecuencia de exceso y déficit hídrico a partir del PDSI en subzonas hidrográficas del departamento Norte de Santander."
                });
                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 20,
                    CapaDepartamentoId = 26,
                    TituloSeccion1 = "Susceptibilidad a inundaciones",
                    InformacionMapa = "La condición alta abarca  zonas que con una periodicidad de al menos una vez al año pueden recibir agua en épocas de aumentos de cauces. La media abarca zonas que pueden recibir agua en épocas de aumentos de cauces, una o varias veces por década. La baja corresponde a las zonas que pueden recibir inundaciones bajo eventos extremos de precipitación que ocurren generalmente en varias décadas.",
                    NombreMapa = "Susceptibilidad a inundación del departamento Norte de Santander."
                });

                contexto.InformacionAmpliaSeccion1.Add(new InformacionAmpliaSeccion1
                {
                    InformacionAmpliaSeccion1Id = 21,
                    CapaDepartamentoId = 6,
                    TituloSeccion1 = "Brillo solar",
                    InformacionMapa = "Nótese como los promedios anuales de brillo solar acumulado tienen correspondencia con los conglomerados de lluvia: La zona norte del litoral presenta un promedio anual entre 2300 y 2500 h/año. La zona central muestra valores entre 2100 a 2300 h/año y la zona sur (conglomerado 1) presenta valores entre 1900 y 2100 h/año.",
                    NombreMapa = "Brillo solar total anual. Promedio multianual período 1980-2011. Subzonas hidrográficas del departamento del Atlántico."
                });

                contexto.SaveChanges();
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 1,
                    CapaDepartamentoId = 2,
                    NombreCortoSeccion2 = "SinopticaPpal",
                    TituloSeccion2 = "Sinóptica principal",
                    Icono = "icon-windleft iconos fondo-verde",
                    Descripcion = "Son estaciones cuyos datos se utilizan principalmente para análisis y predicciones del estado del tiempo y para fines de orientación del transporte aéreo. Esta información se codifica y se intercambia a través de los centros mundiales con el fin de alimentar los modelos globales y locales de pronóstico y para el servicio de la aviación."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 2,
                    CapaDepartamentoId = 2,
                    NombreCortoSeccion2 = "ClimatPpal",
                    TituloSeccion2 = "Climatológica principal",
                    Icono = "icon-windleft iconos fondo-amarillo",
                    Descripcion = "Estación cuyos datos sirven para caracterizar las condiciones climáticas locales y en la que se hacen lecturas horarias u observaciones por lo menos tres veces al día, además de las lecturas horarias efectuadas según datos registrados autográficamente de las variables: precipitación, temperatura del aire, humedad, viento, radiación solar, evaporación y otros fenómenos especiales."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 3,
                    CapaDepartamentoId = 2,
                    NombreCortoSeccion2 = "ClimatOrdin",
                    TituloSeccion2 = "Climatológica ordinaria",
                    Icono = "icon-windleft iconos fondo-naranja",
                    Descripcion = "Estación en la que se efectúan observaciones por lo menos una vez al día, incluidos los máximos y mínimos diarios de la temperatura y las cantidades diarias de precipitación."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 4,
                    CapaDepartamentoId = 2,
                    NombreCortoSeccion2 = "Pluviometrica",
                    TituloSeccion2 = "Pluviométrica",
                    Icono = "icon-windleft iconos fondo-gris",
                    Descripcion = "Tiene un pluviómetro o recipiente que permite medir la cantidad de lluvia caída entre dos mediciones realizadas consecutivas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 5,
                    CapaDepartamentoId = 2,
                    NombreCortoSeccion2 = "Agrometeorologica",
                    TituloSeccion2 = "Agrometeorológica",
                    Icono = "icon-windleft iconos fondo-rojo",
                    Descripcion = "Estación que facilita información meteorológica para aplicaciones del sector agropecuario. Se destaca la medición de la humedad y temperatura del suelo, evaporación, y en algunos casos humedad y temperatura de la hoja."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 6,
                    CapaDepartamentoId = 4,
                    NombreCortoSeccion2 = "conglomeradosG1",
                    TituloSeccion2 = "¿Cómo varía la temperatura del aire mes a mes durante eventos El Niño y La Niña? ",
                    Icono = "",
                    Descripcion = "La gráfica nos permite conocer la distribución y cantidad mensual de lluvia en cada conglomerado climático. Hacia el litoral norte del Atlántico y Bolívar las temporadas secas son más intensas y por consiguiente la escasez de agua puede ser más drástica "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 7,
                    CapaDepartamentoId = 4,
                    NombreCortoSeccion2 = "conglomeradosG2",
                    TituloSeccion2 = "",
                    Icono = "",
                    Descripcion = "De acuerdo a la distribución de las lluvias, los meses del año se pueden dividir por cuatrimestres de la siguiente forma: temporada seca de principio de año (diciembre, enero, febrero, marzo, cuatrimestre DEFM), temporada de lluvias intermedias (abril, mayo, junio, julio, cuatrimestre AMJJ) y temporadas lluvias fuertes (agosto, septiembre, octubre y noviembre, cuatrimestre ASON). Una característica climática de la región es la frecuente ocurrencia de periodos muy secos durante los meses de enero y febrero que desencadenan sequías con impactos negativos sobre la agricultura de la región. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 8,
                    CapaDepartamentoId = 5,
                    NombreCortoSeccion2 = "Min_media",
                    TituloSeccion2 = "Mínima media",
                    Icono = "icon-snow iconos",
                    Descripcion = "Es el valor promedio de temperatura mínima obtenido de una serie de observaciones. Este promedio de valores mínimos puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula a partir de 30 años consecutivos de datos de temperaturas mínimas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 9,
                    CapaDepartamentoId = 5,
                    NombreCortoSeccion2 = "Media",
                    TituloSeccion2 = "Media",
                    Icono = "icon-wind iconos",
                    Descripcion = "Es el valor promedio de temperatura obtenido de una serie de observaciones. El promedio puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula el valor normal o promedio de 30 años consecutivos de datos."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 10,
                    CapaDepartamentoId = 5,
                    NombreCortoSeccion2 = "MaximaMedia",
                    TituloSeccion2 = "Máxima media",
                    Icono = "icon-temperaturealt-thermometeralt iconos",
                    Descripcion = "Es el valor promedio de temperatura máxima obtenido de una serie de observaciones. Este promedio de valores máximos puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula a partir de 30 años consecutivos de datos de temperaturas máximas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 11,
                    CapaDepartamentoId = 7,
                    NombreCortoSeccion2 = "evotransp_define",
                    TituloSeccion2 = "¿Qué es la evapotranspiración? ",
                    Icono = "",
                    Descripcion = "Es la unión entre la evaporación de agua desde el suelo y la transpiración por parte de la vegetación. Sintetiza el comportamiento conjunto de la temperatura del aire, la humedad relativa, la radicación solar y la velocidad del viento. La ETO como proceso natural del ciclo hidrológico, se considera como la variable clave en el balance hídrico de una región en términos de masa (movimiento de agua) y energía (balance de radiación). "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 12,
                    CapaDepartamentoId = 7,
                    NombreCortoSeccion2 = "evotransp_define2",
                    TituloSeccion2 = "",
                    Icono = "",
                    Descripcion = "Para el balance hídrico agrícola la ETO (evapotranspiración del cultivo de referencia) representa el proceso por el cual se pierde agua desde el suelo y los cultivos, que debe suplirse mediante la lluvia o el riego en lo que se denomina requerimiento hídrico del cultivo. Esto depende del tipo, la etapa fenológica y el manejo agronómico del cultivo. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 13,
                    CapaDepartamentoId = 7,
                    NombreCortoSeccion2 = "evotranspG1",
                    TituloSeccion2 = "",
                    Icono = "",
                    Descripcion = "Los cálculos generados para representar los histogramas, gráficas y tablas se han realizado teniendo como base a todas las subzonas hidrográficas que confluyen en el departamento "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 14,
                    CapaDepartamentoId = 9,
                    NombreCortoSeccion2 = "precipitacion_define",
                    TituloSeccion2 = "¿Cómo varía mes a mes la precipitación durante eventos El Niño y La Niña? ",
                    Icono = "",
                    Descripcion = "Variación porcentual de la lluvia mensual promedio bajo eventos El Niño y La Niña (cuando estos se presentan). Nótese que en abril, mayo y junio la señal de las anomalías es más débil a diferencia de diciembre, enero y febrero cuando la señal de aumento y disminución de la precipitación es mayor. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 15,
                    CapaDepartamentoId = 10,
                    NombreCortoSeccion2 = "temperatura_define",
                    TituloSeccion2 = "¿Cómo varía la temperatura del aire mes a mes durante eventos El Niño y La Niña? ",
                    Icono = "",
                    Descripcion = "Las gráficas muestran el efecto de los eventos El Niño y La Niña en las temperaturas mensuales (color azul diminución, color rojo aumento). En general, en la unidad de análisis del departamento de Atlántico la temperatura del aire (media, máxima media y mínima media) aumenta bajo eventos El Niño y disminuye bajo eventos La Niña. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 16,
                    CapaDepartamentoId = 11,
                    NombreCortoSeccion2 = "psdi",
                    TituloSeccion2 = "¿Qué es el PDSI?",
                    Icono = "icon-soundwave iconos",
                    Descripcion = "Es el valor promedio de temperatura mínima obtenido de una serie de observaciones. Este promedio de valores mínimos puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula a partir de 30 años consecutivos de datos de temperaturas mínimas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 17,
                    CapaDepartamentoId = 13,
                    NombreCortoSeccion2 = "clima_define",
                    TituloSeccion2 = "¿Qué es clima? ",
                    Icono = "",
                    Descripcion = "Es el resumen de las condiciones meteorológicas en un lugar determinado, caracterizada por estadísticas a largo plazo de los elementos meteorológicos (temperatura, presión, vientos, humedad y precipitaciones). "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 18,
                    CapaDepartamentoId = 14,
                    NombreCortoSeccion2 = "tiempo_define",
                    TituloSeccion2 = "¿Qué es tiempo meteorológico? ",
                    Icono = "",
                    Descripcion = "Estado de la atmósfera en un instante dado, definido por diversos elementos meteorológicos como la temperatura, precipitación, humedad del aire, entre otros."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 19,
                    CapaDepartamentoId = 29,
                    NombreCortoSeccion2 = "variabilidad_def",
                    TituloSeccion2 = "¿Qué es variabilidad? ",
                    Icono = "",
                    Descripcion = "El término 'variabilidad climática' designa las fluctuaciones del clima en diversos períodos de tiempo (por ejemplo, un mes, estación o año determinados) respecto a estadísticas climáticas a largo plazo relacionadas con el mismo período del calendario. En este sentido, la variabilidad climática se mide por esas desviaciones, denominadas habitualmente anomalías. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 20,
                    CapaDepartamentoId = 31,
                    NombreCortoSeccion2 = "niño_niña_def",
                    TituloSeccion2 = "¿Qué son los eventos ENSO o Niño y Niña? ",
                    Icono = "",
                    Descripcion = "En forma muy general, «El Niño» es el nombre que se da al fenómeno que se presenta cuando la temperatura superficial del mar en el Océano Pacífico Ecuatorial aumenta con respecto al promedio histórico (calentamiento). Este fenómeno oceánico está acoplado al fenómeno atmosférico conocido como la «Oscilación del Sur», el cual consiste en una inversión del gradiente de presión atmosférica superficial entre la región oriental y la occidental del océano Pacífico del sur y puede dar como consecuencia una inversión en la circulación de los vientos sobre la superficie del océano Pacífico tropical. El acoplamiento entre estos dos fenómenos, definido como El Niño – Oscilación del Sur, ENOS o ENSO, es de grandes consecuencias climáticas en Colombia. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 21,
                    CapaDepartamentoId = 16,
                    NombreCortoSeccion2 = "SinopticaPpal",
                    TituloSeccion2 = "Sinóptica principal",
                    Icono = "icon-windleft iconos fondo-verde",
                    Descripcion = "Son estaciones cuyos datos se utilizan principalmente para análisis y predicciones del estado del tiempo y para fines de orientación del transporte aéreo. Esta información se codifica y se intercambia a través de los centros mundiales con el fin de alimentar los modelos globales y locales de pronóstico y para el servicio de la aviación.(Norte Santander)"
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 22,
                    CapaDepartamentoId = 16,
                    NombreCortoSeccion2 = "ClimatPpal",
                    TituloSeccion2 = "Climatológica principal",
                    Icono = "icon-windleft iconos fondo-amarillo",
                    Descripcion = "Estación cuyos datos sirven para caracterizar las condiciones climáticas locales y en la que se hacen lecturas horarias u observaciones por lo menos tres veces al día, además de las lecturas horarias efectuadas según datos registrados autográficamente de las variables: precipitación, temperatura del aire, humedad, viento, radiación solar, evaporación y otros fenómenos especiales."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 23,
                    CapaDepartamentoId = 16,
                    NombreCortoSeccion2 = "ClimatOrdin",
                    TituloSeccion2 = "Climatológica ordinaria",
                    Icono = "icon-windleft iconos fondo-naranja",
                    Descripcion = "Estación en la que se efectúan observaciones por lo menos una vez al día, incluidos los máximos y mínimos diarios de la temperatura y las cantidades diarias de precipitación."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 24,
                    CapaDepartamentoId = 16,
                    NombreCortoSeccion2 = "Pluviometrica",
                    TituloSeccion2 = "Pluviométrica",
                    Icono = "icon-windleft iconos fondo-gris",
                    Descripcion = "Tiene un pluviómetro o recipiente que permite medir la cantidad de lluvia caída entre dos mediciones realizadas consecutivas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 25,
                    CapaDepartamentoId = 16,
                    NombreCortoSeccion2 = "Agrometeorologica",
                    TituloSeccion2 = "Agrometeorológica",
                    Icono = "icon-windleft iconos fondo-rojo",
                    Descripcion = "Estación que facilita información meteorológica para aplicaciones del sector agropecuario. Se destaca la medición de la humedad y temperatura del suelo, evaporación, y en algunos casos humedad y temperatura de la hoja."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 26,
                    CapaDepartamentoId = 18,
                    NombreCortoSeccion2 = "conglomeradosG1",
                    TituloSeccion2 = "¿Cómo varía la temperatura del aire mes a mes durante eventos El Niño y La Niña? ",
                    Icono = "",
                    Descripcion = "La gráfica nos permite conocer la distribución y cantidad mensual de lluvia en cada conglomerado climático. Hacia el litoral norte de Norte de Santander y Bolívar las temporadas secas son más intensas y por consiguiente la escasez de agua puede ser más drástica "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 27,
                    CapaDepartamentoId = 18,
                    NombreCortoSeccion2 = "conglomeradosG2",
                    TituloSeccion2 = "",
                    Icono = "",
                    Descripcion = "De acuerdo a la distribución de las lluvias, los meses del año se pueden dividir por cuatrimestres de la siguiente forma: temporada seca de principio de año (diciembre, enero, febrero, marzo, cuatrimestre DEFM), temporada de lluvias intermedias (abril, mayo, junio, julio, cuatrimestre AMJJ) y temporadas lluvias fuertes (agosto, septiembre, octubre y noviembre, cuatrimestre ASON). Una característica climática de la región es la frecuente ocurrencia de periodos muy secos durante los meses de enero y febrero que desencadenan sequías con impactos negativos sobre la agricultura de la región. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 28,
                    CapaDepartamentoId = 19,
                    NombreCortoSeccion2 = "Min_media",
                    TituloSeccion2 = "Mínima media",
                    Icono = "icon-snow iconos",
                    Descripcion = "Es el valor promedio de temperatura mínima obtenido de una serie de observaciones. Este promedio de valores mínimos puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula a partir de 30 años consecutivos de datos de temperaturas mínimas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 29,
                    CapaDepartamentoId = 19,
                    NombreCortoSeccion2 = "Media",
                    TituloSeccion2 = "Media",
                    Icono = "icon-wind iconos",
                    Descripcion = "Es el valor promedio de temperatura obtenido de una serie de observaciones. El promedio puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula el valor normal o promedio de 30 años consecutivos de datos."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 30,
                    CapaDepartamentoId = 19,
                    NombreCortoSeccion2 = "MaximaMedia",
                    TituloSeccion2 = "Máxima media",
                    Icono = "icon-temperaturealt-thermometeralt iconos",
                    Descripcion = "Es el valor promedio de temperatura máxima obtenido de una serie de observaciones. Este promedio de valores máximos puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula a partir de 30 años consecutivos de datos de temperaturas máximas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 31,
                    CapaDepartamentoId = 21,
                    NombreCortoSeccion2 = "evotransp_define",
                    TituloSeccion2 = "¿Qué es la evapotranspiración? ",
                    Icono = "",
                    Descripcion = "Es la unión entre la evaporación de agua desde el suelo y la transpiración por parte de la vegetación. Sintetiza el comportamiento conjunto de la temperatura del aire, la humedad relativa, la radicación solar y la velocidad del viento. La ETO como proceso natural del ciclo hidrológico, se considera como la variable clave en el balance hídrico de una región en términos de masa (movimiento de agua) y energía (balance de radiación). "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 32,
                    CapaDepartamentoId = 21,
                    NombreCortoSeccion2 = "evotransp_define2",
                    TituloSeccion2 = "",
                    Icono = "",
                    Descripcion = "Para el balance hídrico agrícola la ETO (evapotranspiración del cultivo de referencia) representa el proceso por el cual se pierde agua desde el suelo y los cultivos, que debe suplirse mediante la lluvia o el riego en lo que se denomina requerimiento hídrico del cultivo. Esto depende del tipo, la etapa fenológica y el manejo agronómico del cultivo. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 33,
                    CapaDepartamentoId = 21,
                    NombreCortoSeccion2 = "evotranspG1",
                    TituloSeccion2 = "",
                    Icono = "",
                    Descripcion = "Los cálculos generados para representar los histogramas, gráficas y tablas se han realizado teniendo como base a todas las subzonas hidrográficas que confluyen en el departamento "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 34,
                    CapaDepartamentoId = 23,
                    NombreCortoSeccion2 = "precipitacion_define",
                    TituloSeccion2 = "¿Cómo varía mes a mes la precipitación durante eventos El Niño y La Niña? ",
                    Icono = "",
                    Descripcion = "Variación porcentual de la lluvia mensual promedio bajo eventos El Niño y La Niña (cuando estos se presentan). Nótese que en abril, mayo y junio la señal de las anomalías es más débil a diferencia de diciembre, enero y febrero cuando la señal de aumento y disminución de la precipitación es mayor. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 35,
                    CapaDepartamentoId = 24,
                    NombreCortoSeccion2 = "temperatura_define",
                    TituloSeccion2 = "¿Cómo varía la temperatura del aire mes a mes durante eventos El Niño y La Niña? ",
                    Icono = "",
                    Descripcion = "Las gráficas muestran el efecto de los eventos El Niño y La Niña en las temperaturas mensuales (color azul diminución, color rojo aumento). En general, en la unidad de análisis del departamento de Norte de Santander la temperatura del aire (media, máxima media y mínima media) aumenta bajo eventos El Niño y disminuye bajo eventos La Niña. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 36,
                    CapaDepartamentoId = 25,
                    NombreCortoSeccion2 = "psdi",
                    TituloSeccion2 = "¿Qué es el PDSI?",
                    Icono = "icon-soundwave iconos",
                    Descripcion = "Es el valor promedio de temperatura mínima obtenido de una serie de observaciones. Este promedio de valores mínimos puede ser diario, mensual, anual o de varios años. Generalmente en climatología se calcula a partir de 30 años consecutivos de datos de temperaturas mínimas."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 37,
                    CapaDepartamentoId = 27,
                    NombreCortoSeccion2 = "clima_define",
                    TituloSeccion2 = "¿Qué es clima? ",
                    Icono = "",
                    Descripcion = "Es el resumen de las condiciones meteorológicas en un lugar determinado, caracterizada por estadísticas a largo plazo de los elementos meteorológicos (temperatura, presión, vientos, humedad y precipitaciones). "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 38,
                    CapaDepartamentoId = 28,
                    NombreCortoSeccion2 = "tiempo_define",
                    TituloSeccion2 = "¿Qué es tiempo meteorológico? ",
                    Icono = "",
                    Descripcion = "Estado de la atmósfera en un instante dado, definido por diversos elementos meteorológicos como la temperatura, precipitación, humedad del aire, entre otros."
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 39,
                    CapaDepartamentoId = 30,
                    NombreCortoSeccion2 = "variabilidad_def",
                    TituloSeccion2 = "¿Qué es variabilidad? ",
                    Icono = "",
                    Descripcion = "El término 'variabilidad climática' designa las fluctuaciones del clima en diversos períodos de tiempo (por ejemplo, un mes, estación o año determinados) respecto a estadísticas climáticas a largo plazo relacionadas con el mismo período del calendario. En este sentido, la variabilidad climática se mide por esas desviaciones, denominadas habitualmente anomalías. "
                });
                contexto.InformacionAmpliaSeccion2.Add(new InformacionAmpliaSeccion2
                {
                    InformacionAmpliaSeccion2Id = 40,
                    CapaDepartamentoId = 32,
                    NombreCortoSeccion2 = "niño_niña_def",
                    TituloSeccion2 = "¿Qué son los eventos ENSO o Niño y Niña? ",
                    Icono = "",
                    Descripcion = "En forma muy general, «El Niño» es el nombre que se da al fenómeno que se presenta cuando la temperatura superficial del mar en el Océano Pacífico Ecuatorial aumenta con respecto al promedio histórico (calentamiento). Este fenómeno oceánico está acoplado al fenómeno atmosférico conocido como la «Oscilación del Sur», el cual consiste en una inversión del gradiente de presión atmosférica superficial entre la región oriental y la occidental del océano Pacífico del sur y puede dar como consecuencia una inversión en la circulación de los vientos sobre la superficie del océano Pacífico tropical. El acoplamiento entre estos dos fenómenos, definido como El Niño – Oscilación del Sur, ENOS o ENSO, es de grandes consecuencias climáticas en Colombia. "
                });
                contexto.SaveChanges();

                //informacion amplia municipios:

                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 1,
                    CapaMunicipioId = 13,
                    TituloSeccion1Mcipio = "Estaciones",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal. ",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico"
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 2,
                    CapaMunicipioId = 31,
                    TituloSeccion1Mcipio = "Índice ndvi ",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 3,
                    CapaMunicipioId = 37,
                    TituloSeccion1Mcipio = "Susceptibilidad a inundaciones",
                    InformacionMapa = "El mapa señala los cuerpos de agua que bajo un fenómeno El Niño o La Niña han tenido aumento o disminución en su área en comparación con la línea base cartográfica trazada bajo condiciones normales, la cual corresponde a la oficial a escala 1:25.000 del IGAC. La dinámica de los cuerpos de agua es analizada a partir de índices espectrales calculados sobre imágenes de satélite de media – alta resolución espacial. ",
                    NombreMapa = ""
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 4,
                    CapaMunicipioId = 19,
                    TituloSeccion1Mcipio = "Aptitud agroclimática ",
                    InformacionMapa = "En el mapa se pueden observar las zonas en donde el suelo y el agua disponible en el suelo son adecuadas o son de alto riesgo para establecer cultivos. Estos mapas permiten identificar el riesgo ya sea por limitaciones de suelo o por riesgo de excesos o deficiencias hídricas severas para el cultivo.. ",
                    NombreMapa = "Aptitud agroclimática del munucipio de Repelón. "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 5,
                    CapaMunicipioId = 25,
                    TituloSeccion1Mcipio = "",
                    InformacionMapa = "Comportamiento de la humedad en el suelo para el cultivo en épocas sin anomalías climáticas o cuando hay pronósticos de épocas secas (por ejemplo El Niño) o épocas lluviosas (fenómeno de La Niña). Se observa la ubicación de los suelos más aptos, moderados y no aptos para el cultivo, así como la probabilidad de que ocurra un exceso de agua, un déficit de agua o una humedad de suelo adecuada en etapas fenológicas sensibles de cultivo. ",
                    NombreMapa = "Escenarios agroclimáticos del municipio de Repelón para el cultivo de tomate "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 6,
                    CapaMunicipioId = 14,
                    TituloSeccion1Mcipio = "Estaciones",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal. ",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico"
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 7,
                    CapaMunicipioId = 32,
                    TituloSeccion1Mcipio = "Índice ndvi ",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 8,
                    CapaMunicipioId = 38,
                    TituloSeccion1Mcipio = "Susceptibilidad a inundaciones",
                    InformacionMapa = "El mapa señala los cuerpos de agua que bajo un fenómeno El Niño o La Niña han tenido aumento o disminución en su área en comparación con la línea base cartográfica trazada bajo condiciones normales, la cual corresponde a la oficial a escala 1:25.000 del IGAC. La dinámica de los cuerpos de agua es analizada a partir de índices espectrales calculados sobre imágenes de satélite de media – alta resolución espacial. ",
                    NombreMapa = ""
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 9,
                    CapaMunicipioId = 20,
                    TituloSeccion1Mcipio = "Aptitud agroclimática ",
                    InformacionMapa = "En el mapa se pueden observar las zonas en donde el suelo y el agua disponible en el suelo son adecuadas o son de alto riesgo para establecer cultivos. Estos mapas permiten identificar el riesgo ya sea por limitaciones de suelo o por riesgo de excesos o deficiencias hídricas severas para el cultivo.. ",
                    NombreMapa = "Aptitud agroclimática del munucipio de Suan "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 10,
                    CapaMunicipioId = 26,
                    TituloSeccion1Mcipio = "",
                    InformacionMapa = "Comportamiento de la humedad en el suelo para el cultivo en épocas sin anomalías climáticas o cuando hay pronósticos de épocas secas (por ejemplo El Niño) o épocas lluviosas (fenómeno de La Niña). Se observa la ubicación de los suelos más aptos, moderados y no aptos para el cultivo, así como la probabilidad de que ocurra un exceso de agua, un déficit de agua o una humedad de suelo adecuada en etapas fenológicas sensibles de cultivo. ",
                    NombreMapa = "Escenarios agroclimáticos del municipio de Suan para el cultivo de tomate "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 11,
                    CapaMunicipioId = 15,
                    TituloSeccion1Mcipio = "Estaciones",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal. ",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico"
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 12,
                    CapaMunicipioId = 33,
                    TituloSeccion1Mcipio = "Índice ndvi ",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 13,
                    CapaMunicipioId = 39,
                    TituloSeccion1Mcipio = "Susceptibilidad a inundaciones",
                    InformacionMapa = "El mapa señala los cuerpos de agua que bajo un fenómeno El Niño o La Niña han tenido aumento o disminución en su área en comparación con la línea base cartográfica trazada bajo condiciones normales, la cual corresponde a la oficial a escala 1:25.000 del IGAC. La dinámica de los cuerpos de agua es analizada a partir de índices espectrales calculados sobre imágenes de satélite de media – alta resolución espacial. ",
                    NombreMapa = ""
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 14,
                    CapaMunicipioId = 21,
                    TituloSeccion1Mcipio = "Aptitud agroclimática ",
                    InformacionMapa = "En el mapa se pueden observar las zonas en donde el suelo y el agua disponible en el suelo son adecuadas o son de alto riesgo para establecer cultivos. Estos mapas permiten identificar el riesgo ya sea por limitaciones de suelo o por riesgo de excesos o deficiencias hídricas severas para el cultivo.. ",
                    NombreMapa = "Aptitud agroclimática del munucipio de Manti "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 15,
                    CapaMunicipioId = 27,
                    TituloSeccion1Mcipio = "",
                    InformacionMapa = "Comportamiento de la humedad en el suelo para el cultivo en épocas sin anomalías climáticas o cuando hay pronósticos de épocas secas (por ejemplo El Niño) o épocas lluviosas (fenómeno de La Niña). Se observa la ubicación de los suelos más aptos, moderados y no aptos para el cultivo, así como la probabilidad de que ocurra un exceso de agua, un déficit de agua o una humedad de suelo adecuada en etapas fenológicas sensibles de cultivo. ",
                    NombreMapa = "Escenarios agroclimáticos del municipio de Manati para el cultivo de tomate "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 16,
                    CapaMunicipioId = 16,
                    TituloSeccion1Mcipio = "Estaciones",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal. ",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico"
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 17,
                    CapaMunicipioId = 34,
                    TituloSeccion1Mcipio = "Índice ndvi ",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 18,
                    CapaMunicipioId = 40,
                    TituloSeccion1Mcipio = "Susceptibilidad a inundaciones",
                    InformacionMapa = "El mapa señala los cuerpos de agua que bajo un fenómeno El Niño o La Niña han tenido aumento o disminución en su área en comparación con la línea base cartográfica trazada bajo condiciones normales, la cual corresponde a la oficial a escala 1:25.000 del IGAC. La dinámica de los cuerpos de agua es analizada a partir de índices espectrales calculados sobre imágenes de satélite de media – alta resolución espacial. ",
                    NombreMapa = ""
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 19,
                    CapaMunicipioId = 22,
                    TituloSeccion1Mcipio = "Aptitud agroclimática ",
                    InformacionMapa = "En el mapa se pueden observar las zonas en donde el suelo y el agua disponible en el suelo son adecuadas o son de alto riesgo para establecer cultivos. Estos mapas permiten identificar el riesgo ya sea por limitaciones de suelo o por riesgo de excesos o deficiencias hídricas severas para el cultivo.. ",
                    NombreMapa = "Aptitud agroclimática del municipio de Campo de la Cruz "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 20,
                    CapaMunicipioId = 28,
                    TituloSeccion1Mcipio = "",
                    InformacionMapa = "Comportamiento de la humedad en el suelo para el cultivo en épocas sin anomalías climáticas o cuando hay pronósticos de épocas secas (por ejemplo El Niño) o épocas lluviosas (fenómeno de La Niña). Se observa la ubicación de los suelos más aptos, moderados y no aptos para el cultivo, así como la probabilidad de que ocurra un exceso de agua, un déficit de agua o una humedad de suelo adecuada en etapas fenológicas sensibles de cultivo. ",
                    NombreMapa = "Escenarios agroclimáticos del municipio de Campo de la Cruz para el cultivo de tomate "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 21,
                    CapaMunicipioId = 17,
                    TituloSeccion1Mcipio = "Estaciones",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal. ",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico"
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 22,
                    CapaMunicipioId = 23,
                    TituloSeccion1Mcipio = "Aptitud agroclimática ",
                    InformacionMapa = "En el mapa se pueden observar las zonas en donde el suelo y el agua disponible en el suelo son adecuadas o son de alto riesgo para establecer cultivos. Estos mapas permiten identificar el riesgo ya sea por limitaciones de suelo o por riesgo de excesos o deficiencias hídricas severas para el cultivo.. ",
                    NombreMapa = "Aptitud agroclimática del munucipio de Candelaria "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 23,
                    CapaMunicipioId = 29,
                    TituloSeccion1Mcipio = "",
                    InformacionMapa = "Comportamiento de la humedad en el suelo para el cultivo en épocas sin anomalías climáticas o cuando hay pronósticos de épocas secas (por ejemplo El Niño) o épocas lluviosas (fenómeno de La Niña). Se observa la ubicación de los suelos más aptos, moderados y no aptos para el cultivo, así como la probabilidad de que ocurra un exceso de agua, un déficit de agua o una humedad de suelo adecuada en etapas fenológicas sensibles de cultivo. ",
                    NombreMapa = "Escenarios agroclimáticos del municipio de Candelaria para el cultivo de tomate "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 24,
                    CapaMunicipioId = 35,
                    TituloSeccion1Mcipio = "Índice ndvi ",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 25,
                    CapaMunicipioId = 41,
                    TituloSeccion1Mcipio = "Susceptibilidad a inundaciones",
                    InformacionMapa = "El mapa señala los cuerpos de agua que bajo un fenómeno El Niño o La Niña han tenido aumento o disminución en su área en comparación con la línea base cartográfica trazada bajo condiciones normales, la cual corresponde a la oficial a escala 1:25.000 del IGAC. La dinámica de los cuerpos de agua es analizada a partir de índices espectrales calculados sobre imágenes de satélite de media – alta resolución espacial. ",
                    NombreMapa = ""
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 26,
                    CapaMunicipioId = 18,
                    TituloSeccion1Mcipio = "Estaciones",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal. ",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico"
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 27,
                    CapaMunicipioId = 24,
                    TituloSeccion1Mcipio = "Aptitud agroclimática ",
                    InformacionMapa = "En el mapa se pueden observar las zonas en donde el suelo y el agua disponible en el suelo son adecuadas o son de alto riesgo para establecer cultivos. Estos mapas permiten identificar el riesgo ya sea por limitaciones de suelo o por riesgo de excesos o deficiencias hídricas severas para el cultivo.. ",
                    NombreMapa = "Aptitud agroclimática del munucipio de Santa Lucía "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 28,
                    CapaMunicipioId = 30,
                    TituloSeccion1Mcipio = "",
                    InformacionMapa = "Comportamiento de la humedad en el suelo para el cultivo en épocas sin anomalías climáticas o cuando hay pronósticos de épocas secas (por ejemplo El Niño) o épocas lluviosas (fenómeno de La Niña). Se observa la ubicación de los suelos más aptos, moderados y no aptos para el cultivo, así como la probabilidad de que ocurra un exceso de agua, un déficit de agua o una humedad de suelo adecuada en etapas fenológicas sensibles de cultivo. ",
                    NombreMapa = "Escenarios agroclimáticos del municipio de Santa Lucía para el cultivo de tomate "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 29,
                    CapaMunicipioId = 36,
                    TituloSeccion1Mcipio = "Índice ndvi ",
                    InformacionMapa = "El mapa indica la pérdida o estabilidad del índice normalizado de vegetación (NDVI), bajo un fenómeno El Niño en un período determinado y el obtenido en el mismo período bajo una condición normal",
                    NombreMapa = "Mapa de Anomalías del Índice Normalizado de Vegetación (NDVI) del departamento del Atlántico "
                });
                contexto.InformacionAmpliaSec1Mcipio.Add(new InformacionAmpliaSec1Mcipio
                {
                    InformacionAmpliaSec1McipioId = 30,
                    CapaMunicipioId = 42,
                    TituloSeccion1Mcipio = "Susceptibilidad a inundaciones",
                    InformacionMapa = "El mapa señala los cuerpos de agua que bajo un fenómeno El Niño o La Niña han tenido aumento o disminución en su área en comparación con la línea base cartográfica trazada bajo condiciones normales, la cual corresponde a la oficial a escala 1:25.000 del IGAC. La dinámica de los cuerpos de agua es analizada a partir de índices espectrales calculados sobre imágenes de satélite de media – alta resolución espacial. ",
                    NombreMapa = ""
                }); 





                contexto.SaveChanges();


                //seccion2:
                contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 1,
                    CapaMunicipioId = 37,
                   NombreCortoSeccion2 = "Expans",
                   TituloSeccion2Mcipio = "Expansion",
                    Descripcion ="Señala el aumento del área de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 2,
                    CapaMunicipioId = 37,
                   NombreCortoSeccion2 = "Contracc",
                   TituloSeccion2Mcipio = "Contracción",
                    Descripcion ="Señala la disminución de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 3,
                    CapaMunicipioId = 25,
                   NombreCortoSeccion2 = "Leyenda",
                   TituloSeccion2Mcipio = "Leyenda",
                    Descripcion ="Escenarios"
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 4,
                    CapaMunicipioId = 38,
                   NombreCortoSeccion2 = "Expans",
                   TituloSeccion2Mcipio = "Expansion",
                    Descripcion ="Señala el aumento del área de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 5,
                    CapaMunicipioId = 38,
                   NombreCortoSeccion2 = "Contracc",
                   TituloSeccion2Mcipio = "Contracción",
                    Descripcion ="Señala la disminución de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 6,
                    CapaMunicipioId = 26,
                   NombreCortoSeccion2 = "Leyenda",
                   TituloSeccion2Mcipio = "Leyenda",
                    Descripcion ="Escenarios"
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 7,
                    CapaMunicipioId = 39,
                   NombreCortoSeccion2 = "Expans",
                   TituloSeccion2Mcipio = "Expansion",
                    Descripcion ="Señala el aumento del área de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 8,
                    CapaMunicipioId = 39,
                   NombreCortoSeccion2 = "Contracc",
                   TituloSeccion2Mcipio = "Contracción",
                    Descripcion ="Señala la disminución de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 9,
                    CapaMunicipioId = 27,
                   NombreCortoSeccion2 = "Leyenda",
                   TituloSeccion2Mcipio = "Leyenda",
                    Descripcion ="Escenarios"
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 10,
                    CapaMunicipioId = 40,
                   NombreCortoSeccion2 = "Expans",
                   TituloSeccion2Mcipio = "Expansion",
                    Descripcion ="Señala el aumento del área de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 11,
                    CapaMunicipioId = 40,
                   NombreCortoSeccion2 = "Contracc",
                   TituloSeccion2Mcipio = "Contracción",
                    Descripcion ="Señala la disminución de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 12,
                    CapaMunicipioId = 28,
                   NombreCortoSeccion2 = "Leyenda",
                   TituloSeccion2Mcipio = "Leyenda",
                    Descripcion ="Escenarios"
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 13,
                    CapaMunicipioId = 41,
                   NombreCortoSeccion2 = "Expans",
                   TituloSeccion2Mcipio = "Expansion",
                    Descripcion ="Señala el aumento del área de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 14,
                    CapaMunicipioId = 41,
                   NombreCortoSeccion2 = "Contracc",
                   TituloSeccion2Mcipio = "Contracción",
                    Descripcion ="Señala la disminución de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 15,
                    CapaMunicipioId = 29,
                   NombreCortoSeccion2 = "Leyenda",
                   TituloSeccion2Mcipio = "Leyenda",
                    Descripcion ="Escenarios"
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 16,
                    CapaMunicipioId = 42,
                   NombreCortoSeccion2 = "Expans",
                   TituloSeccion2Mcipio = "Expansion",
                    Descripcion ="Señala el aumento del área de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 17,
                    CapaMunicipioId = 42,
                   NombreCortoSeccion2 = "Contracc",
                   TituloSeccion2Mcipio = "Contracción",
                    Descripcion ="Señala la disminución de los cuerpos de agua. "
              }); 
contexto.InformacionAmpliaSec2Mcipio.Add(new InformacionAmpliaSec2Mcipio
                {
                   InformacionAmpliaSec2McipioId = 18,
                    CapaMunicipioId = 30,
                   NombreCortoSeccion2 = "Leyenda",
                   TituloSeccion2Mcipio = "Leyenda",
                    Descripcion ="Escenarios"
              }); 




                contexto.SaveChanges();

            }
        }
    }
}
