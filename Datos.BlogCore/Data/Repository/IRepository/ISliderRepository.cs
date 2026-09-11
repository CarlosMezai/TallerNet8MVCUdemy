using Models.BlogCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos.BlogCore.Data.Repository.IRepository
{
    public interface ISliderRepository : IRepository<Slider>
    {
        void Update(Slider slider);
    }
}
