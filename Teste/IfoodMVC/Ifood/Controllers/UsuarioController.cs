using Ifood.Helper;
using Ifood.Models;
using Ifood.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ifood.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioService usuarioService;
        private readonly IEnderecoService enderecoService;

        private readonly ISessao sessao;

        public UsuarioController(IUsuarioService usuarioRepositorio, ISessao sessao, IEnderecoService enderecoService)
        {
            this.usuarioService = usuarioRepositorio;
            this.sessao = sessao;
            this.enderecoService = enderecoService;
        }

        [Route("Cadastro")]
        public IActionResult Index()
        {
            if (sessao.BuscarSessao() != null) return RedirectToAction("Home", "Restaurantes");

            return View();
        }

        public async Task<IActionResult> Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioModel user)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    
                    UsuarioModel usuario =  await usuarioService.CadastrarUsuario(user);

                    if (usuario == null) {
                        TempData["MensagemErro"] = $"Dados já existente! Informe os dados novamente!";
                        return View("Index");
                    }
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index", "Login");
                }

                return View("Index" ,user);
                
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro: {ex.Message}";
                return RedirectToAction("Index");
            }


        }
        [Route("CadastrarEndereco")]
        public async Task<IActionResult> CadastrarEndereco()
        {
            return View();
        }

        [HttpPost]
        [Route("CadastrarEndereco")]
        public async Task<IActionResult> CadastrarEndereco(EnderecoModel endereco)
        {
            try
            {
                UsuarioModel usuario = new UsuarioModel();
                usuario.Endereco = await enderecoService.SalvarEndereco(endereco);
                return View("Criar", usuario);
            }
            catch (Exception ex)
            {
                return View();
            }

        }
    }
}
