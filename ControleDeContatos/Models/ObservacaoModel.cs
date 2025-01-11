using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeContatos.Models
{
    public class ObservacaoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha a Observação")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "Preencha a data da observação")]
        public DateTime? DataAtendimento { get; set; }

        [Required]
        public int ContatoId { get; set; }

    }
}
