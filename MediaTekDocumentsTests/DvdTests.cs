using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class DvdTests
    {
        private const string id = "00030";
        private const string titre = "Inception";
        private const string image = "";
        private const int duree = 148;
        private const string realisateur = "Christopher Nolan";
        private const string synopsis = "Un voleur qui s'introduit dans les rêves.";
        private const string idGenre = "10002";
        private const string genre = "Science Fiction";
        private const string idPublic = "00002";
        private const string lePublic = "Adultes";
        private const string idRayon = "DV001";
        private const string rayon = "Films étrangers";
        private static readonly Dvd dvd = new Dvd(id, titre, image, duree, realisateur, synopsis, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod]
        public void DvdTest()
        {
            Assert.AreEqual(id, dvd.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(titre, dvd.Titre, "devrait réussir : titre valorisé");
            Assert.AreEqual(duree, dvd.Duree, "devrait réussir : duree valorisée");
            Assert.AreEqual(realisateur, dvd.Realisateur, "devrait réussir : realisateur valorisé");
            Assert.AreEqual(synopsis, dvd.Synopsis, "devrait réussir : synopsis valorisé");
            Assert.AreEqual(genre, dvd.Genre, "devrait réussir : genre valorisé");
            Assert.AreEqual(lePublic, dvd.Public, "devrait réussir : public valorisé");
            Assert.AreEqual(rayon, dvd.Rayon, "devrait réussir : rayon valorisé");
        }
    }
}
