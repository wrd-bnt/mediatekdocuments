using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Abonnement : représente une commande d'abonnement à une revue
    /// </summary>
    public class Abonnement
    {
        /// <summary>
        /// Identifiant de la commande d'abonnement
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
        /// Date de fin d'abonnement
        /// </summary>
        public DateTime DateFinAbonnement { get; }

        /// <summary>
        /// Identifiant de la revue concernée
        /// </summary>
        public string IdRevue { get; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="id">identifiant de la commande</param>
        /// <param name="dateCommande">date de la commande</param>
        /// <param name="montant">montant de la commande</param>
        /// <param name="dateFinAbonnement">date de fin d'abonnement</param>
        /// <param name="idRevue">identifiant de la revue concernée</param>
        public Abonnement(string id, DateTime dateCommande, double montant,
            DateTime dateFinAbonnement, string idRevue)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
            this.DateFinAbonnement = dateFinAbonnement;
            this.IdRevue = idRevue;
        }
    }
}
