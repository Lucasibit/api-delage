using Ifood.Models;
using Ifood.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ifood.Controllers
{
    public class RequestCepController : Controller
    {

        private readonly IRequestCepService requestCepService;

        public RequestCepController(IRequestCepService requestCepService)
        {
            this.requestCepService = requestCepService;
        }

        public async Task<IActionResult> Index([FromQuery] string cep)
        {
            var request = await requestCepService.BuscarCep(cep);

            if (request != null)
            {
                return View(request);
            }

            return RedirectToAction("Index", "Restaurantes");
        }
    }
}
