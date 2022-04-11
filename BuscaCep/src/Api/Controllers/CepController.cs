using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Application.Interface;
using Domain.Entities;
using System.Net;

namespace Api.Controllers
{
    public class CepController : Controller
    {
        private readonly ICepService _service;

        public CepController(ICepService service) { _service = service; }

        [HttpGet("v1/BuscaCep/{cep}")]
        [ProducesResponseType(typeof(Cep), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErroResponse), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ErroResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ObterEndereco(string cep)
        {
            try
            {
                Cep endereco = null;
                string cepValido = cep.Replace("-", "");
                endereco = await _service.ConsultarEndereco(cepValido);

                if (endereco == null)
                    return NotFound(new ErroResponse() { Codigo = 400, Excecao = "Erro ao consultar o CEP", Erro = $"Nenhum endereço encontrado para o CEP: {cep}" });

                return StatusCode(200, endereco);
            }
            catch (Exception e)
            {
                return BadRequest(new ErroResponse() { Codigo = 400, Excecao = e.StackTrace, Erro = e.Message });
            }
        }
    }
}
