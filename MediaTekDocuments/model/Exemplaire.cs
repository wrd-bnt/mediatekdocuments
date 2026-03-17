using System;
using System.ComponentModel;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Exemplaire (exemplaire d'une revue)
    /// </summary>
    public class Exemplaire
    {
        public int Numero { get; set; }
        public string Photo { get; set; }
        public DateTime DateAchat { get; set; }
        public string IdEtat { get; set; }
        public string Id { get; set; }

        public Exemplaire(int numero, DateTime dateAchat, string photo, string idEtat, string idDocument)
        {
            this.Numero = numero;
            this.DateAchat = dateAchat;
            this.Photo = photo;
            this.IdEtat = idEtat;
            this.Id = idDocument;
        }

        /// <summary>
        /// Vérifie si date de parution est comprise entre date de commande et date de fin d'abonnement
        /// </summary>
        /// <param name="dateCommande">date début abonnement</param>
        /// <param name="dateFinAbonnement">date fin abonnement</param>
        /// <param name="dateParution">date parution à vérifier</param>
        /// <returns>vrai si date de parution est entre les 2 dates</returns>
        public static bool ParutionDansAbonnement(DateTime dateCommande, DateTime dateFinAbonnement, DateTime dateParution)
        {
            return dateParution >= dateCommande && dateParution <= dateFinAbonnement;
        }

    }
  
}
