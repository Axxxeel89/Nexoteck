using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Core.Models
{
    public class Usuarios: IdentityUser
    {
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100)]
        public string Apellido { get; set; } = string.Empty;
        [StringLength(50)]
        public string Celular { get; set; } = string.Empty;

        [StringLength(100)]
        public string Empresa { get; set; } = string.Empty;
    }
}
