namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Suivi : représente une étape de suivi d'une commande
    /// </summary>
    public class Suivi
    {
        /// <summary>
        /// Identifiant du suivi
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Libellé du suivi
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Valorise les propriétés
        /// </summary>
        /// <param name="id">identifiant du suivi</param>
        /// <param name="libelle">libellé du suivi</param>
        public Suivi(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé du suivi
        /// </summary>
        /// <returns>libellé du suivi</returns>
        public override string ToString()
        {
            return this.Libelle;
        }
    }
}