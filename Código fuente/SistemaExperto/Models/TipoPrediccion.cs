using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class TipoPrediccion
    {
        [Key]
        [DisplayName("Código")]
        public int TipoPrediccionId { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Valor máximo")]
        public double Maximo { get; set; }

        [DisplayName("Valor mínimo")]
        public double Minimo { get; set; }

        //Llamado en
        public virtual ICollection<Ofertas> Oferta { get; set; }
    }
}