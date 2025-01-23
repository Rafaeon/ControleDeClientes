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
        private readonly IEmail _email;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
            ISessao sessao,
            IEmail email)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
            _email = email;
        }
        public IActionResult Index()
        {
            // se usuario estiver logado, redirecionar para home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Contato");

            return View();
        }
        public IActionResult RedefinirSenha()
        {
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
        [HttpPost]
        public IActionResult EnviarLinkParaRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorEmailELogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);


                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é: {novaSenha}";

                        bool emailEnviado = _email.Enviar(usuario.Email, "Controle de Clientes - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioRepositorio.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar o e-mail. Por favor, verifique os dados informados.";

                        }

                        return RedirectToAction("Index", "Login");

                    }
                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro, não conseguimos redefinir sua senha, tente novamente, detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
