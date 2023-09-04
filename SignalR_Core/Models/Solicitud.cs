using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Core.Models
{
    public class Solicitud
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tipo de solicitud")]
        public TipoEnum Tipo { get; set; }
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [Display(Name = "Fecha de creación")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Fecha de Actualizacion")]
        public DateTime FechaActualizacion { get; set; } 
        public Estado Estado { get; set; }
        [Display(Name = "Observaciones Tecnicas")]
        public string ObservacionesTecnicas { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        [Display(Name = "Cliente")]
        public string Empresa { get; set; } = string.Empty;

    }
}
