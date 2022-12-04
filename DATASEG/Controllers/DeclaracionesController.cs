using DATASEG.Models;
using DATASEG.Models.Declaraciones.DeclaracionCompleta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace DATASEG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeclaracionesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public DeclaracionesController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        [HttpGet("cEstados")]
        public IEnumerable<cEstadosModel> GetcEstados()
        {
            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s1/";
            ruta = "C:/insumos/s1/";
            string[] subdirectoryEntries = Directory.GetDirectories(ruta);
            List<cEstadosModel> listEstados = new List<cEstadosModel>();
            cEstadosModel estados;
            foreach (string subdirectory in subdirectoryEntries)
            {
                estados = new cEstadosModel()
                {
                    Entidad = subdirectory.Substring(subdirectory.IndexOf("s1/") + 3),
                };

                listEstados.Add(estados);
            }

            return listEstados;
        }

        [HttpGet("{rango}")]
        public IEnumerable<DeclaracionCompleta> GetDeclaraciones(int rango)
        {
            List<DeclaracionesModel> Declaraciones = new List<DeclaracionesModel>();
            List<DeclaracionesModel> DeclaracionesList = new List<DeclaracionesModel>();
            List<DeclaracionCompleta> DeclaracionCompleta = new List<DeclaracionCompleta>();

            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s1/";
            ruta = "C:/insumos/s1/";
            string[] subdirectoryEntries = Directory.GetDirectories(ruta);
            foreach (string subdirectory in subdirectoryEntries)
            {
                var estado = subdirectory.Substring(subdirectory.IndexOf("s1/") + 3);
                string rutaEntidad = $"{_webHostEnvironment.ContentRootPath}/insumos/s1/{estado}";

                rutaEntidad = $"C:/insumos/s1/{estado}";
                string[] fileEntries = Directory.GetFiles(rutaEntidad);

                foreach (string fileName in fileEntries)
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        Declaraciones = JsonConvert.DeserializeObject<List<DeclaracionesModel>>(reader.ReadToEnd());
                    }

                    DeclaracionesList.AddRange(Declaraciones);

                    if (DeclaracionesList.Count >= rango)
                        break;
                }
                var DeclaracionesRango = DeclaracionesList.Take(rango);

                var declaracionCompleta = new DeclaracionCompleta();
                declaracionCompleta.estado = estado;
                declaracionCompleta.declaracionesModels = DeclaracionesRango;

                DeclaracionCompleta.Add(declaracionCompleta);
            }
            return DeclaracionCompleta;
        }
        
        [HttpGet("{estado}/{rango}")]
        public IEnumerable<DeclaracionesModel> GetDeclaracionesEstado(string estado, int rango)
        {
            List<DeclaracionesModel> Declaraciones = new List<DeclaracionesModel>();
            List<DeclaracionesModel> DeclaracionesList = new List<DeclaracionesModel>();

            //var distribucion = getDistribucionJSON(estado, rango);

            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s1/{estado}";
            ruta = $"C:/insumos/s1/{estado}";
            string[] fileEntries = Directory.GetFiles(ruta);

            foreach (string fileName in fileEntries)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Declaraciones = JsonConvert.DeserializeObject<List<DeclaracionesModel>>(reader.ReadToEnd());
                }

                DeclaracionesList.AddRange(Declaraciones);

                if (DeclaracionesList.Count >= rango)
                    break;
            }

            var DeclaracionesRango = DeclaracionesList.Take(rango);

            return DeclaracionesRango;
        }

        private object getDistribucionJSON(string estado, int rango)
        {
            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s1/{estado}";
            string[] fileEntries = Directory.GetFiles(ruta);

            int cantidadArchivos = fileEntries.Count();
            decimal distribucion = Convert.ToDecimal((decimal)rango / (decimal)cantidadArchivos);

            int distribucionRedonda = Convert.ToInt32(Math.Round(distribucion, 1, MidpointRounding.AwayFromZero));
            int sumaDistribucion = distribucionRedonda * (cantidadArchivos - 1);

            int restanteDistribucion = rango - sumaDistribucion;
            return null;
        }


    }
}
