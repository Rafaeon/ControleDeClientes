using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ControleDeContatos.Controllers
{
    public class PecaController : Controller
    {
        private readonly IPecaRepositorio _pecaRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;
        public PecaController(IPecaRepositorio pecaRepositorio, IContatoRepositorio contatoRepositorio)
        {
            _pecaRepositorio = pecaRepositorio;
            _contatoRepositorio = contatoRepositorio;
        } 
        [HttpGet]
        public IActionResult Index(int id)
        {
            var contato = _contatoRepositorio.ListarPorId(id);
            if (contato == null)
            {
                return RedirectToAction("Index", "Contato"); // Redirecione para a listagem de contatos ou outra página relevante.
            }

            var model = new ContatoViewModel
            {
                Contato = contato,
                Pecas = _pecaRepositorio.BuscarPorId(id) // Adicione as peças ao modelo.
            };

            return View(model);


        }
        [HttpPost]
        public IActionResult Criar(PecaModel peca)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pecaRepositorio.Adicionar(peca);
                    TempData["MensagemSucesso"] = "Peça cadastrada com sucesso";
                    return RedirectToAction("Index", new { id = peca.ContatoId});
                }
                return View(peca);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro:{erro.Message}";
                return View(peca);
            }
            
        }
        [HttpGet]
        public IActionResult Criar(int contatoId)
        {
            var novaPeca = new PecaModel { ContatoId = contatoId };
            return View(novaPeca);
        }

        public IActionResult ApagarConfirmacaoPeca(int id)
        {
            var peca = _pecaRepositorio.BuscarPecaPorId(id);
            if (peca == null)
            {
                return NotFound();
            }
            return View(peca);
        }
        [HttpPost]
        public IActionResult Apagar(int id)
        {
            var peca = _pecaRepositorio.BuscarPecaPorId(id);
            if(peca == null)
            {
                return NotFound();
            }
            _pecaRepositorio.Apagar(id);

            return RedirectToAction("Index", new { id = peca.ContatoId });


        }

        public IActionResult EditarPeca(int id)
        {
            var peca = _pecaRepositorio.BuscarPecaPorId(id);
            if (peca == null )
            {
                return NotFound();
            }
            return View(peca);
        }

        [HttpPost]
        public IActionResult EditarPeca(PecaModel peca)
        {
            if (ModelState.IsValid)
            {
                _pecaRepositorio.Atualizar(peca);


                return RedirectToAction("Index", "Peca", new { id = peca.ContatoId });
            }
            return View(peca);  
        }
    }
}
