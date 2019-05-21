namespace SistemaPueblito.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class House
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required]
        [Display(Name = "Casa")]
        public string Name { get; set; }

        public User User { get; set; }
    }
}
