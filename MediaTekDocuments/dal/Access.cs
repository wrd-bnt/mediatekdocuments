using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Linq;
using Serilog;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Couche d'accès aux données de l'application MediatekDocuments
    /// </summary>
    internal class NamespaceDoc { }

    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "http://localhost/rest_mediatekdocuments/";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour delete
        /// </summary>
        private const string DELETE = "DELETE";
        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String authenticationString;
            try
            {
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose()
                    .WriteTo.Console()
                    .WriteTo.File("logs/log.txt")
                    .CreateLogger();
                authenticationString = ConfigurationManager.AppSettings["api"];
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Log.Fatal("Access.Access catch erreur={0}", e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre", null);
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon", null);
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public", null);
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd", null);
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue", null);
            return lesRevues;
        }


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument, null);
            return lesExemplaires;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire", "champs=" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Access.CreerExemplaire erreur={0}", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Controle l'authentification d'un utilisateur
        /// </summary>
        /// <param name="login">login de l'utilisateur</param>
        /// <param name="pwd">mot de passe de l'utilisateur</param>
        /// <returns>l'objet Utilisateur si authentification correcte, null sinon</returns>
        public Utilisateur ControleAuthentification(string login, string pwd)
        {
            Dictionary<string, string> champs = new Dictionary<string, string>();
            champs.Add("login", login);
            champs.Add("pwd", pwd);
            String jsonChamps = JsonConvert.SerializeObject(champs);
            List<Utilisateur> liste = TraitementRecup<Utilisateur>(GET, "utilisateur/" + jsonChamps, null);
            if (liste != null && liste.Count > 0)
            {
                return liste[0];
            }
            return null;
        }

        /// <summary>
        /// Retourne les commandes d'un document (livre ou dvd)
        /// </summary>
        /// <param name="idLivreDvd">id du livre ou dvd concerné</param>
        /// <returns>Liste d'objets CommandeDocuments</returns>
        public List<CommandeDocument> GetCommandesDocument(string idLivreDvd)
        {
            String jsonIdLivreDvd = convertToJson("idLivreDvd", idLivreDvd);
            List<CommandeDocument> lesCommandes = TraitementRecup<CommandeDocument>(GET, "commandedocument/" + jsonIdLivreDvd, null);
            return lesCommandes;
        }

        /// <summary>
        /// Retourne tous les suivis à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            List<Suivi> lesSuivis = TraitementRecup<Suivi>(GET, "suivi", null);
            return lesSuivis;
        }

        /// <summary>
        /// Crée une commande de document dans la BDD
        /// </summary>
        /// <param name="commande">la commande à créer</param>
        /// <returns>true si la création a pu se faire</returns>
        public bool CreerCommandeDocument(CommandeDocument commande)
        {
            try
            {
                // Insertion dans la table commande
                Dictionary<string, object> champs1 = new Dictionary<string, object>();
                champs1.Add("id", commande.Id);
                champs1.Add("dateCommande", commande.DateCommande.ToString("yyyy-MM-dd"));
                champs1.Add("montant", commande.Montant.ToString());
                String jsonCommande = JsonConvert.SerializeObject(champs1);
                List<CommandeDocument> liste1 = TraitementRecup<CommandeDocument>(POST, "commande", "champs=" + jsonCommande);
                if (liste1 == null)
                {
                    Log.Error("Access.CreerCommandeDocument erreur insertion commande");
                    return false;
                }
                // Insertion dans la table commandedocument
                Dictionary<string, object> champs2 = new Dictionary<string, object>();
                champs2.Add("id", commande.Id);
                champs2.Add("nbExemplaire", commande.NbExemplaire);
                champs2.Add("idLivreDvd", commande.IdLivreDvd);
                champs2.Add("idSuivi", commande.IdSuivi);
                String jsonCommandeDoc = JsonConvert.SerializeObject(champs2);
                List<CommandeDocument> liste2 = TraitementRecup<CommandeDocument>(POST, "commandedocument", "champs=" + jsonCommandeDoc);
                return (liste2 != null);
            }
            catch (Exception ex)
            {
                Log.Error("Access.CreerCommandeDocument erreur={0}", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Modifie l'étape de suivi d'une commande dans la BDD
        /// </summary>
        /// <param name="commande">la commande à modifier</param>
        /// <returns>true si la modification a pu se faire</returns>
        public bool UpdateSuiviCommandeDocument(CommandeDocument commande)
        {
            String jsonCommande = JsonConvert.SerializeObject(new { idSuivi = commande.IdSuivi });
            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(PUT, "commandedocument/" + commande.Id, "champs=" + jsonCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Access.UpdateSuiviCommandeDocument erreur={0}", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Supprime une commande de document dans la BDD
        /// </summary>
        /// <param name="commande">la commande à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerCommandeDocument(CommandeDocument commande)
        {
            String jsonCommande = convertToJson("id", commande.Id);
            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "commande/" + jsonCommande, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Access.SupprimerCommandeDocument erreur={0}", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Retourne les abonnements d'une revue
        /// </summary>
        /// <param name="idRevue">id de la revue concernée</param>
        /// <returns>Liste d'objets Abonnement</returns>
        public List<Abonnement> GetAbonnementsRevue(string idRevue)
        {
            String jsonIdRevue = convertToJson("idRevue", idRevue);
            List<Abonnement> lesAbonnements = TraitementRecup<Abonnement>(GET, "abonnement/" + jsonIdRevue, null);
            return lesAbonnements;
        }

        /// <summary>
        /// Retourne les revues dont l'abonnement se termine dans moins de 30 jours
        /// </summary>
        /// <returns>Liste d'objets AbonnementExpire</returns>
        public List<AbonnementExpire> GetRevuesAbonnementsBientotExpires()
        {
            List<AbonnementExpire> lesAbonnements = TraitementRecup<AbonnementExpire>(GET, "abonnementexpire", null);
            return lesAbonnements;
        }

        /// <summary>
        /// Crée un abonnement dans la BDD
        /// </summary>
        /// <param name="abonnement">l'abonnement à créer</param>
        /// <returns>true si la création a pu se faire</returns>
        public bool CreerAbonnement(Abonnement abonnement)
        {
            try
            {
                // Insertion dans la table commande
                Dictionary<string, object> champs1 = new Dictionary<string, object>();
                champs1.Add("id", abonnement.Id);
                champs1.Add("dateCommande", abonnement.DateCommande.ToString("yyyy-MM-dd"));
                champs1.Add("montant", abonnement.Montant.ToString());
                String jsonCommande = JsonConvert.SerializeObject(champs1);
                List<Abonnement> liste1 = TraitementRecup<Abonnement>(POST, "commande", "champs=" + jsonCommande);
                if (liste1 == null)
                {
                    Log.Error("Access.CreerAbonnement erreur insertion commande");
                    return false;
                }
                // Insertion dans la table abonnement
                Dictionary<string, object> champs2 = new Dictionary<string, object>();
                champs2.Add("id", abonnement.Id);
                champs2.Add("dateFinAbonnement", abonnement.DateFinAbonnement.ToString("yyyy-MM-dd"));
                champs2.Add("idRevue", abonnement.IdRevue);
                String jsonAbonnement = JsonConvert.SerializeObject(champs2);
                List<Abonnement> liste2 = TraitementRecup<Abonnement>(POST, "abonnement", "champs=" + jsonAbonnement);
                return (liste2 != null);
            }
            catch (Exception ex)
            {
                Log.Error("Access.CreerAbonnement erreur={0}", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Supprime un abonnement dans la BDD
        /// </summary>
        /// <param name="abonnement">l'abonnement à supprimer</param>
        /// <returns>true si la suppression a pu se faire</returns>
        public bool SupprimerAbonnement(Abonnement abonnement)
        {
            String jsonAbonnement = convertToJson("id", abonnement.Id);
            try
            {
                List<Abonnement> liste = TraitementRecup<Abonnement>(DELETE, "abonnement/" + jsonAbonnement, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Log.Error("Access.SupprimerAbonnement erreur={0}", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée dans l'url</param>
        /// <param name="parametres">paramètres à envoyer dans le body, au format "chp1=val1&chp2=val2&..."</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T> (String methode, String message, String parametres)
        {
            // trans
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Log.Error("Access.TraitementRecup code={0} message={1}", code, (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Log.Fatal("Access.TraitementRecup error={0}", e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

    }
}
