namespace SistemaPueblito.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using SistemaPueblito.Web.Data.Entities;
    using System.ComponentModel.DataAnnotations;

    public class ChildViewModel : Child
    {
        [Display(Name = "Imagen")]
        public IFormFile ImageFile { get; set; }
    }
}
