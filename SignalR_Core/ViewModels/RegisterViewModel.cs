using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Core.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name ="Nombre de Usuario")]
        [Required(ErrorMessage ="El campo{0} es requerido")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "El campo{0} es requerido")]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage ="El valor de maximo de caracteres esta {0}")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El valor de maximo de caracteres esta {0}")]
        public string Empresa { get; set; }

        [StringLength(100, ErrorMessage = "El valor de maximo de caracteres esta {0}")]
        public string Apellido { get; set; }

        [StringLength(50, ErrorMessage = "El valor de maximo de caracteres esta {0}")]
        public string Celular { get; set; }

        [StringLength(50, ErrorMessage = "El valor de caracteres esta {0} y minimo de {1}", MinimumLength =6)]
        [Display(Name ="Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "El valor de caracteres esta {0} y minimo de {1}", MinimumLength = 6)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage ="Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }

        
    }
}
