using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace SistemaExperto.Models
{
    public class CultivoProductividad
    {
        //Código del cultivo
        [Key]
        [DisplayName("Código")]
        public int CultivoProductividadId { get; set; }

        [DisplayName("Cultivo")]
        [Required(ErrorMessage = "Es necesario definir un cultivo")]
        public int CultivoId { get; set; }

        [DisplayName("AMP (agotamiento máximo permisible)")]
        [Required(ErrorMessage = "Es necesario definir el Agotamiento máximo permisible AMP")]
        public double AMP { get; set; }

        //[DisplayName("CC inicial")]
        //[Required(ErrorMessage = "Es necesario definir el CC inicial")]
        //public double inicialCC { get; set; }

        [DisplayName("Ky Inicial (reducción de rendimiento inicial)")]
        [Required(ErrorMessage = "Es necesario definir el Coeficiente reducción de rendimiento inicial KyInicial")]
        public double KyInicial { get; set; }

        [DisplayName("Ky Desarrollo (reducción de rendimiento desarrollo)")]
        [Required(ErrorMessage = "Es necesario definir el Coeficiente reducción de rendimiento Desarrollo KyDesarrollo")]
        public double KyDesarrollo { get; set; }

        [DisplayName("Ky Medio (reducción de rendimiento medio)")]
        [Required(ErrorMessage = "Es necesario definir el Coeficiente reducción de rendimiento Medio KyMedio")]
        public double KyMedio { get; set; }

        [DisplayName("Ky Final (reducción de rendimiento final)")]
        [Required(ErrorMessage = "Es necesario definir el Coeficiente reducción de rendimiento Final KyFinal")]
        public double KyFinal { get; set; }

        //[DisplayName("Etapa inicial (días)")]       
        //public int EtapaInicial { get; set; }

        //[DisplayName("Etapa desarrollo (días)")]       
        //public int EtapaDesarrollo { get; set; }

        //[DisplayName("Etapa medio (días)")]
        //public int EtapaMedio { get; set; }

        //[DisplayName("Etapa final (días)")]       
        //public int EtapaFinal { get; set; }
   
        //Llave a la tabla de cultivo
        public virtual Cultivo Cultivo { get; set; }

        //Llamado desde la tabla de CultivoDepartamento
        public virtual ICollection<CultivoDepartamento> CultivoDepartamento { get; set; }

    }
}