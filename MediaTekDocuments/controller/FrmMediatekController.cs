using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }


        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// Retourne les commandes d'un document (livre ou dvd)
        /// </summary>
        /// <param name="idLivreDvd">id du livre ou dvd concerné</param>
        /// <returns>Liste d'objets CommandeDocuments</returns>
        public List<CommandeDocument> GetCommandesDocument(string idLivreDvd)
        {
            return access.GetCommandesDocument(idLivreDvd);
        }

        /// <summary>
        /// Retourne tous les suivis
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }

        /// <summary>
        /// Crée une commande de document dans la BDD
        /// </summary>
        /// <param name="commande">la commande à créer</param>
        /// <returns>true si la création a pu se faire</returns>
        public bool CreerCommandeDocument(CommandeDocument commande)
        {
            return access.CreerCommandeDocument(commande);
        }

        /// <summary>
        /// Modifie l'étape de suivi d'une commande dans la BDD
        /// </summary>
        /// <param name="commande">la commande à modifier</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool UpdateSuiviCommandeDocument(CommandeDocument commande)
        {
            return access.UpdateSuiviCommandeDocument(commande);
        }

        /// <summary>
        /// Supprime une commande de document dans la BDD
        /// </summary>
        /// <param name="commande">la commande à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerCommandeDocument(CommandeDocument commande)
        {
            return access.SupprimerCommandeDocument(commande);
        }

        /// <summary>
        /// Retourne les abonnements d'une revue
        /// </summary>
        /// <param name="idRevue">id de la revue concernée</param>
        /// <returns>Liste d'objets Abonnement</returns>
        public List<Abonnement> GetAbonnementsRevue(string idRevue)
        {
            return access.GetAbonnementsRevue(idRevue);
        }

        /// <summary>
        /// Retourne les revues dont l'abonnement se termine dans moins de 30 jours
        /// </summary>
        /// <returns>Liste d'objets AbonnementExpire</returns>
        public List<AbonnementExpire> GetRevuesAbonnementsBientotExpires()
        {
            return access.GetRevuesAbonnementsBientotExpires();
        }

        /// <summary>
        /// Crée un abonnement dans la BDD
        /// </summary>
        /// <param name="abonnement">l'abonnement à créer</param>
        /// <returns>true si la création a pu se faire</returns>
        public bool CreerAbonnement(Abonnement abonnement)
        {
            return access.CreerAbonnement(abonnement);
        }

        /// <summary>
        /// Supprime un abonnement dans la BDD
        /// </summary>
        /// <param name="abonnement">l'abonnement à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerAbonnement(Abonnement abonnement)
        {
            return access.SupprimerAbonnement(abonnement);
        }
    }
}
