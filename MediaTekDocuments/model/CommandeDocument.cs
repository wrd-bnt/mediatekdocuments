using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeDocument : représente une commande de livre ou DVD
    /// </summary>
    public class CommandeDocument
    {
        /// <summary>
        /// Identifiant de la commande
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Date de la commande
        /// </summary>
        public DateTime DateCommande { get; }

        /// <summary>
        /// Montant de la commande
        /// </summary>
        public double Montant { get; }

        /// <summary>
        /// Nombre d'exemplaires commandés
        /// </summary>
        public int NbExemplaire { get; }

        /// <summary>
        /// Identifiant du livre ou DVD concerné
        /// </summary>
        public string IdLivreDvd { get; }

        /// <summary>
        /// Identifiant de l'étape de suivi
        /// </summary>
        public string IdSuivi { get; set; }

        /// <summary>
        /// Libellé de l'étape de suivi
        /// </summary>
        public string Suivi { get; set; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="id">identifiant de la commande</param>
        /// <param name="dateCommande">date de la commande</param>
        /// <param name="montant">montant de la commande</param>
        /// <param name="nbExemplaire">nombre d'exemplaires commandés</param>
        /// <param name="idLivreDvd">identifiant du livre ou DVD concerné</param>
        /// <param name="idSuivi">identifiant de l'étape de suivi</param>
        /// <param name="suivi">libellé de l'étape de suivi</param>
        public CommandeDocument(string id, DateTime dateCommande, double montant,
            int nbExemplaire, string idLivreDvd, string idSuivi, string suivi)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.NbExemplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
            this.IdSuivi = idSuivi;
            this.Suivi = suivi;
        }
    }
}