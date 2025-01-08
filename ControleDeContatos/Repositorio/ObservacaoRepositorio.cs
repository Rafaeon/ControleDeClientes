using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public class ObservacaoRepositorio : IObservacaoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ObservacaoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public void AdicionarObservacao(ObservacaoModel observacao)
        {
            _bancoContext.Observacoes.Add(observacao);
            _bancoContext.SaveChanges();
        }

        public List<ObservacaoModel> BuscarPorContatoId(int contatoId)
        {
            return _bancoContext.Observacoes
                .Where(o => o.ContatoId == contatoId)
                .ToList();
        }

        public void AtualizarObservacao(ObservacaoModel observacao)
        {
            _bancoContext.Observacoes.Update(observacao);
            _bancoContext.SaveChanges();
        }

        public void ApagarObservacao(int id)
        {
            var observacao = _bancoContext.Observacoes.Find(id);
            if (observacao != null)
            {
                _bancoContext.Observacoes.Remove(observacao);
                _bancoContext.SaveChanges();
            }
        }
    }
}
