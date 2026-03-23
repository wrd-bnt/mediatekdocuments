
using MediaTekDocuments.dal;
using MediaTekDocuments.model;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Couche contrôleur de l'application MediatekDocuments
    /// </summary>
    internal class NamespaceDoc { }

    /// <summary>
    /// Controleur de FrmAuthentification
    /// </summary>
    class FrmAuthentificationController
    {
        /// <summary>
        /// objet d'accès aux données
        /// </summary>
        private readonly Access access;
        
        /// <summary>
        /// Récupère l'instance unique d'accès aux données 
        /// </summary>
        public FrmAuthentificationController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Vérifie l'authentification d'un utilisateur
        /// </summary>
        /// <param name="login">login de l'utilisateur</param>
        /// <param name="pwd">mot de passe de l'utilisateur</param>
        /// <returns>l'objet Utilisateur si authentification correcte, null sinon</returns>
        public Utilisateur ControleAuthentification(string login, string pwd)
        {
            return access.ControleAuthentification(login, pwd);
        }
    }
}