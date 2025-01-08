using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
            ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            // se usuario estiver logado, redirecionar para home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Contato");

            return View();
        }

        public IActionResult Sair()
        { 
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if(ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);


                    if (usuario != null) 
                    {
                        if(usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Contato");
                        }

                        TempData["MensagemErro"] = $"Senha do usuario é invalida. Por favor, tente novemnte.";

                    }
                    TempData["MensagemErro"] = $"Usuario ou senha invalidos. Por favor, tente novemnte.";
                }
                return View("Index");
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Erro, não conseguimos realizar seu login, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
