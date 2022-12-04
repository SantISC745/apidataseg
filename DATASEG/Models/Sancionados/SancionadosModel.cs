namespace DATASEG.Models.Sancionados
{
    public class SancionadosModel
    {
        public string id { get; set; }
        public string? fechaCaptura { get; set; }
        public string expediente { get; set; }
        public InstitucionDependencia institucionDependencia { get; set; }
        public ServidorPublicoSancionado servidorPublicoSancionado { get; set; }
        public string autoridadSancionadora { get; set; }
        public TipoFalta tipoFalta { get; set; }
        public IList<TipoSancion> tipoSancion { get; set; }
        public string causaMotivoHechos { get; set; }
        public Resolucion resolucion { get; set; }
        public Multa multa { get; set; }
        public Inhabilitacion inhabilitacion { get; set; }
        public string observaciones { get; set; }
        public IList<Documento> documentos { get; set; }
    }
    public class InstitucionDependencia
    {
        public string nombre { get; set; }
        public string siglas { get; set; }
        public string clave { get; set; }
    }

    public class Genero
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }

    public class ServidorPublicoSancionado
    {
        public string nombres { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public Genero genero { get; set; }
        public string puesto { get; set; }
    }

    public class TipoFalta
    {
        public string clave { get; set; }
        public string valor { get; set; }
        public string descripcion { get; set; }
    }

    public class TipoSancion
    {
        public string clave { get; set; }
        public string valor { get; set; }
        public string descripcion { get; set; }
    }

    public class Resolucion
    {
        public string url { get; set; }
        public string fechaResolucion { get; set; }
    }

    public class Moneda
    {
        public string clave { get; set; }
        public string valor { get; set; }
    }

    public class Multa
    {
        public int monto { get; set; }
        public Moneda moneda { get; set; }
    }

    public class Inhabilitacion
    {
        public string plazo { get; set; }
    }

    public class Documento
    {
        public object id { get; set; }
        public object titulo { get; set; }
        public object descripcion { get; set; }
        public object url { get; set; }
        public object fecha { get; set; }
    }

}
