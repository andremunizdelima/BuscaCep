using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Application.Interface;
using Domain.Entities;

namespace Api.Controllers
{
    public class CepController : Controller
    {
        private readonly ICepService _service;

        public CepController(ICepService service) { _service = service; }
        
        [HttpGet("v1/BuscaCep")]
        public async Task<IActionResult> ObterEndereco(string cep)
        {
            try
            {
                Cep endereco = null;

                if (string.IsNullOrEmpty(cep) && cep.Length >= 3)
                    endereco = await _service.ConsultarEndereco(cep);

                if (endereco == null) return NotFound($"Nenhum endereço encontrado para o CEP: {cep}");

                return StatusCode(200, endereco);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
