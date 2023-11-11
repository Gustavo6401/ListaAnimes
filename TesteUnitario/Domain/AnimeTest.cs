

namespace TesteUnitario.Domain
{
    [TestClass]
    public class AnimeTest
    {
        [TestMethod]
        // Testa se as propriedades estão corretas ou se falta alguma
        public void TestarPropriedades()
        {
            Anime anime = new Anime
            {
                Id = 1,
                Nome = "Naruto Shippuden",
                EpQueParei = 71,
                NumeroEpisodios = 500,
                Status = "Assistindo"
            };

            Assert.AreEqual(anime.Id, 1);
            Assert.AreEqual(anime.Nome, "Naruto Shippuden");
            Assert.AreEqual(anime.EpQueParei, 71);
            Assert.AreEqual(anime.NumeroEpisodios, 500);
            Assert.AreEqual(anime.Status, "Assistindo");
        }
    }
}
