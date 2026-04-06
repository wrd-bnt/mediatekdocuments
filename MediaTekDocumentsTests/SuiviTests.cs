using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class SuiviTests
    {
        private const string id = "EC";
        private const string libelle = "en cours";
        private readonly Suivi suivi = new Suivi(id, libelle);

        [TestMethod]
        public void SuiviTest()
        {
            Assert.AreEqual(id, suivi.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(libelle, suivi.Libelle, "devrait réussir : libellé valorisé");
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle, suivi.ToString(), "devrait réussir : libellé retourné");
        }
    }
}
