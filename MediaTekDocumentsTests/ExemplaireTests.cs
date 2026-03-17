using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class ExemplaireTests
    {
        private static readonly DateTime dateCommande = new DateTime(2026, 1, 1);
        private static readonly DateTime dateFinAbonnement = new DateTime(2026, 12, 31);
        private static readonly DateTime dateParutionDedans = new DateTime(2026, 6, 15);
        private static readonly DateTime dateParutionDehors = new DateTime(2025, 6, 15);

        [TestMethod]
        public void ParutionDansAbonnementTest()
        {
            Assert.IsTrue(Exemplaire.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParutionDedans), "devrait réussir : parution dans l'abonnement");
            Assert.IsFalse(Exemplaire.ParutionDansAbonnement(dateCommande, dateFinAbonnement, dateParutionDehors), "devrait réussir : parution hors abonnement");
        }
    }
}
