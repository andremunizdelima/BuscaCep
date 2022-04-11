using Newtonsoft.Json;

namespace Domain.Entities
{
    public class ErroResponse
    {
        [JsonProperty("Codigo")] public int Codigo { get; set; }
        [JsonProperty("Erro")] public string Erro { get; set; }
        [JsonProperty("Excecao")] public string Excecao { get; set; }
    }
}
