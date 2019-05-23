namespace SistemaPueblito.Web.Data.Entities
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Child : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Edad")]
        public int Age { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }
       

        public User User { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName
        {
            get
            {
                return $"{this.FirstName} {this.LastName}";
            }
        }
    }
}
