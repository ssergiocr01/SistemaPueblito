namespace SistemaPueblito.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class State : IEntity
    {
        public int Id { get; set; }

        [Display(Name ="Estado")]
        [MaxLength(50,ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        public string Name { get; set; }
    }
}
