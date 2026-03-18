using Newtonsoft.Json;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Utilisateur
    /// </summary>
    public class Utilisateur
    {
        public int Id { get; }
        public string Login { get; }
        public string Pwd { get; }
        public string IdService { get; }
        public string LibelleService { get; }

        [JsonIgnore]
        public Service Service { get; private set; }

        /// <summary>
        /// Valorise les propriétés 
        /// </summary>
        /// <param name="id">identifiant de l'utilisateur</param>
        /// <param name="login">login de l'utilisateur</param>
        /// <param name="pwd">mot de passe de l'utilisateur</param>
        /// <param name="idService">identifiant du service</param>
        /// <param name="libelleService">libellé du service</param>
        public Utilisateur(int id, string login, string pwd, string idService, string libelleService)
        {
            this.Id = id;
            this.Login = login;
            this.Pwd = pwd;
            this.IdService = idService;
            this.LibelleService = libelleService;
            this.Service = new Service(idService, libelleService);
        }
    }
}