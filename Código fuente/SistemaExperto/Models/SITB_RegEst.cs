namespace SistemaExperto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class SITB_RegEst
    {
        [Key]
        public string Fecha { get; set; }
        public string Estado_Est_1 { get; set; }
        public string Estado_Est_2 { get; set; }
        public string Estado_Est_3 { get; set; }
    }
}