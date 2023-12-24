using Dominio.DTOs;
using Infraestrutura.RequisitarAPI.API;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;

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

        [TestMethod]
        public async Task GetById()
        {
            AnimeAPI api = new AnimeAPI();
            AnimeDTO dbz = await api.ConsultarPorId(2);

            Assert.AreEqual(2, dbz.Id);
            Assert.AreEqual("Dragon Ball Z", dbz.Nome);
        }

        [TestMethod]
        public async Task GetByName()
        {
            AnimeAPI api = new AnimeAPI();
            List<AnimeDTO>? lista = await api.ConsultarPorNome("Bleach");

            Assert.AreEqual(3, lista.ElementAt(0).Id);
            Assert.AreEqual("Bleach", lista.ElementAt(0).Nome);
        }

        [TestMethod]
        public async Task Edit()
        {
            AnimeDTO anime = new AnimeDTO(2002, "One Piece", 1079, "Assistindo", 69);

            AnimeAPI api = new AnimeAPI();            
            HttpResponseMessage response = await api.AlterarDados(2002, anime);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public async Task Delete()
        {
            AnimeAPI api = new AnimeAPI();
            HttpResponseMessage response = await api.RemoverDados(2);

            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }
    }
}
