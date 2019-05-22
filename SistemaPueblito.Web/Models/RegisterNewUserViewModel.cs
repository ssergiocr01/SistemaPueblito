namespace SistemaPueblito.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterNewUserViewModel
    {
        [Required]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Apellidos")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Correo Electrónico")]
        public string Username { get; set; }

        [Required]
        [Display(Name ="Contraseña")]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [Display(Name ="Confirmar Contraseña")]
        public string Confirm { get; set; }
    }
}
