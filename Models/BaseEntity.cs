namespace RappiApi.Models
{
    /// <summary>
    /// BaseEntity, Entidad de identificadores
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public class BaseEntity : IAggregateRoot
    {
        /// <summary>
        /// Id, Propiedad de indentidad
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string Id { get; set; }
    }
}