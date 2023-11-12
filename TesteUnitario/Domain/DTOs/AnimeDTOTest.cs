using Dominio.DTOs;

namespace TesteUnitario.Domain.DTOs
{
    [TestClass]
    public class AnimeDTOTest
    {
        [TestMethod]
        public void TestarDTO()
        {
            AnimeDTO dto = new AnimeDTO(3, "One Piece", 1000, "Assistindo", 44);

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
            AnimeDTO dto = new AnimeDTO(1, "Naruto Shippuden", 500, "Assistindo", 73);            

            AnimeDTO d = dto;

            Assert.AreEqual(dto.PorcentagemConcluida, 14.6m);
        }
    }
}
