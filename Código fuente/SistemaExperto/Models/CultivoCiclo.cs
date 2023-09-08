using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class CultivoCiclo
    {
        //Código del ciclo
        [Key]
        [DisplayName("Código")]
        public int CultivoCicloId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un cultivo")]
        public string Nombre { get; set; }

        [DisplayName("Cultivo")]
        [Required(ErrorMessage = "Es necesario definir un cultivo")]
        public int CultivoId { get; set; }

        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir un municipio")]
        public int MunicipioId { get; set; }

        [DisplayName("Condicion")]
        [Required(ErrorMessage = "Es necesario definir una condicion")]
        public int CondicionId { get; set; }

        //Llave a la tabla de departamentos
        public virtual Cultivo Cultivo { get; set; }
        //Llave a la tabla de municipios
        public virtual Municipio Municipio { get; set; }

        //Llave a la tabla de Condicion
        public virtual Condicion Condicion { get; set; }

        //Llamado desde la tabla de tipo de etapa de cultivo
        public virtual ICollection<CultivoTipoEtapa> CultivoTipoEtapa { get; set; }
    }
}