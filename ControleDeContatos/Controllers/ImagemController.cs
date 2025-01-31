using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

public class ImagemController : Controller
{
    private readonly IImagemRepositorio _imagemRepositorio;
    private readonly IContatoRepositorio _contatoRepositorio;

    public ImagemController(IImagemRepositorio imagemRepositorio, IContatoRepositorio contatoRepositorio)
    {
        _imagemRepositorio = imagemRepositorio;
        _contatoRepositorio = contatoRepositorio;
    }

    [HttpGet]
    public IActionResult Index(int id)
    {
        var imagens = _imagemRepositorio.ObterPorContatoId(id);

        var viewModel = new ContatoViewModel
        {
            Imagens = imagens,
            Contato = new ContatoModel { Id = id }
        };

        ViewBag.ContatoId = id;
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Upload(int contatoId, IFormFile arquivo)
    {
        try
        {
            var contato = _contatoRepositorio.ListarPorId(contatoId);
            if (contato == null)
            {
                TempData["Mensagem"] = "Contato não encontrado.";
                return RedirectToAction("Index", new { contatoId = contatoId });
            }

            if (arquivo != null && arquivo.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await arquivo.CopyToAsync(memoryStream);
                    var arquivoBytes = memoryStream.ToArray();

                    var imagem = new ImagemModel
                    {
                        Nome = arquivo.FileName,
                        Arquivo = arquivoBytes,
                        ContatoId = contatoId
                    };

                    await _imagemRepositorio.AdicionarAsync(imagem); // Usando o método assíncrono
                    await _imagemRepositorio.SaveChangesAsync();
                }

                TempData["Mensagem"] = "Upload realizado com sucesso!";
            }
            else
            {
                TempData["Mensagem"] = "Nenhum arquivo selecionado.";
            }
        }
        catch (Exception ex)
        {
            TempData["Mensagem"] = $"Ocorreu um erro durante o upload: {ex.Message}";
        }

        var imagens = _imagemRepositorio.ObterPorContatoId(contatoId);
        var viewModel = new ContatoViewModel
        {
            Imagens = imagens,
            Contato = new ContatoModel { Id = contatoId }
        };

        return View("Index", viewModel);
    }

    public IActionResult Download(int id)
    {
        var arquivo = _imagemRepositorio.ObterPorId(id);

        if (arquivo != null)
        {
            return File(arquivo.Arquivo, "application/octet-stream", arquivo.Nome);
        }

        TempData["Mensagem"] = "Arquivo não encontrado.";
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Excluir(int id)
    {
        var peca = _imagemRepositorio.ObterPorId(id);
        if (peca == null)
        {
            return NotFound();
        }
        _imagemRepositorio.Remover(id);

        return RedirectToAction("Index", new { id = peca.ContatoId });
    }

}