using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace SistemaExperto.Models
{
    public class EtapaGrupo
    {
        //Código de etapa del grupo
        [Key]
        [DisplayName("Código")]
        public int EtapaGrupoId { get; set; }

        //Código del grupo
        [DisplayName("Código grupo")]
        [Required(ErrorMessage = "Es necesario definir un grupo de cultivo")]
        public int GrupoCultivoId { get; set; }

        [DisplayName("Código grupo")]
        [Required(ErrorMessage = "Es necesario definir una etapa")]
        public int CultivoEtapaId { get; set; }

        [DisplayName("Imagen")]
        [Required(ErrorMessage = "Es necesario definir una imagen")]
        public string RutaIcono { get; set; }

        //Llave a la tabla de grupos
        public virtual GrupoCultivo GrupoCultivo { get; set; }

        //Llave a la tabla de etapa
        public virtual CultivoEtapa CultivoEtapa { get; set; }
    }
}