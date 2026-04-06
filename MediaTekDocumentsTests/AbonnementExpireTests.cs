using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class AbonnementExpireTests
    {
        private const string titre = "Le Monde";
        private static readonly DateTime dateFinAbonnement = new DateTime(2026, 12, 31);
        private static readonly AbonnementExpire abonnementExpire = new AbonnementExpire(titre, dateFinAbonnement);

        [TestMethod]
        public void AbonnementExpireTest()
        {
            Assert.AreEqual(titre, abonnementExpire.Titre, "devrait réussir : titre valorisé");
            Assert.AreEqual(dateFinAbonnement, abonnementExpire.DateFinAbonnement, "devrait réussir : dateFinAbonnement valorisée");
        }
    }
}