using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class FichaOpcion
    {
        [Key]
        [DisplayName("Código Ficha")]
        public int FichaOpcionId { get; set; }

        [DisplayName("Titulo")]
        public string Titulo { get; set; }

        [DisplayName("Información")]
        public string Informacion { get; set; }

        [DisplayName("Código Opcion")]
        public int ListaOpcionesId { get; set; }
       
        [DisplayName("Orden")]
        public int Orden { get; set; }

        //Llaves a
        //public virtual OpcionTecnologica OpcionTecnologica { get; set; }

        public virtual ListaOpciones ListaOpciones { get; set; }
    }
}