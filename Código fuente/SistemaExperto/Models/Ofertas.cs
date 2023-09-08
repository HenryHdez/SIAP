using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Ofertas
    {
        [Key]
        [DisplayName("Código")]
        public int OfertaId { get; set; }

        [DisplayName("Estado fenológico")]
        public int CultivoEtapaId { get; set; }

        [DisplayName("Tipo de predicción")]
        public int TipoPrediccionId { get; set; }

        [DisplayName("Cultivo")]
        public int CultivoId { get; set; }

        [DisplayName("Efecto")]
        public int EfectoId { get; set; }

        [DisplayName("Indica si es Local o Regional")]
        public bool IndicadorLocal { get; set; }

        //Llaves a
        public virtual CultivoEtapa CultivoEtapa { get; set; }
        public virtual TipoPrediccion TipoPrediccion { get; set; }
        public virtual Cultivo Cultivo { get; set; }
        public virtual Efectos Efectos { get; set; }

        //Llamado en
        //public virtual ICollection<Ofertas> Oferta { get; set; }
    }
}