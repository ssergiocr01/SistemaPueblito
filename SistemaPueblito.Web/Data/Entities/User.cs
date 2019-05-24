namespace SistemaPueblito.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        [Required]
        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener un máximo de {1} caracteres")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener un máximo de {1} caracteres")]
        public string LastName { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }

        public override bool EmailConfirmed { get => base.EmailConfirmed; set => base.EmailConfirmed = value; }

        [NotMapped]
        [Display(Name ="¿Es Administrador?")]
        public bool IsAdmin { get; set; }
    }
}
