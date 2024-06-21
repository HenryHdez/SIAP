using System.Collections.Generic;
using SistemaExperto.Models;


    public class ListaOpcionesViewModel
    {
        public Municipio Municipio { get; set; }

       // public Acciones Acciones { get; set; }
        
        //public IEnumerable<Municipio> Municipio { get; set; }

        //public IEnumerable<Cultivo> Cultivo { get; set; }
        public Cultivo Cultivo { get; set; }


        public IEnumerable<TipoOferta> TipoOferta { get; set; }

        //public IEnumerable<TipoPrediccion> TipoPrediccion { get; set; }
        public TipoPrediccion TipoPrediccion { get; set; }

        public IEnumerable<OpcionTecnologica> OpcionTecnologica { get; set; }
        public IEnumerable<ListaOpciones> ListaOpciones { get; set; }
    }
