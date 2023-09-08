using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class VariablesHistoricas
    {
        [Key]
        [DisplayName("Código")]
        public int VariablesHistoricasId { get; set; }

        [DisplayName("Z")]
        public string Z { get; set; }

        [DisplayName("PX1")]
        public string PX1 { get; set; }

        [DisplayName("PX2")]
        public string PX2 { get; set; }

        [DisplayName("PX3")]
        public string PX3 { get; set; }

        [DisplayName("X")]
        public string X { get; set; }

        [DisplayName("Ze")]
        public string Ze { get; set; }

        [DisplayName("Uw")]
        public string Uw { get; set; }

        [DisplayName("Ud")]
        public string Ud { get; set; }
    }
}