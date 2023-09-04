using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR_Core.Models;
using SignalR_Core.ViewModels;

namespace SignalR.Controllers
{
    public class CuentasController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CuentasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            LoginViewModel login = new LoginViewModel();
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginRequest)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(loginRequest.Email, loginRequest.Password, loginRequest.RemenberMe, lockoutOnFailure: true);

                if (resultado.Succeeded)
                {
                    return LocalRedirect("~/Home/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No puedes ingresar tu cuenta, puede deberse a que agregaste mal las credenciales, o que el usuario este bloqueado");
                }
            
            }

            return View(loginRequest);
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel register = new RegisterViewModel();
            return View(register);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel regRequest)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuarios()
                {
                    UserName = regRequest.Email,
                    Email = regRequest.Email,
                    Nombre = regRequest.Nombre,
                    Apellido = regRequest.Apellido,
                    Celular = regRequest.Celular
                };

                var resultado = await _userManager.CreateAsync(usuario, regRequest.Password);

                if (resultado.Succeeded)
                {
                    await _signInManager.SignInAsync(usuario, isPersistent: false);
                    return LocalRedirect("~/Home/Index");
                }
            }

            return View(regRequest);

        }

        [HttpPost]
        public async Task<IActionResult> SalirAplicacion()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Bloqueado()
        {
            return View();
        }
        
    }
}
