using System.ComponentModel.DataAnnotations;

namespace RappiApi.Models.ViewModels
{
    public class PaginacionViewModel
    {
        public int Pagina { get; set; }
        public int TamanoPagina { get; set; }
    }
}