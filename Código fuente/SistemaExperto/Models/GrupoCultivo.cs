using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class GrupoCultivo
    {
        //Código del grupo cultivo
        [Key]
        [DisplayName("Código")]
        public int GrupoCultivoId { get; set; }

        //Nombre o identificador del cultivo
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        //Llamado desde la tabla de etapagrupo
        public virtual ICollection<EtapaGrupo> EtapaGrupo { get; set; }

        //Llamado desde la tabla de Cultivos
        public virtual ICollection<Cultivo> Cultivo { get; set; }
    }
}