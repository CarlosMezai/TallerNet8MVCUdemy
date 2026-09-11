using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BlogCore.ViewModels
{
    public class ArticuloVM
    {
        public Articulo Articulo { get; set;} 

        public IEnumerable<SelectListItem>? ListaCategorias { get; set; }

        public IFormFile? Imagen { get; set; }
    }
}
