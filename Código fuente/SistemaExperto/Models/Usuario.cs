using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using CompareAttribute = System.Web.Mvc.CompareAttribute;

namespace SistemaExperto.Models
{
    public class Usuario
    {
        [Key]
        [DisplayName("Código del usuario")]
        public int UsuarioId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Es necesario definir un nombre")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        public string Apellido { get; set; }

        [DisplayName("Tipo identificación")]
        [Required(ErrorMessage = "Es necesario definir un tipo de identificación")]
        public int TipoIdentificacionId { get; set; }

        [DisplayName("Número de identificación")]
        [Required(ErrorMessage = "Es necesario definir un número de identificación")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "El número de identificación no es válido")]
        public string Cedula { get; set; }

        [DisplayName("Usuario")]
        [Required(ErrorMessage = "Es necesario definir un usuario")]
        public string LoginUsuario { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Es necesario definir una contraseña")]
        public string Contrasena { get; set; }

        [DisplayName("Correo")]
        [RegularExpression("^[A-Za-z0-9](([_\\.\\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\\.\\-\u200C\u200B]?[a-zA-Z0-9]+)*)\\.([A-Za-z]{2,})$", ErrorMessage = "El correo ingresado no es válido")]
        [Required(ErrorMessage = "Es necesario definir un correo")]
        public string Correo { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "Es necesario definir una dirección")]
        public string Direccion { get; set; }

        [DisplayName("Celular")]
        [Required(ErrorMessage = "Es necesario definir un número celular")]
        public string Celular { get; set; }

        [DisplayName("Teléfono")]
        public string Telefono { get; set; }

        [DisplayName("Institución")]
        [Required(ErrorMessage = "Es necesario definir una institución")]
        public string Institucion { get; set; }

        [DisplayName("Departamento")]
        public int? DepartamentoId { get; set; }

        [DisplayName("País")]
        [Required(ErrorMessage = "Es necesario definir un país")]
        public int PaisId { get; set; }

        [DisplayName("Último ingreso")]
        public DateTime UltimoLogin { get; set; }

        [DisplayName("Actividad")]
        [Required(ErrorMessage = "Es necesario definir una actividad")]
        public int ActividadId { get; set; }

        [DisplayName("¿Usuario interno?")]
        [Required(ErrorMessage = "Es necesario definir un tipo de usuario (externo/interno)")]
        public bool TipoUsuario { get; set; }

        [DisplayName("Administrador")]
        public bool Administrador { get; set; }

        [DisplayName("¿Activo?")]
        public bool Activo { get; set; }

        [DisplayName("Perfil")]
        public int PerfilId { get; set; }

        [DisplayName("Nombres completos")]
        public string NombreCompleto => string.Format("{0} {1}", (object)this.Nombre, (object)this.Apellido);

        public virtual Departamento Departamento { get; set; }

        public virtual Pais Pais { get; set; }

        public virtual Perfil Perfil { get; set; }

        public virtual Actividad Actividad { get; set; }

        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
    }
}

/*
namespace SistemaExperto.Models
{
public class Usuario
{
    [Key]
    [DisplayName("Código del usuario")]
    public int UsuarioId { get; set; }

    [DisplayName("Nombre")]
    [Required(ErrorMessage = "Es necesario definir un nombre")]
    public string Nombre { get; set; }

    [DisplayName("Apellido")]
    public string Apellido { get; set; }

    [DisplayName("TipoIdentificacion")]
    public string TipoIdentificacionId { get; set; }

    [DisplayName("LoginUsuario")]
    public string LoginUsuario { get; set; }

    [DisplayName("Direccion")]
    public string Direccion { get; set; }

    [DisplayName("Celular")]
    public string Celular { get; set; }

    [DisplayName("Telefono")]
    public string Telefono { get; set; }

    [DisplayName("TipoUsuario")]
    public bool TipoUsuario { get; set; }

    [Required(ErrorMessage = "Es necesario definir un número de identificación")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "El número de identificación no es válido")]
    public string Cedula { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Contrasena")]
    [Required(ErrorMessage = "Es necesario definir una contraseña")]
    public string Contrasena { get; set; }

    [DataType(DataType.Password)]
    [DisplayName("Confirmar contraseña")]
    [Required(ErrorMessage = "Es necesario definir una contraseña")]
    [Compare("Contrasena", ErrorMessage = "Las contraseñas deben coincidir")]
    public string ConfirmarClave { get; set; }

    //[DataType(DataType.EmailAddress)]
    [DisplayName("Correo")]
    [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "El correo ingresado no es válido")]
    [Required(ErrorMessage = "Es necesario definir un correo")]
    public string Correo { get; set; }

    //[DisplayName("Acividad")]
    //[Required(ErrorMessage = "Es necesario definir una actividad")]
    //public string Actividad { get; set; }

    [DisplayName("Institución")]
    [Required(ErrorMessage = "Es necesario definir una institución")]
    public string Institucion { get; set; }

    [DisplayName("Departamento")]
    public int? DepartamentoId { get; set; }

    [DisplayName("País")]
    [Required(ErrorMessage = "Es necesario definir un país")]
    public int PaisId { get; set; }

    [DisplayName("Último ingreso")]
    public DateTime UltimoLogin { get; set; }

    [DisplayName("Actividad")]
    [Required(ErrorMessage = "Es necesario definir una actividad")]
    public int ActividadId { get; set; }

    [DisplayName("Administrador")]
    public bool Administrador { get; set; }

    [DisplayName("¿Activo?")]
    public bool Activo { get; set; }

    //Llave a la tabla de departamentos
    public virtual Departamento Departamento { get; set; }

    //Llave a la tabla de país
    public virtual Pais Pais { get; set; }


    //Llave a la tabla de actividad
    public virtual Actividad Actividad { get; set; }

    // [DisplayName("Fecha de último ingreso")]
    // public DateTime UltimoLogin { get; set; }
}
}
*/
