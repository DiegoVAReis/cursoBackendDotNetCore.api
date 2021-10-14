using System.ComponentModel.DataAnnotations;

namespace cursoBackendDotNetCore.api.Models.Usuarios
{
    public class RegistroViewModelInput
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; } 

        [Required(ErrorMessage = "O E-mail é obrigatório")]  
        public string Email { get; set; }   

        [Required(ErrorMessage = "A Senha é obrigatório")]
        public string Senha { get; set; }   
    }
}