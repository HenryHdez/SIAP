// Decompiled with JetBrains decompiler
// Type: SistemaExperto.Models.Termino
// Assembly: SEMapa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D3DE640-B680-4304-B937-7AD421129A2A
// Assembly location: C:\inetpub\wwwroot\Semapa\bin\SEMapa.dll

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaExperto.Models
{
  public class Termino
  {
    [Key]
    [DisplayName("Código")]
    public int TerminoId { get; set; }

    [DisplayName("Nombre término")]
    [Required(ErrorMessage = "Es necesario definir un nombre")]
    public string NombreTermino { get; set; }

    [DisplayName("Código")]
    [Required(ErrorMessage = "Es necesario definir un código")]
    public string Codigo { get; set; }

    [DisplayName("Definición breve")]
    [Required(ErrorMessage = "Es necesario escribir una definición breve")]
    public string DefinicionBreve { get; set; }

    [DisplayName("Definición amplia")]
    public string DefinicionAmplia { get; set; }

    [DisplayName("Fuente")]
    public string Fuente { get; set; }

    [DisplayName("Información de apoyo")]
    public string InformacionApoyo { get; set; }

    [DisplayName("Etiquetas")]
    public string Etiquetas { get; set; }

    [DisplayName("Orden")]
    public int? Orden { get; set; }

    [DisplayName("Codigo padre del término")]
    [ForeignKey("CodigoPadre")]
    public int? CodigoPadreId { get; set; }

    [DisplayName("Código del video")]
    [Required(ErrorMessage = "Es necesario tener una ruta de video")]
    public string Video { get; set; }

    [DisplayName("Coordenadas imagen")]
    [Required(ErrorMessage = "Es necesario tener las coordenadas de la imagen ")]
    public string CoordenadasImagen { get; set; }

    public virtual Termino CodigoPadre { get; set; }
  }
}
