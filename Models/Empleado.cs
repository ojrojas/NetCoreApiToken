namespace RappiApi.Models
{
    /// <summary>
    /// Empleado, Modelo empleado para la transaccion entre backend y base datos
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public class Empleado : BaseEntity
    {
        /// <summary>
        /// TipoIdentificacion, propiedad TipoIdentificacion para la transaccion
        /// </summary>
        /// <value>TipoIdentificacion</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>

        public int TipoIdentificacion { get; set; }

        /// <summary>
        /// NumeroIDentitificacion, propiedad NumeroIDentitificacion para la transaccion
        /// </summary>
        /// <value>NumeroIDentitificacion</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string NumeroIDentitificacion { get; set; }

        /// <summary>
        /// Nombre, propiedad Nombre para la transaccion
        /// </summary>
        /// <value>Nombre</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string Nombre { get; set; }

        /// <summary>
        /// SegundoNombre, propiedad SegundoNombre para la transaccion
        /// </summary>
        /// <value>SegundoNombre</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string SegundoNombre { get; set; }

        /// <summary>
        /// Apellido, propiedad Apellido para la transaccion
        /// </summary>
        /// <value>Apellido</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string Apellido { get; set; }

        /// <summary>
        /// SegundoApellido, propiedad SegundoApellido para la transaccion
        /// </summary>
        /// <value>SegundoApellido</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string SegundoApellido { get; set; }

        /// <summary>
        /// SubArea, propiedad SubArea para la transaccion
        /// </summary>
        /// <value>SubArea</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public SubArea SubArea { get; set; }

        /// <summary>
        /// SubAreaId, propiedad SubAreaId para la transaccion
        /// </summary>
        /// <value>SubAreaId</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public string SubAreaId { get; set; }

    }
}