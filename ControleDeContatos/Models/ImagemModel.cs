using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ImagemModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public byte[] Arquivo { get; set; }

        public DateTime DataInclusão { get; set; }


        [Required]
        public int ContatoId { get; set; }

    }
}
