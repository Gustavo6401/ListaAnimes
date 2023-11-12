using Dominio.DTOs;

namespace TesteUnitario.Domain.DTOs
{
    [TestClass]
    public class AnimeDTOTest
    {
        [TestMethod]
        public void TestarDTO()
        {
            AnimeDTO dto = new AnimeDTO
            {
                Id = 3,
                Nome = "One Piece",
                EpQueParei = 44,
                NumeroEpisodios = 1000,
                Status = "Assistindo"
            };

            Assert.AreEqual(dto.Id, 3);
            Assert.AreEqual(dto.Nome, "One Piece");
            Assert.AreEqual(dto.EpQueParei, 44);
            Assert.AreEqual(dto.NumeroEpisodios, 1000);
            Assert.AreEqual(dto.Status, "Assistindo");
            // Assert.AreEqual(dto.PorcentagemConcluida, 4.4m);
        }

        [TestMethod]
        public void VerificarPorcentagem()
        {
            AnimeDTO dto = new AnimeDTO
            {
                Id = 1,
                Nome = "Naruto Shippuden",
                EpQueParei = 73,
                NumeroEpisodios = 500,
                Status = "Assistindo"
            };

            Assert.AreEqual(dto.PorcentagemConcluida, 14.6m);
        }
    }
}
