using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BlogCore
{
    public class Articulo
    {
        public Articulo()
        {
            FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy");
        }


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre para el artículo")]
        [Display(Name = "Nombre del Artículo")]
        public string Nombre{ get; set; }

        [Required(ErrorMessage = "Ingrese una descripción para el artículo")]
        public string Descripcion { get; set; }


        [Display(Name = "Fecha de Creación")]
        public string? FechaCreacion { get; set; }

        
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string Urlmagen { get; set; }

        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }
}
