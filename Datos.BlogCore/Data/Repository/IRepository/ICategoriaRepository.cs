using Models.BlogCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BlogCore.Data.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {

        void Update(Categoria categoria);
        
    }
}
