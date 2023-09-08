using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class EstacionMensual
    {
        //Código para el registro de datos de estación mensual
        [Key]
        [DisplayName("Código")]
        public int EstacionMensualId { get; set; }

        //Código de la estación, para la relación con la tabla Estacion
        [DisplayName("Estación")]
        [Required(ErrorMessage = "Es necesario definir una estación")]
        public int EstacionId { get; set; }

        //Fecha de registro de datos en formato (AAAA,MM,DD)
        [DisplayName("Fecha")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{dd/MM/yyyy}")]
        [Required(ErrorMessage = "Es necesario definir un mes")]
        public DateTime Fecha { get; set; }

        [DisplayName("Temp. mínima")]
        //[Required(ErrorMessage = "Es necesario definir la temperatura mínima")]
        public double? Tmin { get; set; }

        [DisplayName("Temp. máxima")]
        //[Required(ErrorMessage = "Es necesario definir la temperatura máxima")]
        public double? Tmax { get; set; }

        [DisplayName("Precipitación")]
        [Required(ErrorMessage = "Es necesario definir el valor de la precipitación")]
        public double Precipitacion { get; set; }

        [DisplayName("Viento")]
        //[Required(ErrorMessage = "Es necesario definir el valor del viento")]
        public double? Viento { get; set; }

        //--
        [DisplayName("Temp. mínima Real")]
        public double? TminReal { get; set; }

        [DisplayName("Temp. máxima Real")]
        public double? TmaxReal { get; set; }

        [DisplayName("Ppt Real")]
        public double? PrecipitacionReal { get; set; }

        [DisplayName("Viento Real")]
        public double? VientoReal { get; set; }
        //--

        [DisplayName("ETo")]
        public double? ETo { get; set; }

        [DisplayName("Evapotranspiración Real")]
        public double? EToReal { get; set; }

        [DisplayName("Valor de SPI")]
        public double SPI { get; set; }

        [DisplayName("Valor SPI Real")]
        public double? SPIReal { get; set; }

        [DisplayName("Precipitación <<debajo>>")]
        public double pptDebajo { get; set; }

        [DisplayName("Precipitación <<dentro>>")]
        public double pptDentro { get; set; }

        [DisplayName("Precipitación <<sobre>>")]
        public double pptSobre { get; set; }
               
        [DisplayName("Probabilidad ppt")]
        public double ProbabilidadPpt { get; set; }

        [DisplayName("Id Categoria ppt")]
        public int CategoriaProbabilidadId { get; set; }

        [DisplayName("Precipitación mínima")]
        public double ValorMinimo { get; set; }

        [DisplayName("Precipitación máxima")]
        public double ValorMaximo { get; set; }

        //#CambioPalmerSPI
        [DisplayName("Existe predicción")]
        public bool ExistePrediccion { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Tmax <= Tmin)
            {
                yield return new ValidationResult
                 ("La temperatura máxima no puede ser meno o igual a la mínima", new[] { "Tmax", "Tmin" });
            }
        }

        public virtual Estacion Estacion { get; set; }
        ////Llaves a
        //public virtual CategoriaProbabilidad CategoriaProbabilidad { get; set; }
    }
}