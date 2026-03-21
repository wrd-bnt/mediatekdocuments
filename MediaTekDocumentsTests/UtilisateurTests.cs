using Microsoft.VisualStudio.TestTools.UnitTesting;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class UtilisateurTests
    {
        private const int id = 1;
        private const string login = "admin";
        private const string pwd = "admin";
        private const string idService = "ADM";
        private const string libelleService = "administratif";
        private static readonly Utilisateur utilisateur = new Utilisateur(id, login, pwd, idService, libelleService);

        [TestMethod]
        public void UtilisateurTest()
        {
            Assert.AreEqual(id, utilisateur.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(login, utilisateur.Login, "devrait réussir : login valorisé");
            Assert.AreEqual(pwd, utilisateur.Pwd, "devrait réussir : pwd valorisé");
            Assert.AreEqual(idService, utilisateur.IdService, "devrait réussir : idService valorisé");
            Assert.AreEqual(libelleService, utilisateur.LibelleService, "devrait réussir : libelleService valorisé");
            Assert.AreEqual(idService, utilisateur.Service.Id, "devrait réussir : service.Id valorisé");
        }
    }
}