using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class SueloProductividad
    { //Código del SueloProductividad
        [Key]
        [DisplayName("Código")]
        public int SueloProductividadId { get; set; }
       
       
        [DisplayName("C.C (capacidad campo)")]
        [Required(ErrorMessage = "Es necesario definir el % de Capacidad Campo del Suelo donde se encuentre el cultivo C.C")]
        public double CC { get; set; }

        [DisplayName("C.C Menor")]
        [Required(ErrorMessage = "Es necesario definir el % de Capacidad Campo mínimo")]
        public double CCMenor { get; set; }

        [DisplayName("C.C Mayor")]
        [Required(ErrorMessage = "Es necesario definir el % de Capacidad Campo máximo")]
        public double CCMayor { get; set; }

        [DisplayName("PMP (punto marchitez permanente)")]
        [Required(ErrorMessage = "Es necesario definir el Punto de Marchitez Permanente PMP")]
        public double PMP { get; set; }

        [DisplayName("PMP Menor")]
        [Required(ErrorMessage = "Es necesario definir el Punto de Marchitez Permanente PMP mínimo")]
        public double PMPMenor { get; set; }

        [DisplayName("PMP Mayor")]
        [Required(ErrorMessage = "Es necesario definir el Punto de Marchitez Permanente PMP máximo")]
        public double PMPMayor { get; set; }

        [DisplayName("Da (densidad aparente)")]
        [Required(ErrorMessage = "Es necesario definir la densidad aparente Da")]
        public double Da { get; set; }

        [DisplayName("Da Menor")]
        [Required(ErrorMessage = "Es necesario definir la densidad aparente Da mínima")]
        public double DaMenor { get; set; }

        [DisplayName("Da Mayor")]
        [Required(ErrorMessage = "Es necesario definir la densidad aparente Da máxima")]
        public double DaMayor { get; set; }

        
        [DisplayName("Suelo")]
        [Required(ErrorMessage = "Es necesario definir un tipo de suelo")]
        public int TipoSueloId { get; set; }

        //Lave a TipoSuelo
        public virtual TipoSuelo TipoSuelo { get; set; }
    }
}