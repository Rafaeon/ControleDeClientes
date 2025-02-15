﻿using System.ComponentModel.DataAnnotations;
using ControleDeContatos.Enums;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o email do contato")]
        [EmailAddress(ErrorMessage = "O email informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage ="O celular informado não é valido!")]
        public string Celular { get; set; }
        public string? Endereco { get; set; }
        public DateTime? DataDeGarantia { get; set; }

        public SituacaoCliente? Situacao { get; set; }


    }

}
