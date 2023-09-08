using System.Collections.Generic;
using SistemaExperto.Models;


    public class FichaOpcionViewModel
    {
        public Municipio Municipio { get; set; }

        public Cultivo Cultivo { get; set; }

        public OpcionTecnologica OpcionTecnologica { get; set; }
        public ListaOpciones ListaOpciones { get; set; }
        //public IEnumerable<ListaOpciones> ListaOpciones { get; set; }

        public TipoPrediccion TipoPrediccion { get; set; }

        public TipoOferta TipoOferta { get; set; }
        //public FichaOpcion FichaOpcion { get; set; }
        public IEnumerable<FichaOpcion> FichaOpcion { get; set; }

        //public AreaTematica AreaTematica { get; set; }
    }
