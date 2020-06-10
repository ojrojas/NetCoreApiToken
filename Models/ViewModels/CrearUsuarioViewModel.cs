using System.ComponentModel.DataAnnotations;

namespace RappiApi.Models.ViewModels    
{
    public class CrearUsuarioViewModel {
        [Required]
        public string Usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}