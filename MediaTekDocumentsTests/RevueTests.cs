using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class RevueTests
    {
        private const string id = "10001";
        private const string titre = "Le Monde";
        private const string image = "";
        private const string idGenre = "10005";
        private const string genre = "Actualités";
        private const string idPublic = "00002";
        private const string lePublic = "Adultes";
        private const string idRayon = "RV001";
        private const string rayon = "Presse";
        private const string periodicite = "Quotidien";
        private const int delaiMiseADispo = 1;
        private static readonly Revue revue = new Revue(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon, periodicite, delaiMiseADispo);

        [TestMethod]
        public void RevueTest()
        {
            Assert.AreEqual(id, revue.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(titre, revue.Titre, "devrait réussir : titre valorisé");
            Assert.AreEqual(periodicite, revue.Periodicite, "devrait réussir : periodicite valorisée");
            Assert.AreEqual(delaiMiseADispo, revue.DelaiMiseADispo, "devrait réussir : delaiMiseADispo valorisé");
            Assert.AreEqual(genre, revue.Genre, "devrait réussir : genre valorisé");
            Assert.AreEqual(lePublic, revue.Public, "devrait réussir : public valorisé");
            Assert.AreEqual(rayon, revue.Rayon, "devrait réussir : rayon valorisé");
        }
    }
}
