using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IObservacaoRepositorio
    {
        void AdicionarObservacao(ObservacaoModel observacao);
        List<ObservacaoModel> BuscarPorContatoId(int contatoId);
        void AtualizarObservacao(ObservacaoModel observacao);
        void ApagarObservacao(int id);
    }
}
