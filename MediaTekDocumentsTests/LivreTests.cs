using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class LivreTests
    {
        private const string id = "00001";
        private const string titre = "Quand sort la recluse";
        private const string image = "";
        private const string isbn = "1234569877896";
        private const string auteur = "Fred Vargas";
        private const string collection = "Commissaire Adamsberg";
        private const string idGenre = "10014";
        private const string genre = "Policier";
        private const string idPublic = "00002";
        private const string lePublic = "Adultes";
        private const string idRayon = "LV003";
        private const string rayon = "Policiers français étrangers";
        private static readonly Livre livre = new Livre(id, titre, image, isbn, auteur, collection, idGenre, genre, idPublic, lePublic, idRayon, rayon);

        [TestMethod]
        public void LivreTest()
        {
            Assert.AreEqual(id, livre.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(titre, livre.Titre, "devrait réussir : titre valorisé");
            Assert.AreEqual(isbn, livre.Isbn, "devrait réussir : isbn valorisé");
            Assert.AreEqual(auteur, livre.Auteur, "devrait réussir : auteur valorisé");
            Assert.AreEqual(collection, livre.Collection, "devrait réussir : collection valorisée");
            Assert.AreEqual(genre, livre.Genre, "devrait réussir : genre valorisé");
            Assert.AreEqual(lePublic, livre.Public, "devrait réussir : public valorisé");
            Assert.AreEqual(rayon, livre.Rayon, "devrait réussir : rayon valorisé");
        }
    }
}
