namespace DATASEG.Models.Contrataciones
{
    public class ContratacionesModel
    {
        public string id { get; set; }
        public DateTime fechaCaptura { get; set; }
        public string ejercicioFiscal { get; set; }
        public Ramo ramo { get; set; }
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public InstitucionDependencia institucionDependencia { get; set; }
        public Puesto puesto { get; set; }
        public IList<TipoArea> tipoArea { get; set; }
        public IList<NivelResponsabilidad> nivelResponsabilidad { get; set; }
        public IList<TipoProcedimiento> tipoProcedimiento { get; set; }
        public SuperiorInmediato superiorInmediato { get; set; }
        public string observaciones { get; set; }
    }

    public class Ramo
    {
        public int clave { get; set; }
        public string valor { get; set; }
    }

    public class InstitucionDependencia
    {
        public string nombre { get; set; }
        public string siglas { get; set; }
        public string clave { get; set; }
    }

    public class Puesto
    {
        public string nombre { get; set; }
        public string nivel { get; set; }
    }

    public class TipoArea
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }

    public class NivelResponsabilidad
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }

    public class TipoProcedimiento
    {
        public int clave { get; set; }
        public string valor { get; set; }
    }

    public class SuperiorInmediato
    {
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Puesto puesto { get; set; }
    }

}
