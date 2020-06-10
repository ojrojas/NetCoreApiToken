using System.ComponentModel.DataAnnotations;

namespace RappiApi.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        public bool Recuerdame {get;set;}
    }
}