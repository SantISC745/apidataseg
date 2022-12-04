namespace DATASEG.Models.Declaraciones.DeclaracionCompleta
{

    public class DeclaracionCompleta
    {
        public string? estado { get; set; }
        public IEnumerable<DeclaracionesModel> declaracionesModels { get; set; }
    }

    public class DeclaracionesModel
    {
        public string id { get; set; }
        public Metadata metadata { get; set; }
        public Declaracion declaracion { get; set; }
    }
    public class Metadata
    {
        public DateTime actualizacion { get; set; }
        public string institucion { get; set; }
        public string tipo { get; set; }
        public bool declaracionCompleta { get; set; }
        public bool actualizacionConflictoInteres { get; set; }
    }

    public class Rfc
    {
    }

    public class CorreoElectronico
    {
        public string institucional { get; set; }
    }

    public class Telefono
    {
    }

    public class SituacionPersonalEstadoCivil
    {
    }

    public class RegimenMatrimonial
    {
    }

    public class DatosGenerales
    {
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Rfc rfc { get; set; }
        public CorreoElectronico correoElectronico { get; set; }
        public Telefono telefono { get; set; }
        public SituacionPersonalEstadoCivil situacionPersonalEstadoCivil { get; set; }
        public RegimenMatrimonial regimenMatrimonial { get; set; }
    }

    public class MunicipioAlcaldia
    {
    }

    public class EntidadFederativa
    {
    }

    public class DomicilioMexico
    {
        public MunicipioAlcaldia municipioAlcaldia { get; set; }
        public EntidadFederativa entidadFederativa { get; set; }
    }

    public class DomicilioExtranjero
    {
    }

    public class DomicilioDeclarante
    {
        public DomicilioMexico domicilioMexico { get; set; }
        public DomicilioExtranjero domicilioExtranjero { get; set; }
    }

    public class Nivel
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }

    public class InstitucionEducativa
    {
        public string nombre { get; set; }
        public string ubicacion { get; set; }
    }

    public class Escolaridad
    {
        public string tipoOperacion { get; set; }
        public Nivel nivel { get; set; }
        public InstitucionEducativa institucionEducativa { get; set; }
        public string carreraAreaConocimiento { get; set; }
        public string estatus { get; set; }
        public string documentoObtenido { get; set; }
        public string fechaObtencion { get; set; }
    }

    public class DatosCurricularesDeclarante
    {
        public IList<Escolaridad> escolaridad { get; set; }
    }

    public class TelefonoOficina
    {
        public string telefono { get; set; }
        public string extension { get; set; }
    }

    public class DatosEmpleoCargoComision
    {
        public string tipoOperacion { get; set; }
        public string nivelOrdenGobierno { get; set; }
        public string ambitoPublico { get; set; }
        public string nombreEntePublico { get; set; }
        public string areaAdscripcion { get; set; }
        public string empleoCargoComision { get; set; }
        public bool contratadoPorHonorarios { get; set; }
        public string nivelEmpleoCargoComision { get; set; }
        public string funcionPrincipal { get; set; }
        public string fechaTomaPosesion { get; set; }
        public TelefonoOficina telefonoOficina { get; set; }
        public DomicilioMexico domicilioMexico { get; set; }
        public DomicilioExtranjero domicilioExtranjero { get; set; }
        public bool cuentaConOtroCargoPublico { get; set; }
        public IList<object> otroEmpleoCargoComision { get; set; }
    }

    public class ExperienciaLaboral
    {
        public bool ninguno { get; set; }
        public IList<object> experiencia { get; set; }
    }

    public class ActividadLaboral
    {
    }

    public class SalarioMensualNeto
    {
    }

    public class ActividadLaboralSectorPublico
    {
        public SalarioMensualNeto salarioMensualNeto { get; set; }
    }

    public class Sector
    {
    }

    public class ActividadLaboralSectorPrivadoOtro
    {
        public Sector sector { get; set; }
        public SalarioMensualNeto salarioMensualNeto { get; set; }
    }

    public class DatosPareja
    {
        public bool ninguno { get; set; }
        public DomicilioMexico domicilioMexico { get; set; }
        public DomicilioExtranjero domicilioExtranjero { get; set; }
        public ActividadLaboral actividadLaboral { get; set; }
        public ActividadLaboralSectorPublico actividadLaboralSectorPublico { get; set; }
        public ActividadLaboralSectorPrivadoOtro actividadLaboralSectorPrivadoOtro { get; set; }
    }

    public class DatosDependienteEconomico
    {
        public bool ninguno { get; set; }
        public IList<object> dependienteEconomico { get; set; }
    }

    public class RemuneracionAnualCargoPublico
    {
        public int valor { get; set; }
        public string moneda { get; set; }
    }

    public class OtrosIngresosAnualesTotal
    {
        public int valor { get; set; }
        public string moneda { get; set; }
    }

    public class RemuneracionTotal
    {
        public int valor { get; set; }
        public string moneda { get; set; }
    }

    public class Remuneracion
    {
        public int valor { get; set; }
        public string moneda { get; set; }
    }

    public class Actividades
    {
        public Remuneracion remuneracion { get; set; }
        public string nombreRazonSocial { get; set; }
        public string tipoNegocio { get; set; }
        public TipoInstrumento tipoInstrumento { get; set; }
    }

    public class ActividadIndustrialComercialEmpresarial
    {
        public RemuneracionTotal remuneracionTotal { get; set; }
        public IList<Actividades> actividades { get; set; }
    }

    public class TipoInstrumento
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }


    public class ActividadFinanciera
    {
        public RemuneracionTotal remuneracionTotal { get; set; }
        public IList<Actividades> actividades { get; set; }
    }

    public class Servicio
    {
        public Remuneracion remuneracion { get; set; }
        public string tipoServicio { get; set; }
    }

    public class ServiciosProfesionales
    {
        public RemuneracionTotal remuneracionTotal { get; set; }
        public IList<Servicio> servicios { get; set; }
    }

    public class Bienes
    {
        public Remuneracion remuneracion { get; set; }
        public string tipoBienEnajenado { get; set; }
    }

    public class EnajenacionBienes
    {
        public RemuneracionTotal remuneracionTotal { get; set; }
        public IList<Bienes> bienes { get; set; }
    }

    public class Ingreso
    {
        public Remuneracion remuneracion { get; set; }
        public string tipoIngreso { get; set; }
    }

    public class OtrosIngresos
    {
        public RemuneracionTotal remuneracionTotal { get; set; }
        public IList<Ingreso> ingresos { get; set; }
    }

    public class IngresoAnualNetoDeclarante
    {
        public int valor { get; set; }
        public string moneda { get; set; }
    }

    public class IngresoAnualNetoParejaDependiente
    {
    }

    public class TotalIngresosAnualesNetos
    {
        public int valor { get; set; }
        public string moneda { get; set; }
    }

    public class Ingresos
    {
        public RemuneracionAnualCargoPublico remuneracionAnualCargoPublico { get; set; }
        public OtrosIngresosAnualesTotal otrosIngresosAnualesTotal { get; set; }
        public ActividadIndustrialComercialEmpresarial actividadIndustrialComercialEmpresarial { get; set; }
        public ActividadFinanciera actividadFinanciera { get; set; }
        public ServiciosProfesionales serviciosProfesionales { get; set; }
        public EnajenacionBienes enajenacionBienes { get; set; }
        public OtrosIngresos otrosIngresos { get; set; }
        public IngresoAnualNetoDeclarante ingresoAnualNetoDeclarante { get; set; }
        public IngresoAnualNetoParejaDependiente ingresoAnualNetoParejaDependiente { get; set; }
        public TotalIngresosAnualesNetos totalIngresosAnualesNetos { get; set; }
    }

    public class BienesInmuebles
    {
        public bool ninguno { get; set; }
        public IList<object> bienInmueble { get; set; }
    }

    public class Vehiculos
    {
        public bool ninguno { get; set; }
        public IList<object> vehiculo { get; set; }
    }

    public class BienesMuebles
    {
        public bool ninguno { get; set; }
        public IList<object> bienMueble { get; set; }
    }

    public class Inversiones
    {
        public bool ninguno { get; set; }
        public IList<object> inversion { get; set; }
    }

    public class Adeudos
    {
        public bool ninguno { get; set; }
        public IList<object> adeudo { get; set; }
    }

    public class PrestamoOComodato
    {
        public bool ninguno { get; set; }
        public IList<object> prestamo { get; set; }
    }

    public class SituacionPatrimonial
    {
        public DatosGenerales datosGenerales { get; set; }
        public DomicilioDeclarante domicilioDeclarante { get; set; }
        public DatosCurricularesDeclarante datosCurricularesDeclarante { get; set; }
        public DatosEmpleoCargoComision datosEmpleoCargoComision { get; set; }
        public ExperienciaLaboral experienciaLaboral { get; set; }
        public DatosPareja datosPareja { get; set; }
        public DatosDependienteEconomico datosDependienteEconomico { get; set; }
        public Ingresos ingresos { get; set; }
        public BienesInmuebles bienesInmuebles { get; set; }
        public Vehiculos vehiculos { get; set; }
        public BienesMuebles bienesMuebles { get; set; }
        public Inversiones inversiones { get; set; }
        public Adeudos adeudos { get; set; }
        public PrestamoOComodato prestamoOComodato { get; set; }
    }

    public class Participacion
    {
        public bool ninguno { get; set; }
        public IList<object> participacion { get; set; }
    }

    public class ParticipacionTomaDecisiones
    {
        public bool ninguno { get; set; }
        public IList<object> participacion { get; set; }
    }

    public class Apoyos
    {
        public bool ninguno { get; set; }
        public IList<object> apoyo { get; set; }
    }

    public class Representacion
    {
        public bool ninguno { get; set; }
        public IList<object> representacion { get; set; }
    }

    public class ClientesPrincipales
    {
        public bool ninguno { get; set; }
        public IList<object> cliente { get; set; }
    }

    public class BeneficiosPrivados
    {
        public bool ninguno { get; set; }
        public IList<object> beneficio { get; set; }
    }

    public class Fideicomisos
    {
        public bool ninguno { get; set; }
        public IList<object> fideicomiso { get; set; }
    }

    public class Interes
    {
        public Participacion participacion { get; set; }
        public ParticipacionTomaDecisiones participacionTomaDecisiones { get; set; }
        public Apoyos apoyos { get; set; }
        public Representacion representacion { get; set; }
        public ClientesPrincipales clientesPrincipales { get; set; }
        public BeneficiosPrivados beneficiosPrivados { get; set; }
        public Fideicomisos fideicomisos { get; set; }
    }

    public class Declaracion
    {
        public SituacionPatrimonial situacionPatrimonial { get; set; }
        public Interes interes { get; set; }
    }
}

