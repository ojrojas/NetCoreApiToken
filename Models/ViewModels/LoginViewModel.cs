using System.ComponentModel.DataAnnotations;

namespace RappiApi.Models.ViewModels
{
    /// <summary>
    /// LoginViewModel, Modelo empleado para la transaccion entre front y backend
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/06/2020</date>
    public class LoginViewModel
    {
        /// <summary>
        /// NombreUsuario, propiedad NombreUsuario para la transaccion
        /// </summary>
        /// <value>NombreUsuario</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Required]
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Contrasena, propiedad Contrasena para la transaccion
        /// </summary>
        /// <value>Contrasena</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        /// <summary>
        /// Recuerdame, propiedad Recuerdame para la transaccion
        /// </summary>
        /// <value>Recuerdame</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public bool Recuerdame { get; set; }
    }
}