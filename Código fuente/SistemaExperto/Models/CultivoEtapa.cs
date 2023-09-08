using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class CultivoEtapa
    {
        [Key]
        [DisplayName("Código")]
        public int CultivoEtapaId { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Orden")]
        public int Orden { get; set; }

        [DisplayName("Clase")]
        public string Clase { get; set; }

        [DisplayName("Ícono")]
        public string RutaIcono { get; set; }

        //Llamado desde la tabla de tipo de etapa de cultivo
        public virtual ICollection<CultivoTipoEtapa> CultivoTipoEtapa { get; set; }

        //Llamado desde la tabla de etapagrupo
        public virtual ICollection<EtapaGrupo> EtapaGrupo { get; set; }
    }
}