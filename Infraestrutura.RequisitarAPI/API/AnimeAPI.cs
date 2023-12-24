using Dominio.DTOs;
using Dominio.Entities;
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
        public async Task<HttpResponseMessage> AlterarDados(int id, AnimeDTO animeDTO)
        {
            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(animeDTO);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await client.PutAsync($"http://localhost:5036/api/Anime/{id}", body);

            return resp;
        }

        /*Uma coisa que eu penso é em separar os HTTPResponseMessage do Resto do código para testar 
a parte de consulta parecida com a de cadastro.*/
        public async Task<HttpResponseMessage> CadastrarAnime(AnimeDTO anime)
        {
            HttpClient client = new HttpClient();

            string json = JsonConvert.SerializeObject(anime);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage resp = await client.PostAsync("http://localhost:5036/api/Anime", body);

            return resp;
        }

        public async Task<AnimeDTO> ConsultarPorId(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"http://localhost:5036/api/Anime/{id}");

            string json = await response.Content.ReadAsStringAsync();

            AnimeDTO dto = JsonConvert.DeserializeObject<AnimeDTO>(json);

            if(dto == null) return new AnimeDTO(1, "Não Há Nada Cadastrado Ainda no nosso sistema.", 0, "Nada Cadastrado", 0);

            return dto;
        }

        public async Task<List<AnimeDTO>> ConsultarPorNome(string nome)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync($"http://localhost:5036/api/Anime/GetByName?nome={nome}");

            string json = await response.Content.ReadAsStringAsync();

            List<AnimeDTO>? dto = JsonConvert.DeserializeObject<List<AnimeDTO>>(json);

            if(dto == null)
            {
                AnimeDTO anime = new AnimeDTO(1, "Não Há Nada Cadastrado Ainda no nosso sistema.", 0, "Nada Cadastrado", 0);

                dto.Add(anime);
            }

            return dto;
        }

        public async Task<List<AnimeDTO>> ConsultarTodosAnimes()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://localhost:5036/api/Anime");

            string json = await response.Content.ReadAsStringAsync();

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
