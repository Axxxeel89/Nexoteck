using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Core.Models
{
    public class Incidente
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaResolucion { get; set; }
        public int Estado { get; set; }
        public string ObservacionesTecnicas { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public int Impacto { get; set; }
        public string Empresa { get; set; } = string.Empty;
    }
}
