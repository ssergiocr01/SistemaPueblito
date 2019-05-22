namespace SistemaPueblito.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ChangeUserViewModel
    {
        [Display(Name ="Nombres")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name ="Apellidos")]
        [Required]
        public string LastName { get; set; }
    }
}
