using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;
using SignalR_Core.Models;
using SignalR_Infraestructura.Data;
using System.Security.Claims;

namespace SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatHubController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ApplicationDbContext _context;

        public ChatHubController(
            IHubContext<ChatHub> hubContext,
            IHttpContextAccessor contextAccessor,
            ApplicationDbContext context)
        {
            _hubContext = hubContext;
            _contextAccessor=contextAccessor;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> EnviarMensaje(string messageChat)
        {
            await _hubContext.Clients.All.SendAsync("sendMessage", messageChat);

            var userName = _contextAccessor.HttpContext!.User?.Claims?
                            .FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;

            
            UsuarioChat usuario = new UsuarioChat();


            usuario.UserName = userName;
            usuario.Fecha = DateTime.Now; 
            usuario.message = messageChat;

            _context.UsuarioChats.Add(usuario);
            _context.SaveChanges();
                 
            return Ok();
        }
    }
}
