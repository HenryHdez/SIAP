using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class CultivoTipoEtapa
    {
        [Key]
        [DisplayName("Código")]
        public int CultivoTipoEtapaId { get ;set; }

        [DisplayName("Duracion")]
        [Required(ErrorMessage = "Es necesario definir una duracion")]
        public int Duracion { get; set; }

        [DisplayName("Mes de inicio")]
        [Required(ErrorMessage = "Es necesario definir un mes de inicio")]
        public int MesInicio { get; set; }

        [DisplayName("Ciclo")]
        [Required(ErrorMessage = "Es necesario definir un cultivo")]
        public int CultivoCicloId { get; set; }

        [DisplayName("Etapa de cultivo")]
        [Required(ErrorMessage = "Es necesario definir una etapa")]
        public int CultivoEtapaId { get; set; }

        //Llave a la tabla de ciclo del cultivo
        public virtual CultivoCiclo CultivoCiclo { get; set; }
        //Llave a la tabla de etapa del cultivo
        public virtual CultivoEtapa CultivoEtapa { get; set; }
    }
}