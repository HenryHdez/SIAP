using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Departamento
    {
        [Key]
        [DisplayName("Código")]
        public int DepartamentoId { get; set; }

        [DisplayName("Código Dane")]
        public string CodigoDane { get; set; }
        
        [DisplayName("Departamento")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        [DisplayName("Coordenadas")]
        public string Coordenadas { get; set; }

        //Llamado desde la tabla de municipios
        public virtual ICollection<Municipio> Municipio { get; set; }
        //Llamado desde la tabla de conglomerados
        public virtual ICollection<Conglomerado> Conglomerado { get; set; }

        //Llamado desde la tabla de cultivos departamento -productividad
        public virtual ICollection<CultivoDepartamento> CultivoDepartamento { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

    }
}