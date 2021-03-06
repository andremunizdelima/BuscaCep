using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Domain.Client;
using Domain.Entities;

namespace Infra.Client
{
    public class CepClient : ICepClient
    {
        private IHttpClientFactory _httpClient { get; }

        public CepClient(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Cep> GetCepClient(string cep)
        {
            try
            {
                Cep endereco = null;
                string url = $"https://viacep.com.br/ws/{cep}/json/";
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = _httpClient.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var stream = await response.Content.ReadAsStreamAsync();
                    endereco = await JsonSerializer.DeserializeAsync<Cep>(stream);
                }
                else if (response.Content.ReadAsStringAsync().Result.Contains("true"))
                {
                    throw new Exception($"CEP {cep} inválido ou não existe");
                }

                return endereco;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
