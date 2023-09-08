using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class Municipio
    {
        [Key]
        [DisplayName("Código")]
        public int MunicipioId { get; set; }

        [DisplayName("Código Dane")]
        public string CodigoDane { get; set; }

        [DisplayName("Box")]
        public string Box { get; set; }

        [DisplayName("Municipio")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Imagen")]
        public string RutaImagen { get; set; }

        [DisplayName("Departamento")]
        [Required(ErrorMessage = "Es necesario definir un departamento")]
        public int DepartamentoId { get; set; }

        //Llave a la tabla de departamentos
        public virtual Departamento Departamento { get; set; }

        //Llamado desde la tabla de zonas
        public virtual ICollection<Zona> Zona { get; set; }
        //Llamado desde la tabla de relación entre municipio y estación
        public virtual ICollection<MunicipioEstacion> MunicipioEstacion { get; set; }
        //Llamado desde la tabla de ciclos de cultivo
        public virtual ICollection<CultivoCiclo> CultivoCiclo { get; set; }

        //Llamado desde la tabla de cultivosMunicipios
        public virtual ICollection<CultivoMunicipio> CultivoMunicipio { get; set; }
    }
}