﻿using ControleDeContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UsuarioSemSenhaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuario")]
        [EmailAddress(ErrorMessage = "O email informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o Perfil do usuario")]

        public PerfilEnum Perfil { get; set; }
       
    }
}
