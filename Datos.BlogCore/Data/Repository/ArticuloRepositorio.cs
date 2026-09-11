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
    public class ArticuloRepositorio : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _db;

        public ArticuloRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;

        }
        public void Update(Articulo articulo)
        {
            var objDb = _db.Articulo.FirstOrDefault(s => s.Id == articulo.Id );
            objDb.Nombre = articulo.Nombre;
            objDb.Descripcion = articulo.Descripcion;
            objDb.Urlmagen = articulo.Urlmagen;
            objDb.CategoriaId = articulo.CategoriaId;

            //_db.SaveChanges();
            
        }
    }
}
