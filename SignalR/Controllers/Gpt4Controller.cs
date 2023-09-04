using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SignalR.Services;
using SignalR_Core.Models;

namespace SignalR.Controllers
{
    public class Gpt4Controller : Controller
    {
        private readonly IAnswerGeneratorServices _answer;

        public Gpt4Controller(IAnswerGeneratorServices answer)
        {
            _answer=answer;
        }
        public IActionResult Index()
        {
            Assistant assistant = new();
            return View(assistant);
        }

        public async Task<IActionResult> GenerarRespuestaGPT4(Assistant request)
        {
            var respuesta = await _answer.GenerateAnswer(request.Prompt);
            return Ok(respuesta);
        }
    }
}
