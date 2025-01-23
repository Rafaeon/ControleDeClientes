using ControleDeContatos.Models;

namespace ControleDeContatos.Repositorio
{
    public interface IPecaRepositorio
    {
        void Adicionar(PecaModel peca);
        List<PecaModel> BuscarTodas();
        PecaModel Atualizar(PecaModel peca);
        List<PecaModel> BuscarPorId(int contatoId);
        PecaModel BuscarPecaPorId(int id);
        bool Apagar(int id);
    }
}
