using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class RedefinirSenhaModel
    {
        [Required(ErrorMessage = "Digite login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o E-mail")]
        public string Email { get; set; }
    }
}
