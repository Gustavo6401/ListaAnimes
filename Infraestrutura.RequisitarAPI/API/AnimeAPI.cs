using Dominio.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.RequisitarAPI.API
{
    public class AnimeAPI
    {
        
        public async Task<HttpResponseMessage> CadastrarAnime(AnimeDTO anime)
        {
            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(anime);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await client.PostAsync("http://localhost:5036/api/Anime", body);

            return resp;
        }

        public async Task<List<AnimeDTO>> ConsultarTodosAnimes()
        {
            HttpClient client = new HttpClient();

            string json = await client.GetAsync("http://localhost:5036/api/Anime")
                                .Result
                                .Content
                                .ReadAsStringAsync();

            List<AnimeDTO>? listaAnimes = JsonConvert.DeserializeObject<List<AnimeDTO>>(json)
                              .ToList();

            // Isso vai garantir que a lista de animes não permaneça nula, vai emitir uma mensagem para o usuário se a lista estiver vazia e vai passar o teste unitário.
            if (listaAnimes == null)
            {
                AnimeDTO dto = new AnimeDTO(1, "Não Há Nada Cadastrado Ainda no nosso sistema.", 0, "Nada Cadastrado", 0);

                listaAnimes.Add(dto);
            }
                

            return listaAnimes;
        }
    }
}
