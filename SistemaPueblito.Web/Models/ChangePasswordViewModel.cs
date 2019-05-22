namespace SistemaPueblito.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordViewModel
    {
        [Display(Name = "Contraseña Actual")]
        [Required]
        public string OldPassword { get; set; }

        [Display(Name = "Nueva Contraseña")]
        [Required]
        public string NewPassword { get; set; }

        [Display(Name ="Confirmar Contraseña")]
        [Required]
        public string Confirm { get; set; }
    }
}
