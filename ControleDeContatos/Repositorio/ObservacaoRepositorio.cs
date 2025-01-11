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

        public ObservacaoModel Adicionar(ObservacaoModel observacao)
        {
            _bancoContext.Observacoes.Add(observacao);
            _bancoContext.SaveChanges();
            return observacao;
        }
        public ObservacaoModel ListarPorId(int id)
        {
            return _bancoContext.Observacoes.FirstOrDefault(x => x.Id == id);
        }
        public List<ObservacaoModel> BuscarTodos(int contatoId)
        {
            return _bancoContext.Observacoes.Where(o => o.ContatoId == contatoId).ToList();
        }
        public void Atualizar(ObservacaoModel observacao)
        {
            ObservacaoModel observacaoDB = ListarPorId(observacao.Id);

            if (observacaoDB == null) throw new Exception("Houve um erro na atualização do observacao!");

            observacaoDB.Observacao = observacao.Observacao;
            observacaoDB.DataAtendimento = observacao.DataAtendimento;

            _bancoContext.Observacoes.Update(observacaoDB);
            _bancoContext.SaveChanges();
            
        }

        public bool ApagarObs(int id)
        {
            ObservacaoModel observacaoDB = ListarPorId(id);

            if (observacaoDB == null) throw new Exception("Houve um erro na deleção do observacao!");

            _bancoContext.Observacoes.Remove(observacaoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
