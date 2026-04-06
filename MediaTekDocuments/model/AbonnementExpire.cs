using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier pour les abonnements bientôt expirés (titre + date fin)
    /// </summary>
    public class AbonnementExpire
    {
        /// <summary>
        /// Titre de la revue
        /// </summary>
        public string Titre { get; set; }

        /// <summary>
        /// Date de fin d'abonnement
        /// </summary>
        public DateTime DateFinAbonnement { get; set; }

        /// <summary>
        /// Constructeur sans paramètres requis pour la désérialisation JSON
        /// </summary>
        public AbonnementExpire() { }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="titre">titre de la revue</param>
        /// <param name="dateFinAbonnement">date de fin d'abonnement</param>
        public AbonnementExpire(string titre, DateTime dateFinAbonnement)
        {
            this.Titre = titre;
            this.DateFinAbonnement = dateFinAbonnement;
        }
    }
}
