using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BlogCore
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Estado { get; set; }

        [DataType(DataType.ImageUrl)]
        public string UrlImagen { get; set; }
    }
}
