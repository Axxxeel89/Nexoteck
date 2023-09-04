using Microsoft.AspNetCore.Mvc;
using SignalR_Core.Models;
using SignalR_Infraestructura.Data;

namespace SignalR.Controllers
{
    public class PQRSController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PQRSController(ApplicationDbContext db)
        {
            _dbContext= db;
        }

        [HttpGet]
        public IActionResult Solicitudes()
        {
            IEnumerable<Solicitud> solicitud = _dbContext.Solicitudes.ToList();

            return View(solicitud);
        }

        [HttpGet]
        public IActionResult UpsertSolicitud(int? id)
        {
            Solicitud solicitud = new();

            if(id == null)
            {
                solicitud = new Solicitud()
                {
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    Empresa = "E-Skids"
                };

                return View(solicitud);
            }
            else
            {
                solicitud = _dbContext.Solicitudes.Find(id);
            }

            return View(solicitud);
        }

        [HttpPost]
        public IActionResult UpsertSolicitud(Solicitud solicitud)
        {
            if(ModelState.IsValid)
            {
                if (solicitud.Id == 0)
                {
                    _dbContext.Solicitudes.Add(solicitud);
                    _dbContext.SaveChanges();
                }
                else
                {
                    _dbContext.Solicitudes.Update(solicitud);
                    _dbContext.SaveChanges();
                }
            }

            return RedirectToAction("Solicitudes", "PQRS");
        }

        public IActionResult Incidentes()
        {
            return View();
        }
    }
}
