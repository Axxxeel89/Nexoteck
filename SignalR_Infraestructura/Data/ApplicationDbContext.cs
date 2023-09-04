using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SignalR_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Infraestructura.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<Usuarios> usuarios { get; set; }
        public DbSet<UsuarioChat> UsuarioChats { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }

    }
}
