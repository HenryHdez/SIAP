using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Cultivo
    {
        //Código del cultivo
        [Key]
        [DisplayName("Código")]
        public int CultivoId { get; set; }

        //Nombre o identificador del cultivo
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        //Resumen de las características del cultivo
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        //Duración de la etapa inicial en días
        [DisplayName("Tiempo fase inicial (días)")]
        public int TiempoInicial { get; set; }

        //Duración de la etapa de desarrollo en días
        [DisplayName("Tiempo fase desarrollo (días)")]
        public int TiempoDesarrollo { get; set; }

        //Duración de la etapa media en días
        [DisplayName("Tiempo fase media (días)")]
        public int TiempoMedia { get; set; }

        //Duración de la etapa final en días
        [DisplayName("Tiempo fase final (días)")]
        public int TiempoFinal { get; set; }
        
        [DisplayName("Kc inicial")]
        public double KInicial { get; set; }

        [DisplayName("Kc media")]
        public double KMedia { get; set; }

        [DisplayName("Kc final")]
        public double KFinal { get; set; }

        [DisplayName("Agotamiento crítico inicial (%)")]
        public double ACInicial { get; set; }

        [DisplayName("Agotamiento crítico media (%)")]
        public double ACMedia { get; set; }

        [DisplayName("Agotamiento crítico final (%)")]
        public double ACFinal { get; set; }

        [DisplayName("Profundidad radicular mínima (Zr min) (m)")]
        public double ZrMin { get; set; }

        [DisplayName("Profundidad radicular máxima (Zr max) (m)")]
        public double ZrMax { get; set; }

        [DisplayName("Día Zr min. (días)")]
        public double JMin { get; set; }

        [DisplayName("Día Zr max. (días)")]
        public double JMax { get; set; }

        [DisplayName("Ícono")]
        public string RutaIcono { get; set; }

        [DisplayName("Imagen")]
        public string RutaImagen { get; set; }

        [DisplayName("Indicador")]
        public string IndicadorMapa { get; set; }

        [DisplayName("Grupo cultivo")]
        public int GrupoCultivoId { get; set; }

        //Código del tipo de cultivo, para hacer relación con la tabla TipoCultivo
        // [DisplayName("Tipo de cultivo")]
        //public int CultivoTipoId { get; set; }

        //Llave a la tabla de cultivos
        //public virtual CultivoTipo CultivoTipo { get; set; }  
        //Llave a la tabla de grupos
        public virtual GrupoCultivo GrupoCultivo { get; set; }
        public virtual ICollection<Zona> Zona { get; set; }
        //Llamado desde la tabla de ofertas
        public virtual ICollection<Ofertas> Ofertas { get; set; }
        //Llamado desde la tabla de ciclos
        public virtual ICollection<CultivoCiclo> CultivoCiclo { get; set; }

        //Llamado desde la tabla de cultivosProductividad
        public virtual ICollection<CultivoProductividad> CultivoProductividad { get; set; }

        //Llamado desde la tabla de cultivosMunicipios
        public virtual ICollection<CultivoMunicipio> CultivoMunicipio { get; set; }
    }
}