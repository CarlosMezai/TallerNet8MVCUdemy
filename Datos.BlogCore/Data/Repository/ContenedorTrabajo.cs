using BlogCore.Data;
using Datos.BlogCore.Data.Repository.IRepository;
using Models.BlogCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.BlogCore.Data.Repository 
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {

        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepositorio(_db);
            Articulo = new ArticuloRepositorio(_db);
            Slider = new SliderRepositorio(_db);
        }

        public ICategoriaRepository Categoria { get; private set;}
        public IArticuloRepository Articulo { get; private set;}
        public ISliderRepository Slider { get; private set;}

        public void Dispose()
        { 
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
