namespace RappiApi.Models
{
      /// <summary>
    /// SubArea, Modelo empleado para la transaccion entre backend y base datos
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>

    public class SubArea : BaseEntity
    {
           /// <summary>
        /// Nombre, propiedad Nombre para la transaccion
        /// </summary>
        /// <value>Nombre</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string Nombre { get; set; }

           /// <summary>
        /// Codigo, propiedad Codigo para la transaccion
        /// </summary>
        /// <value>Codigo</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public int Codigo { get; set; }

           /// <summary>
        /// Area, propiedad Area para la transaccion
        /// </summary>
        /// <value>Area</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public Area Area { get; set; }

           /// <summary>
        /// AreaId, propiedad AreaId para la transaccion
        /// </summary>
        /// <value>AreaId</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string AreaId { get; set; }
    }
}