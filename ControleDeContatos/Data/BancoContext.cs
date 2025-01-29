using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ControleDeContatos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        { 
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ObservacaoModel> Observacoes { get; set; }
        public DbSet<PecaModel> Pecas { get; set; }
        public DbSet<ImagemModel> Imagens { get; set; }




    }
}