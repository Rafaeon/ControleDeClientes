using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class PecaModel
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage ="Incluir modelo da peça")]
        public string Nome { get; set; }
        public DateTime? DataGarantia { get; set; }

        [Required(ErrorMessage = "Incluir a quantidade de peça")]
        public int QTDPeca { get; set; }
        [Required(ErrorMessage = "Incluir a categoria da peça")]
        public string CategoriaPeca { get; set; }

        [Required]
        public int ContatoId { get; set; }

    }
}
