namespace ControleDeContatos.Models
{
    public class ContatoViewModel
    {
        public ContatoModel Contato { get; set; }
        public List<ObservacaoModel>? Observacoes { get; set; }
        public List<PecaModel>? Pecas { get; set; }

        public List<ImagemModel>? Imagens { get; set; }
    }
}
