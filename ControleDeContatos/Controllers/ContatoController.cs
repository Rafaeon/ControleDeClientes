using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IObservacaoRepositorio _observacaoRepositorio;
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio, IObservacaoRepositorio observacaoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
            _observacaoRepositorio = observacaoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);

            
            var model = new ContatoViewModel();
            model.Contato = contato;
            var lista = _observacaoRepositorio.BuscarTodos(id);
            model.Observacoes = lista;
            return View(model);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);

            return View(contato);

        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Erro, não conseguimos apagar seu contato, tente novamente";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro, não conseguimos apagar seu contato, mais detalhes do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid) //criar validação
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastro com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Alterar(ContatoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(model.Contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", model); //forçar view Editar
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Erro, não conseguimos atualizar seu contato, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public JsonResult CriarObservacao( int txtContatoId,string txtObservacao, DateTime txtDataAtendimento)
        {
            ObservacaoModel obj = new ObservacaoModel();
            obj.Observacao = txtObservacao;
            obj.DataAtendimento = txtDataAtendimento;
            obj.ContatoId = txtContatoId;
            _observacaoRepositorio.Adicionar(obj);

            return Json(txtObservacao);  

        }
        public IActionResult ApagarConfirmacaoObs(int id)
        {
            var observacao = _observacaoRepositorio.ListarPorId(id);
            if (observacao == null)
            {
                return NotFound(); 
            }

            
            return View(observacao);
        }

        
        [HttpPost]
        public IActionResult ApagarObs(int id)
        {
            var observacao = _observacaoRepositorio.ListarPorId(id);
            if (observacao == null)
            {
                return NotFound();
            }

            _observacaoRepositorio.ApagarObs(id);

            return RedirectToAction("Editar", new { id = observacao.ContatoId });
        }
        public IActionResult EditarObservacao(int id)
        {
            var observacao = _observacaoRepositorio.ListarPorId(id);
            if (observacao == null)
            {
                return NotFound();
            }

            return View(observacao);
        }

        [HttpPost]
        public IActionResult EditarObservacao(ObservacaoModel model)
        {
            if (ModelState.IsValid)
            {
                _observacaoRepositorio.Atualizar(model);
                return RedirectToAction("Editar", new { id = model.ContatoId });
            }

            return View(model);
        }

    }
}