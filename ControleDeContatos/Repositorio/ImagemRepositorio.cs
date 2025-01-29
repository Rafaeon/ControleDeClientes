using ControleDeContatos.Data;
using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public class ImagemRepositorio : IImagemRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ImagemRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public void Adicionar(ImagemModel arquivo)
        {
            _bancoContext.Imagens.Add(arquivo);
            _bancoContext.SaveChanges();
        }

        public async Task AdicionarAsync(ImagemModel arquivo)
        {
            await _bancoContext.Imagens.AddAsync(arquivo);
            await _bancoContext.SaveChangesAsync();
        }

        public List<ImagemModel> ObterPorContatoId(int contatoId)
        {
            return _bancoContext.Imagens.Where(i => i.ContatoId == contatoId).ToList();
        }

        public ImagemModel ObterPorId(int id)
        {
            return _bancoContext.Imagens.Find(id);
        }

        public void Remover(int id)
        {
            var arquivo = _bancoContext.Imagens.Find(id);
            if (arquivo != null)
            {
                _bancoContext.Imagens.Remove(arquivo);
                _bancoContext.SaveChanges();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _bancoContext.SaveChangesAsync();
        }
    }
}