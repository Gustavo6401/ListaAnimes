using AutoMapper;
using Dominio.DTOs;
using Dominio.Interfaces.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteUnitario.Mock.RepositoryMock;

namespace TesteUnitario.Infra.Services
{
    [TestClass]
    public class AnimeServicesTest
    {
        // Esse teste vai verificar a integração entre a classe services e repository.
        // Se não fosse essa MERDA eu iria procurar o erro até não aguentar mais.
        Mapper Mapper { get; }
        AnimeRepositoryMock RepositoryMock = new AnimeRepositoryMock();

        [TestMethod]
        public async Task AdicionarAnime()
        {
            AnimeDTO anime = new AnimeDTO(4, "Bleach", 366, "Concluído", 366);

            // Testa a Integração entre as classes 
            IAnimeServices services = new AnimeServices(Mapper, RepositoryMock);
            await services.Create(anime);

            // Testa se a DTO está fazendo seu trabalho direito. Que é exatamente transformar os dados em classes diferentes.
            Anime resposta = RepositoryMock.GetById(anime.Id).Result;

            Assert.AreEqual(anime.Nome, resposta.Nome);
            Assert.AreEqual(anime.NumeroEpisodios, resposta.NumeroEpisodios);
            Assert.AreEqual(anime.Status, resposta.Status);
            Assert.AreEqual(anime.EpQueParei, resposta.EpQueParei);
        }

        [TestMethod]
        public async Task ConsultarPorId()
        {
            // Id 1 - Naruto Shippuden
            IAnimeServices services = new AnimeServices(Mapper, RepositoryMock);
            AnimeDTO dto = await services.GetById(1);

            Assert.AreEqual(dto.Id, 1);
            Assert.AreEqual(dto.Nome, "Naruto Shippuden");
            Assert.AreEqual(dto.EpQueParei, 80);
            Assert.AreEqual(dto.NumeroEpisodios, 500);
            Assert.AreEqual(dto.Status, "Assistindo");
            Assert.AreEqual(dto.PorcentagemConcluida, 16);
        }

        [TestMethod]
        public async Task ConsultarPorNome()
        {
            IAnimeServices services = new AnimeServices(Mapper, RepositoryMock);
            AnimeDTO dto = await services.GetByName("Naruto Shippuden");

            Assert.AreEqual(dto.Id, 1);
            Assert.AreEqual(dto.Nome, "Naruto Shippuden");
            Assert.AreEqual(dto.EpQueParei, 80);
            Assert.AreEqual(dto.NumeroEpisodios, 500);
            Assert.AreEqual(dto.Status, "Assistindo");
            Assert.AreEqual(dto.PorcentagemConcluida, 16);
        }

        [TestMethod]
        public async Task ListarTodos()
        {
            IAnimeServices services = new AnimeServices(Mapper, RepositoryMock);
            IList<AnimeDTO> lista = await services.GetAll();

            Assert.AreEqual(lista.ElementAt(0).Id, 1);
            Assert.AreEqual(lista.ElementAt(0).Nome, "Naruto Shippuden");
            Assert.AreEqual(lista.ElementAt(0).EpQueParei, 80);
            Assert.AreEqual(lista.ElementAt(0).NumeroEpisodios, 500);
            Assert.AreEqual(lista.ElementAt(0).Status, "Assistindo");
            Assert.AreEqual(lista.ElementAt(0).PorcentagemConcluida, 16);
        }

        [TestMethod]
        public async Task Modificar()
        {
            IAnimeServices services = new AnimeServices(Mapper, RepositoryMock);
            await services.Update(new AnimeDTO(3, "Bleach", 366, "Assistido", 366));

            AnimeDTO anime = await services.GetById(3);

            Assert.AreEqual(anime.Id, 3);
            Assert.AreEqual(anime.Nome, "Bleach");
            Assert.AreEqual(anime.NumeroEpisodios, 366);
            Assert.AreEqual(anime.Status, "Assistido");
            Assert.AreEqual(anime.EpQueParei, 366);
            Assert.AreEqual(anime.PorcentagemConcluida, 100);
        }

        [TestMethod]
        public async Task Remover()
        {
            IAnimeServices services = new AnimeServices(Mapper, RepositoryMock);
            await services.Delete(2);

            AnimeDTO anime = await services.GetById(2);

            Assert.IsNull(anime);
        }
    }
}
