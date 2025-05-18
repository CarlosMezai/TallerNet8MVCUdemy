using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BlogCore
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ingrese un nombre para la categoria")]
        [Display(Name ="Nombre de Categpría")]
        public string Nombre { get; set; }

        [Display(Name ="Orden de Visualización")]
        public int? Orden { get; set; }
    }
}
