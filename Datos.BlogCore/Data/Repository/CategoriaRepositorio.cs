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
    public class CategoriaRepositorio : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;

        }
        public void Update(Categoria categoria)
        {
            var objDb = _db.Categoria.FirstOrDefault(s => s.Id == categoria.Id );
            objDb.Nombre = categoria.Nombre;
            objDb.Orden = categoria.Orden;

            _db.SaveChanges();
            
        }
    }
}
