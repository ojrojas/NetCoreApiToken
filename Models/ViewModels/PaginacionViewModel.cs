using System.ComponentModel.DataAnnotations;

namespace RappiApi.Models.ViewModels
{
    public class PaginacionViewModel
    {
        public int Pagina { get; set; }
        public string TamanoPagina { get; set; }
    }
}