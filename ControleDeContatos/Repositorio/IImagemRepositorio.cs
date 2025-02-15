﻿using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeContatos.Repositorio
{
    public interface IImagemRepositorio
    {
        void Adicionar(ImagemModel arquivo);
        Task AdicionarAsync(ImagemModel arquivo); 
        ImagemModel ObterPorId(int id);
        List<ImagemModel> ObterPorContatoId(int contatoId);
        void Remover(int id);
        Task SaveChangesAsync(); 
    }
}