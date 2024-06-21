using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// La información general sobre un ensamblado SistemaExperto controla mediante el siguiente 
// conjunto de atributos. Cambie los valores de estos atributos para modificar la información
// asociada con un ensamblado.
[assembly: AssemblyTitle("SistemaExperto")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SistemaExperto")]
[assembly: AssemblyCopyright("Copyright ©  2023")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Si ComVisible SistemaExperto establece en False, los componentes COM no verán los 
// tipos de este ensamblado. Si necesita obtener acceso a un tipo de este ensamblado desde 
// COM, establezca el atributo ComVisible en True en este tipo.
[assembly: ComVisible(false)]

// El siguiente GUID sirve como ID de typelib si este proyecto SistemaExperto expone a COM
[assembly: Guid("c9833c11-24f2-492a-8d5d-3a6769d2594e")]

// La información de versión de un ensamblado consta de los siguientes cuatro valores:
//
//      Versión principal
//      Versión secundaria 
//      Número de compilación
//      Revisión
//
// Puede especificar todos los valores o usar los valores predeterminados de número de compilación y de revisión 
// mediante el carácter '*', como SistemaExperto muestra a continuación:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
//Configuración de log
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config", Watch = true)]