using API.Controllers;
using Dominio.DTOs;
using Dominio.Interfaces.Repositories;
using Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using TesteUnitario.Mock.RepositoryMock;
using TesteUnitario.Mock.Servicos;

namespace TesteUnitario.API.Controllers
{
    [TestClass]
    public class AnimeControllerTest
    {
        private IAnimeRepository repository = new AnimeRepositoryMock();

        [TestMethod]
        public async Task AdicionarAnime()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeDTO anime = new AnimeDTO(4, "Bleach", 366, "Concluído", 366);

            AnimeController controller = new AnimeController(services);
            var status = await controller.Create(anime);

            Assert.IsInstanceOfType<OkResult>(status);
        }

        [TestMethod]
        public async Task AdicionarAnimeNulo()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeDTO anime = null;

            AnimeController controller = new AnimeController(services);
            var status = await controller.Create(anime);

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }

        [TestMethod]
        public async Task AdicionarAnimeNotFound()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeDTO anime = null;

            AnimeController controller = new AnimeController(services);
            var status = await controller.Create(anime);

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }

        [TestMethod]
        public async Task ConsultarPorId()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeController controller = new AnimeController(services);
            var status = await controller.GetById(1);

            Assert.IsInstanceOfType<OkObjectResult>(status);
        }

        [TestMethod]
        public async Task ConsultarPorIdAnimeNulo()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            // Ids Existentes: 1, 2, 3
            AnimeController controller = new AnimeController(services);
            var status = await controller.GetById(4);

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }

        [TestMethod]
        public async Task ConsultarPorNome()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            // Nomes Existentes: Naruto Shippuden, Dragon Ball Z, One Piece
            AnimeController controller = new AnimeController(services);
            var status = await controller.GetByName("Naruto Shippuden");

            Assert.IsInstanceOfType<OkObjectResult>(status);
        }

        [TestMethod]
        public async Task ConsultarPorNomeAnimeNulo()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            // Nomes Existentes: Naruto Shippuden, Dragon Ball Z, One Piece
            AnimeController controller = new AnimeController(services);
            var status = await controller.GetByName("Bleach");

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }
        
        [TestMethod]
        public async Task ListarTodos()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeController controller = new AnimeController(services);
            var status = await controller.Index();

            Assert.IsInstanceOfType<OkObjectResult>(status);
        }

        [TestMethod]
        public async Task ModificarDados()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeDTO anime = new AnimeDTO(1, "Bleach", 366, "Concluído", 366);

            AnimeController controller = new AnimeController(services);
            var status = await controller.Update(1, anime);

            Assert.IsInstanceOfType<OkResult>(status);
        }

        [TestMethod]
        public async Task ModificarDadosIdsDiferentes()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeDTO anime = new AnimeDTO(4, "Bleach", 366, "Concluído", 366);

            AnimeController controller = new AnimeController(services);
            var status = await controller.Update(1, anime);

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }

        [TestMethod]
        public async Task ModificarDadosIdInexistente()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeDTO anime = new AnimeDTO(4, "Bleach", 366, "Concluído", 366);

            AnimeController controller = new AnimeController(services);
            var status = await controller.Update(4, anime);

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }

        [TestMethod]
        public async Task ModificarDadosDominioNulo()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeDTO anime = null;

            AnimeController controller = new AnimeController(services);
            var status = await controller.Update(1, anime);

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }

        [TestMethod]
        public async Task RemoverDados()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeController controller = new AnimeController(services);
            IActionResult status = await controller.Delete(3);

            Assert.IsInstanceOfType<OkResult>(status);
        }

        [TestMethod]
        public async Task RemoverDadosIdInvalido()
        {
            IAnimeServices services = new AnimeServicesMock(repository);

            AnimeController controller = new AnimeController(services);
            IActionResult status = await controller.Delete(4);

            Assert.IsInstanceOfType<NotFoundResult>(status);
        }
    }
}
