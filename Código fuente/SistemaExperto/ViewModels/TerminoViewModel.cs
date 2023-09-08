using System.Collections.Generic;
using SistemaExperto.Models;

//namespace SistemaExperto.ViewModels
//{
    public class TerminoViewModel
    {
        public IEnumerable<Termino> TerminosPadre { get; set; }
        public IEnumerable<Termino> TerminosHijo { get; set; }
        public IEnumerable<Termino> TerminosNieto { get; set; }
    }
//}