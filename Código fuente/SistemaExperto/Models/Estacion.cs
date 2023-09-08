using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Estacion
    {
        //Código de la estación
        [Key]
        [DisplayName("Código")]
        public int EstacionId { get; set; }

        //Nombre o identificador de la estación
        [DisplayName("Estación")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        //Código IDEAM de la estación
        [DisplayName("Código IDEAM")]
        public string CodigoIdeam { get; set; }

        //Coordenada geográfica de posición norte - sur
        [DisplayName("Latitud (°)")]
        [Required(ErrorMessage = "Es necesario definir una latitud")]
        public double Latitud { get; set; }

        //Coordenada geográfica de posición oriente - occidente
        [DisplayName("Longitud (°)")]
        [Required(ErrorMessage = "Es necesario definir una longitud")]
        public double Longitud { get; set; }

        //Altura sobre el nivel del mar
        [DisplayName("Altitud (msnm)")]
        [Required(ErrorMessage = "Es necesario definir la altura")]
        public double Altitud { get; set; }

        [DisplayName("Ruta imagen")]
        public string RutaImagen { get; set; }

        [DisplayName("Tipo estación")]
        public int EstacionTipoId { get; set; }

        
        //Llamado desde la tabla de datos de estación
        public virtual ICollection<EstacionMensual> DatosEstacion { get; set; }
        //Llamado desde la tabla de relación entre zona y estación
        public virtual ICollection<ZonaEstacion> ZonaEstacion { get; set; }
        //Llamado desde la tabla de relación entre municipio y estación
        public virtual ICollection<MunicipioEstacion> MunicipioEstacion { get; set; }

        //Llamado desde la tabla de relación entre estacion y estacionConstantes
        public virtual ICollection<EstacionConstantes> EstacionConstantes { get; set; }

        //Llave a la tabla de tipo de estación
        public virtual EstacionTipo EstacionTipo { get; set; }



        //Llamado desde la tabla de Estacion -productividad
        public virtual ICollection<EstacionProductividad> EstacionProductividad { get; set; }

    }
}