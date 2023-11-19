using Dominio.DTOs;
using Newtonsoft.Json;

namespace API.RequisicaoInterna
{
    /// <summary>
    /// Fiz essa classe com o objetivo de fazer uma requisição à própria API.
    /// </summary>
    public class AnimeRequisition
    {
        public async Task<AnimeDTO> GetById(int id)
        {
            HttpClient client = new HttpClient();

            string json = await client.GetStringAsync($"https://localhost:7010/api/Anime/{id}");

            return JsonConvert.DeserializeObject<AnimeDTO>(json);
        } 
    }
}
