using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class CategorieTests
    {
        private const string id = "10001";
        private const string libelle = "Policier";
        private readonly Categorie categorie = new Categorie(id, libelle);

        [TestMethod]
        public void CategorieTest()
        {
            Assert.AreEqual(id, categorie.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(libelle, categorie.Libelle, "devrait réussir : libellé valorisé");
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle, categorie.ToString(), "devrait réussir : libellé retourné");
        }
    }
}
