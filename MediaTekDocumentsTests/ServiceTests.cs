using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class ServiceTests
    {
        private const string id = "ADM";
        private const string libelle = "administratif";
        private readonly Service service = new Service(id, libelle);

        [TestMethod]
        public void ServiceTest()
        {
            Assert.AreEqual(id, service.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(libelle, service.Libelle, "devrait réussir : libellé valorisé");
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual(libelle, service.ToString(), "devrait réussir : libellé retourné");
        }
    }
}