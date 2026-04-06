using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MediaTekDocuments.model;

namespace MediaTekDocumentsTests
{
    [TestClass]
    public class CommandeDocumentTests
    {
        private const string id = "12345";
        private static readonly DateTime dateCommande = new DateTime(2026, 1, 1);
        private const double montant = 25.0;
        private const int nbExemplaire = 3;
        private const string idLivreDvd = "00001";
        private const string idSuivi = "EC";
        private const string suivi = "en cours";
        private static readonly CommandeDocument commande = new CommandeDocument(id, dateCommande, montant, nbExemplaire, idLivreDvd, idSuivi, suivi);

        [TestMethod]
        public void CommandeDocumentTest()
        {
            Assert.AreEqual(id, commande.Id, "devrait réussir : id valorisé");
            Assert.AreEqual(dateCommande, commande.DateCommande, "devrait réussir : dateCommande valorisée");
            Assert.AreEqual(montant, commande.Montant, "devrait réussir : montant valorisé");
            Assert.AreEqual(nbExemplaire, commande.NbExemplaire, "devrait réussir : nbExemplaire valorisé");
            Assert.AreEqual(idLivreDvd, commande.IdLivreDvd, "devrait réussir : idLivreDvd valorisé");
            Assert.AreEqual(idSuivi, commande.IdSuivi, "devrait réussir : idSuivi valorisé");
            Assert.AreEqual(suivi, commande.Suivi, "devrait réussir : suivi valorisé");
        }
    }
}
