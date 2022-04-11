using System.Threading.Tasks;

using Application.Interface;
using Domain.Client;
using Domain.Entities;

namespace Application.Service
{
    public class CepService : ICepService
    {
        private ICepClient _clientCep;
        public CepService(ICepClient clientCep) { _clientCep = clientCep; }
        public async Task<Cep> ConsultarEndereco(string cep) { return await _clientCep.GetCepClient(cep); }
    }
}
