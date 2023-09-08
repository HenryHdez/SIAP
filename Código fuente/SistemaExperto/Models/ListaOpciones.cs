using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SistemaExperto.Models
{
    public class ListaOpciones
    {
        [Key]
        [DisplayName("Código Regla")]
        public int ListaOpcionesId{ get; set; }
        
        [DisplayName("Código Cultivo")]
        public int CultivoId { get; set; }

        [DisplayName("Código municipio")]
        public int MunicipioId { get; set; }

        [DisplayName("Código TipoAccion")]
        public int TipoOfertaId { get; set; }

        [DisplayName("Código Condicion")]
        public int TipoPrediccionId { get; set; }

        [DisplayName("Código Opción")]
        public int OpcionTecnologicaId { get; set; }

        [DisplayName("Estado Desarrollo Cultivo")]
        public string EstadoDesarrolloCultivo { get; set; }
        
        [DisplayName("Indica si OT es Local ")]
        public bool IndicadorLocal { get; set; }

        //Llaves a
        public virtual Cultivo Cultivo { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual TipoOferta TipoOferta { get; set; }
        public virtual TipoPrediccion TipoPrediccion { get; set; }
        public virtual OpcionTecnologica OpcionTecnologica { get; set; }
       

    }
}