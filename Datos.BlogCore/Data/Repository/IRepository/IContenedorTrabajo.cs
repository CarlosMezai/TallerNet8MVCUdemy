using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BlogCore.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {

        //Se deben agregar los diferentes respositorios

        ICategoriaRepository Categoria { get; }
        IArticuloRepository Articulo { get; }
        ISliderRepository Slider { get; }



        void Save();
        
    }
}
