using Datos.BlogCore.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SliderController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
