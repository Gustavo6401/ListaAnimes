using Dominio.DTOs;
using Infraestrutura.RequisitarAPI.API;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteUnitario.Requisicao
{
    [TestClass]
    public class AnimeRequisicao
    {
        // Testa se a API está rodando corretamente com a resposta correta.
        [TestMethod]
        public async Task Create()
        {
            AnimeDTO anime = new AnimeDTO(0, "Naruto Shippuden", 500, "Assistindo", 90);

            AnimeAPI api = new AnimeAPI();
            HttpResponseMessage response = await api.CadastrarAnime(anime);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Index()
        {
            AnimeAPI api = new AnimeAPI();
            List<AnimeDTO> response = await api.ConsultarTodosAnimes();

            Assert.IsNotNull(response);
        }
    }
}
