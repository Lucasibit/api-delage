using Ifood.Helper;
using Ifood.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ifood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessao sessao;

        public HomeController(ILogger<HomeController> logger, ISessao sessao)
        {
            _logger = logger;
            this.sessao = sessao;
        }

        public IActionResult Index()
        {
            if (sessao.BuscarSessao() != null) return RedirectToAction("Index", "Restaurantes");

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}