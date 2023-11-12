using Infraestrutura.Repositories;
using Dominio.Interfaces.Repositories;
using Infraestrutura.Context;
using Dominio.Entities;

namespace TesteUnitario.Infra.Repositories;

[TestClass]
public class AnimeRepositoryTest
{
    AnimeContext context = new AnimeContext();   

    // Odiei fazer testes unitários em bases de dados, um teste afeta os outros.
    [TestMethod]
    public async Task AdicionarAnime()
    {
        var anime = new Anime
        {
            Id = 0,
            Nome = "Naruto Shippuden",
            EpQueParei = 71,
            NumeroEpisodios = 500,
            Status = "Assistindo"
        };

        IAnimeRepository repository = new AnimeRepository(context);
        await repository.Create(anime);

        var resultado = await repository.GetByName("Naruto Shippuden");

        Assert.AreEqual(anime.Nome, resultado.Nome);
        Assert.AreEqual(anime.EpQueParei, resultado.EpQueParei);
        Assert.AreEqual(anime.NumeroEpisodios, resultado.NumeroEpisodios);
        Assert.AreEqual(anime.Status, resultado.Status);
    }

    [TestMethod]
    // Para rodar esse teste unitário, é necessário excluir os dados do banco de dados
    public async Task ListarTodosAnimes()
    {
        var naruto = new Anime
        {
            Id = 0,
            Nome = "Naruto Shippuden",
            EpQueParei = 71,
            NumeroEpisodios = 500,
            Status = "Assistindo"
        };

        var dbz = new Anime
        {
            Id = 0,
            Nome = "Dragon Ball Z",
            EpQueParei = 82,
            NumeroEpisodios = 291,
            Status = "Assistindo"
        };

        IAnimeRepository repository = new AnimeRepository(context);
        await repository.Create(dbz);
        await repository.Create(naruto);

        var resultado = await repository.GetAll();

        Assert.AreEqual(naruto.Nome, resultado.ElementAt(0).Nome);
        Assert.AreEqual(naruto.EpQueParei, resultado.ElementAt(0).EpQueParei);
        Assert.AreEqual(naruto.NumeroEpisodios, resultado.ElementAt(0).NumeroEpisodios);
        Assert.AreEqual(naruto.Status, resultado.ElementAt(0).Status);
        Assert.AreEqual(dbz.Nome, resultado.ElementAt(1).Nome);
        Assert.AreEqual(dbz.EpQueParei, resultado.ElementAt(1).EpQueParei);
        Assert.AreEqual(dbz.NumeroEpisodios, resultado.ElementAt(1).NumeroEpisodios);
        Assert.AreEqual(dbz.Status, resultado.ElementAt(1).Status);
    }

    [TestMethod]
    public async Task ConsultarPorId()
    {
        var anime = new Anime
        {
            Id = 0,
            Nome = "Naruto Shippuden",
            EpQueParei = 71,
            NumeroEpisodios = 500,
            Status = "Assistindo"
        };

        IAnimeRepository repository = new AnimeRepository(context);
        // Isso estava interferindo na parte de listar todos.
        // await repository.Create(anime);

        var resultado = await repository.GetById(1);

        Assert.AreEqual(anime.Nome, resultado.Nome);
        Assert.AreEqual(anime.EpQueParei, resultado.EpQueParei);
        Assert.AreEqual(anime.NumeroEpisodios, resultado.NumeroEpisodios);
        Assert.AreEqual(anime.Status, resultado.Status);
    }

    [TestMethod]
    public async Task ConsultarPorNome()
    {
        IAnimeRepository repository = new AnimeRepository(context);

        Anime anime = await repository.GetByName("Naruto Shippuden");

        Assert.AreEqual(anime.Nome, "Naruto Shippuden");
        Assert.AreEqual(anime.EpQueParei, 71);
        Assert.AreEqual(anime.NumeroEpisodios, 500);
        Assert.AreEqual(anime.Status, "Assistindo");
    }

    [TestMethod]
    public async Task ModificarAnime()
    {
        IAnimeRepository repository = new AnimeRepository(context);

        Anime anime = new Anime
        {
            Id = 1,
            Nome = "Dragon Ball Z",
            EpQueParei = 82,
            NumeroEpisodios = 291,
            Status = "Assistindo"
        };

        await repository.Update(anime);

        var resultado = await repository.GetById(1);

        Assert.AreEqual(resultado.Nome, "Dragon Ball Z");
        Assert.AreEqual(resultado.EpQueParei, 82);
        Assert.AreEqual(resultado.NumeroEpisodios, 291);
        Assert.AreEqual(resultado.Status, "Assistindo");
    }

    [TestMethod]
    public async Task RemoverAnime()
    {
        IAnimeRepository repository = new AnimeRepository(context);

        await repository.Delete(1);

        var resultado = await repository.GetById(1);

        Assert.IsNull(resultado);
    }
}
