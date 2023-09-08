using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class CultivoMunicipio
    {
        [Key]
        [DisplayName("Código")]
        public int CultivoMunicipioId { get; set; }

        [DisplayName("Cultivo")]
        [Required(ErrorMessage = "Es necesario definir un cultivo")]
        public int CultivoId { get; set; }

        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir un municipio")]
        public int MunicipioId { get; set; }

        [DisplayName("Ruta pdf práctica de manejo")]
        public string RutaPracticaManejo { get; set; }

        //Llave a la tabla de cultivo
        public virtual Cultivo Cultivo { get; set; }

        //Llave a la tabla de municipio
        public virtual Municipio Municipio { get; set; }
    }
}