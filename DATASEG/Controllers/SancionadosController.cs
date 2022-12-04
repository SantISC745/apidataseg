using DATASEG.Models;
using DATASEG.Models.Declaraciones.DeclaracionCompleta;
using DATASEG.Models.Sancionados.SancionadoCompleto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DATASEG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionadosController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;

        public SancionadosController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        [HttpGet("cEstados")]
        public IEnumerable<cEstadosModel> GetcEstados()
        {
            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s3/";
            ruta = "C:/insumos/s3/";
            string[] subdirectoryEntries = Directory.GetDirectories(ruta);
            List<cEstadosModel> listEstados = new List<cEstadosModel>();
            cEstadosModel estados;
            foreach (string subdirectory in subdirectoryEntries)
            {
                estados = new cEstadosModel()
                {
                    Entidad = subdirectory.Substring(subdirectory.IndexOf("s3/") + 3),
                };

                listEstados.Add(estados);
            }

            return listEstados;
        }

        [HttpGet("{rango}")]
        public IEnumerable<SancionadoCompletoModel> GetSancionados(int rango)
        {
            List<SancionadosModel> Declaraciones = new List<SancionadosModel>();
            List<SancionadosModel> DeclaracionesList = new List<SancionadosModel>();
            List<SancionadoCompletoModel> DeclaracionCompleta = new List<SancionadoCompletoModel>();

            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s3/";
            ruta = "C:/insumos/s3/";
            string[] subdirectoryEntries = Directory.GetDirectories(ruta);
            foreach (string subdirectory in subdirectoryEntries)
            {
                var estado = subdirectory.Substring(subdirectory.IndexOf("s3/") + 3);
                string rutaEntidad = $"{_webHostEnvironment.ContentRootPath}/insumos/s3/{estado}";

                rutaEntidad = $"C:/insumos/s3/{estado}";
                string[] fileEntries = Directory.GetFiles(rutaEntidad);

                foreach (string fileName in fileEntries)
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        Declaraciones = JsonConvert.DeserializeObject<List<SancionadosModel>>(reader.ReadToEnd());
                    }

                    DeclaracionesList.AddRange(Declaraciones);

                    if (DeclaracionesList.Count >= rango)
                        break;
                }
                var DeclaracionesRango = DeclaracionesList.Take(rango);

                var declaracionCompleta = new SancionadoCompletoModel();
                declaracionCompleta.estado = estado;
                declaracionCompleta.declaracionesModels = DeclaracionesRango;

                DeclaracionCompleta.Add(declaracionCompleta);
            }
            return DeclaracionCompleta;
        }

        [HttpGet("{estado}/{rango}")]
        public IEnumerable<SancionadosModel> GetSancionadosEstado(string estado, int rango)
        {
            List<SancionadosModel> Sancionados = new List<SancionadosModel>();
            List<SancionadosModel> SancionadosList = new List<SancionadosModel>();

            //var distribucion = getDistribucionJSON(estado, rango);

            string ruta = $"{_webHostEnvironment.ContentRootPath}/insumos/s3/{estado}";
            ruta = $"C:/insumos/s3/{estado}";
            string[] fileEntries = Directory.GetFiles(ruta);

            foreach (string fileName in fileEntries)
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Sancionados = JsonConvert.DeserializeObject<List<SancionadosModel>>(reader.ReadToEnd());
                }

                SancionadosList.AddRange(Sancionados);

                if (SancionadosList.Count >= rango)
                    break;
            }

            var SancionadosRango = SancionadosList.Take(rango);

            return SancionadosRango;
        }
    }


}
