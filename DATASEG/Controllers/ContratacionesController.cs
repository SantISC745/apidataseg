using DATASEG.Models;
using DATASEG.Models.Contrataciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DATASEG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratacionesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public ContratacionesController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        [HttpGet("cEstados")]
        public IEnumerable<cEstadosModel> GetcEstados()
        {
            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s2/";
            //ruta = "C:/insumos/s2/";
            string[] subdirectoryEntries = Directory.GetDirectories(ruta);
            List<cEstadosModel> listEstados = new List<cEstadosModel>();
            cEstadosModel estados;
            foreach (string subdirectory in subdirectoryEntries)
            {
                estados = new cEstadosModel()
                {
                    Entidad = subdirectory.Substring(subdirectory.IndexOf("s2/") + 3),
                };

                listEstados.Add(estados);
            }

            return listEstados;
        }

        [HttpGet("{estado}/{rango}")]
        public IEnumerable<ContratacionesModel> GetContrataciones(string estado, int rango)
        {
            List<ContratacionesModel> Contrataciones = new List<ContratacionesModel>();
            List<ContratacionesModel> ContratacionesList = new List<ContratacionesModel>();

            //var distribucion = getDistribucionJSON(estado, rango);

            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s2/{estado}";
            //ruta = $"C:/insumos/s2/{estado}";
            string[] fileEntries = Directory.GetFiles(ruta);

            foreach (string fileName in fileEntries)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Contrataciones = JsonConvert.DeserializeObject<List<ContratacionesModel>>(reader.ReadToEnd());
                }

                ContratacionesList.AddRange(Contrataciones);

                if (ContratacionesList.Count >= rango)
                    break;
            }

            var ContratacionesRango = ContratacionesList.Take(rango);

            return ContratacionesRango;
        }
    }
}
