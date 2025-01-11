using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IObservacaoRepositorio
    {
        ObservacaoModel ListarPorId(int id);
        List<ObservacaoModel> BuscarTodos(int contatoId);
        ObservacaoModel Adicionar(ObservacaoModel observacao);
        void Atualizar(ObservacaoModel observacao);
        bool ApagarObs(int id);

    }
}
