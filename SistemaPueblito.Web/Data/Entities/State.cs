namespace SistemaPueblito.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class State : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string Name { get; set; }

        public User User { get; set; }
    }
}
