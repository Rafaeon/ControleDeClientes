using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class ObservacaoController : Controller
    {
        private readonly IObservacaoRepositorio _observacaoRepositorio;

        public ObservacaoController(IObservacaoRepositorio observacaoRepositorio)
        {
            _observacaoRepositorio = observacaoRepositorio;
        }

        // Ação para adicionar uma nova observação
        [HttpPost]
        public IActionResult AdicionarObservacao(ObservacaoModel observacao)
        {
            if (ModelState.IsValid)
            {
                _observacaoRepositorio.AdicionarObservacao(observacao);
                return RedirectToAction("Editar", "Contato", new { id = observacao.ContatoId });
            }

            return View(observacao);
        }

        // Ação para buscar as observações por ContatoId
        public IActionResult Editar(int id)
        {
            var observacoes = _observacaoRepositorio.BuscarPorContatoId(id);
            return View(observacoes);
        }
        [HttpPost]
        public IActionResult Criar(ObservacaoModel observacao)
        {
            if (ModelState.IsValid)
            {
                _observacaoRepositorio.AdicionarObservacao(observacao);
                TempData["MensagemSucesso"] = "Observação adicionada com sucesso!";
                return RedirectToAction("Editar", "Contato", new { id = observacao.ContatoId });
            }
            return View(observacao);
        }

    }
}
