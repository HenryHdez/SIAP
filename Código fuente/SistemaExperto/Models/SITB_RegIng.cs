using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaExperto.Models
{
    public class SITB_RegIng
    {
        [Key]
        public int ID { get; set; }
        public string Fecha { get; set; }
        public string Modulo { get; set; }
        public string Submodulo { get; set; }
    }
}