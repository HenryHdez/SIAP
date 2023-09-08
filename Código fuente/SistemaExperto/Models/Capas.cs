using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace SistemaExperto.Models
{
    public class Capas
    {
        [Key]
        [DisplayName("Código")]
        public int CapaId { get; set; }

        [DisplayName("Nombre de capa")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string NombreCaracterizacion { get; set; }

        [DisplayName("Nombre identificador de capa")]
        [Required(ErrorMessage = "Es necesario definir un nombre corto")]
        public string IdentificadorCaracterizacion { get; set; }

        [DisplayName("Concepto")]
        public string Concepto { get; set; }

        [DisplayName("Ruta de imagen de la capa")]
        public string RutaImagen { get; set; }

    }
}