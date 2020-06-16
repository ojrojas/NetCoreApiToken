namespace RappiApi.Models
{
    /// <summary>
    /// Entidad Area
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public class Area : BaseEntity
    {
        /// <summary>
        /// Nombre
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string Nombre { get; set; }

        /// <summary>
        /// Codigo
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public int Codigo { get; set; }
    }
}