using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Core.Models
{
    public class UsuarioChat
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }

        [StringLength(1000)]
        public string message { get; set; } = string.Empty;
    }
}
