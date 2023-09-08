using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Zona
    {
        //Código de la zona
        [Key]
        [DisplayName("Código")]
        public int ZonaId { get; set; }

        //Nombre o identificador de la zona
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        //Código del municipio, para hacer la relación con la tabla Municipio
        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir un Departamento")]
        public int MunicipioId { get; set; }

        //Código del cultivo, para hacer la relación con la tabla Cultivo
        [DisplayName("Tipo de cultivo")]
        [Required(ErrorMessage = "Es necesario definir una zona")]
        public int CultivoId { get; set; }

        //Código del cultivo, para hacer la relación con la tabla Cultivo
        [DisplayName("Tipo de suelo")]
        [Required(ErrorMessage = "Es necesario definir un tipo de suelo")]
        public int TipoSueloId { get; set; }

        //Coordenada geográfica de posición norte - sur
        [DisplayName("Latitud (°)")]
        [Required(ErrorMessage = "Es necesario definir una latitud")]
        public double Latitud { get; set; }

        //Coordenada geográfica de posición oriente - occidente
        [DisplayName("Longitud (°)")]
        [Required(ErrorMessage = "Es necesario definir una longitud")]
        public double Longitud { get; set; }

        [DisplayName("Tasa máxima de infiltración (mm/día)")]
        public double TasaMax { get; set; }

        //Capacidad de campo
        [DisplayName("Capacidad de campo (m3/m3)")]
        [Required(ErrorMessage = "Es necesario definir la capacidad de campo")]
        public double CC { get; set; }

        //Punto de marchitez permanente
        [DisplayName("Punto de marchitez permanente (m3/m3)")]
        [Required(ErrorMessage = "Es necesario definir el punto de marchitez permanente")]
        public double PMP { get; set; }

        public virtual ICollection<ZonaMensual> ZonaMensual { get; set; }
        public virtual ICollection<ZonaEstacion> ZonaEstacion { get; set; }

        //Llave a Cultivo
        public virtual Cultivo Cultivo { get; set; }

        //Lave a Departamento
        public virtual Municipio Municipio { get; set; }

        //Lave a TipoSuelo
        public virtual TipoSuelo TipoSuelo { get; set; }
    }
}