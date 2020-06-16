using System.ComponentModel.DataAnnotations;

namespace RappiApi.Models.ViewModels
{
    /// <summary>
    /// UsuarioViewModel, modelo de transaccion entre front y backend
    /// </summary>
    /// <author>Oscar Julian Rojas </author>
    /// <date>09/06/2020</date>
    public class UsuarioViewModel
    {

        /// <summary>
        /// Usuario, propiedad usuario para la transaccion
        /// </summary>
        /// <value>Usuario</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Required]
        public string Usuario { get; set; }

        /// <summary>
        /// Password, propiedad password para la transaccion
        /// </summary>
        /// <value>password</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}