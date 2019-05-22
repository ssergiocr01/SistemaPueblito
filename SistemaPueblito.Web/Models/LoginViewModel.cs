namespace SistemaPueblito.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Nombre de Usuario")]
        public string Username { get; set; }

        [Required]
        [Display(Name ="Contraseña")]
        public string Password { get; set; }

        [Display(Name ="Recuérdame")]
        public bool RememberMe { get; set; }
    }
}
