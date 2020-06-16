using System.ComponentModel.DataAnnotations;

namespace RappiApi.Models.ViewModels
{
    /// <summary>
    /// PaginacionViewModel, Modelo empleado para la transaccion entre front y backend
    /// </summary>
    /// <author>Oscar Julian Rojas </author>
    /// <date>09/06/2020</date>
    public class PaginacionViewModel
    {
        /// <summary>
        /// Pagina, propiedad Pagina para la transaccion
        /// </summary>
        /// <value>Pagina</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public int Pagina { get; set; }

        /// <summary>
        /// TamanoPagina, propiedad TamanoPagina para la transaccion
        /// </summary>
        /// <value>TamanoPagina</value>
        /// <author>Oscar Julian Rojas</author>
        /// <date>09/06/2020</date>
        public int TamanoPagina { get; set; }
    }
}