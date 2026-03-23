namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classes métier de l'application MediatekDocuments
    /// </summary>
    internal class NamespaceDoc { }

    /// <summary>
    /// Classe métier Service
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant du service
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Libellé du service
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Valorise les propriétés 
        /// </summary>
        /// <param name="id">identifiant du service</param>
        /// <param name="libelle">libellé du service</param>
        public Service(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé du service
        /// </summary>
        /// <returns>libellé du service</returns>
        public override string ToString()
        {
            return this.Libelle;
        }

    }

}
