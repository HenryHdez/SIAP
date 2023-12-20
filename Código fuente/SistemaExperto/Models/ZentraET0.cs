namespace SistemaExperto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class ZentraET0
    {
        [Key]
        public int Id { get; set; }
        public string Datetime { get; set; }
        public string ETo { get; set; }
    }
}