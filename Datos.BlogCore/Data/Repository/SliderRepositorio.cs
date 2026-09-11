using Datos.BlogCore.Data.Repository.IRepository;
using Models.BlogCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.Data;


namespace Datos.BlogCore.Data.Repository
{
    public class SliderRepositorio : Repository<Slider>, ISliderRepository
    {

        private readonly ApplicationDbContext _db;
        public SliderRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Slider slider)
        {
            var objDb = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
            objDb.Nombre = slider.Nombre;
            objDb.Estado = slider.Estado;
            objDb.UrlImagen = slider.UrlImagen;
             //_db.SaveChanges();
        }
    }
}
