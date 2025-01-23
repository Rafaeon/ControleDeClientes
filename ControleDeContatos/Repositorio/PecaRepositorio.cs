using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos.Repositorio
{
    public class PecaRepositorio : IPecaRepositorio
    {
        private readonly BancoContext _bancoContext;

        public PecaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public void Adicionar(PecaModel peca)
        {
            _bancoContext.Pecas.Add(peca);
            _bancoContext.SaveChanges();
        }

        public bool Apagar(int id)
        {
            PecaModel pecaDB = BuscarPecaPorId(id);

            if (pecaDB == null) throw new Exception("Houve algum problema ao tentar apagar a peca");
            
            _bancoContext.Pecas.Remove(pecaDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public PecaModel Atualizar(PecaModel peca)
        {
            PecaModel pecaDB = BuscarPecaPorId(peca.Id);
            if (pecaDB == null) throw new Exception("Houve algum problema ao tentar editar a peca");

            pecaDB.Nome = peca.Nome;
            pecaDB.CategoriaPeca = peca.CategoriaPeca;
            pecaDB.QTDPeca = peca.QTDPeca;
            pecaDB.DataGarantia = peca.DataGarantia;


            _bancoContext.Pecas.Update(pecaDB);
            _bancoContext.SaveChanges();

            return pecaDB;
        }

        public List<PecaModel> BuscarPorId(int contatoId)
        {
            return _bancoContext.Pecas.Where(p => p.ContatoId == contatoId).ToList();
        }

        public List<PecaModel> BuscarTodas()
        {
            return _bancoContext.Pecas.ToList();
        }

        public PecaModel BuscarPecaPorId(int id)
        {
            return _bancoContext.Pecas.FirstOrDefault(a => a.Id == id);
        }
    }
}
