

namespace TesteUnitario.Domain
{
    [TestClass]
    public class AnimeTest
    {
        [TestMethod]
        // Testa se as propriedades estão corretas ou se falta alguma
        public void TestarPropriedades()
        {
            Anime anime = new Anime(1, "Naruto Shippuden", 74, 500, "Assistindo");

            Assert.AreEqual(anime.Id, 1);
            Assert.AreEqual(anime.Nome, "Naruto Shippuden");
            Assert.AreEqual(anime.EpQueParei, 74);
            Assert.AreEqual(anime.NumeroEpisodios, 500);
            Assert.AreEqual(anime.Status, "Assistindo");
        }
    }
}
