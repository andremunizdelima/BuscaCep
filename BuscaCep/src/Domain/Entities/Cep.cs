using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Cep
    {
        [JsonProperty("Cep")] public string cep { get; set; }
        [JsonProperty("Logradouro")] public string logradouro { get; set; }
        [JsonProperty("Complemento")] public string complemento { get; set; }
        [JsonProperty("Bairro")] public string bairro { get; set; }
        [JsonProperty("Localidade")] public string localidade { get; set; }
        [JsonProperty("Uf")] public string uf { get; set; }
        [JsonProperty("Ibge")] public string ibge { get; set; }
        [JsonProperty("Gia")] public string gia { get; set; }
        [JsonProperty("Siafi")] public string siafi { get; set; }
    }
}