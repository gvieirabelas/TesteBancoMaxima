using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RotasDeViagemAPI.Models;
using RotasDeViagemAPI.Service;

namespace RotasDeViagemAPI.Controllers
{
    [ApiController]
    [Route("v1/rotas")]
    public class RotaController : Controller
    {
        public RotaService service = new RotaService();
        [HttpPost]
        [Route("GetRoute")]
        public ActionResult<ResponseRoute> GetRoute([FromBody]RequestRoute request)
        {
            var arquivo = service.getArquivo(request.Location);
            if (!arquivo.Select(x => x.Origem).ToList().Contains(request.InitialRota.Origem) || !arquivo.Select(x => x.Destino).ToList().Contains(request.InitialRota.Destino))
                return new ResponseRoute()
                {
                    OrigemConcat = "Rota não encontrada",
                    Valor = 0
                };

            request.Rotas = arquivo;
            var retorno = service.FindBestWay(request.InitialRota,request.Rotas);
            return retorno;
        }
        [HttpPost]
        [Route("CreateNewRoute")]
        public ActionResult<string> CreateNewRoute([FromBody] RequestInsertRoute request)
        {
            var response = service.SetRoute(request);
            return response;
        }
    }
}