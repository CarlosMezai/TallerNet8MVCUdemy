using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BlogCore.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {

        //Se debn agregar los diferentes respositorios

        ICategoriaRepository Categoria { get; }


        void Save();
        
    }
}
