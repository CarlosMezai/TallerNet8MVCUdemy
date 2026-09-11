using Datos.BlogCore.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Models.BlogCore.ViewModels;
using Models.BlogCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace BlogCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticulosController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ArticulosController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArticuloVM artiVM = new ArticuloVM()
            {
                Articulo = new Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()

            };
            return View(artiVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloVM artiVm)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if (artiVm.Articulo.Id == 0 && archivos.Count() > 0)
                {
                    //Nuevo articulo
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStream);
                    }

                    artiVm.Articulo.Urlmagen = @"\imagenes\articulos\" + nombreArchivo + extension;
                    artiVm.Articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Articulo.Add(artiVm.Articulo);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Seleccione una imagen para el artículo");
                }
            }
            artiVm.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            return View(artiVm);

        }

        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    ArticuloVM artiVM = new ArticuloVM()
        //    {
        //        Articulo = new Articulo(),
        //        ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
        //    };

        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    artiVM.Articulo = _contenedorTrabajo.Articulo.GetFirstOrDefault(u => u.Id == id);

        //    if (artiVM.Articulo == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(artiVM);
        //}


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ArticuloVM artiVM = new ArticuloVM()
            {
                Articulo = new Articulo(),
                ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias()
            };

            if (id != null)
            {
                artiVM.Articulo = _contenedorTrabajo.Articulo.Get(id.GetValueOrDefault());
                
            }
            return View(artiVM);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ArticuloVM artiVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostEnvironment.WebRootPath;
                //var archivos = HttpContext.Request.Form.Files;

                var articuloDesdeBd = _contenedorTrabajo.Articulo.Get(artiVM.Articulo.Id);


                if (artiVM.Imagen != null && artiVM.Imagen.Length > 0)
                {
                    //Eliminar imagene anterior
                    var rutaImagenAntigua = Path.Combine(rutaPrincipal, articuloDesdeBd.Urlmagen.TrimStart('\\'));
                    if (System.IO.File.Exists(rutaImagenAntigua))
                    {
                        System.IO.File.Delete(rutaImagenAntigua);
                    }
                    //Guardar nueva imagen 
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\articulos");
                    var extension = Path.GetExtension(artiVM.Imagen.FileName);

                    using (var fileStream = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        artiVM.Imagen.CopyTo(fileStream);
                    }

                    artiVM.Articulo.Urlmagen = @"\imagenes\articulos\" + nombreArchivo + extension;
                    artiVM.Articulo.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.Articulo.Update(artiVM.Articulo);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Aqui cuando la img ya existe y mantiene la misma
                    artiVM.Articulo.Urlmagen = articuloDesdeBd.Urlmagen;
                }
                _contenedorTrabajo.Articulo.Update(artiVM.Articulo);
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }
            artiVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
            return View(artiVM);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(ArticuloVM artiVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string rutaPrincipal = _hostEnvironment.WebRootPath;
        //        var archivos = HttpContext.Request.Form.Files;

        //        var articuloDesdeBd = _contenedorTrabajo.Articulo.Get(artiVM.Articulo.Id);


        //        if (archivos.Count() > 0)
        //        {
        //            //Nueva magen articulo
        //            string nombreArchivo = Guid.NewGuid().ToString();
        //            var subidas = Path.Combine(rutaPrincipal, @"imagenes\articulos");
        //            var extension = Path.GetExtension(archivos[0].FileName);
        //            var nuevaExtension = Path.GetExtension(archivos[0].FileName);
        //            var rutaImagen = Path.Combine(rutaPrincipal, articuloDesdeBd.Urlmagen.TrimStart('\\')); 

        //            //Eliminar imagen reemplazada
        //            if(System.IO.File.Exists(rutaImagen))
        //            {
        //                System.IO.File.Delete(rutaImagen);
        //            }

        //            //Nueva Imagen
        //            using (var fileStream = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
        //            {
        //                archivos[0].CopyTo(fileStream);
        //            }

        //            artiVM.Articulo.Urlmagen = @"\imagenes\articulos\" + nombreArchivo + extension;
        //            artiVM.Articulo.FechaCreacion = DateTime.Now.ToString();

        //            _contenedorTrabajo.Articulo.Update(artiVM.Articulo);
        //            _contenedorTrabajo.Save();

        //            return RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            //Aqui cuando la img ya existe y mantiene la misma
        //            artiVM.Articulo.Urlmagen = articuloDesdeBd.Urlmagen;
        //        }
        //        _contenedorTrabajo.Articulo.Update(artiVM.Articulo);
        //        _contenedorTrabajo.Save();

        //        return RedirectToAction(nameof(Index));
        //    }
        //    artiVM.ListaCategorias = _contenedorTrabajo.Categoria.GetListaCategorias();
        //    return View(artiVM);

        //}



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var articulodesdeBd = _contenedorTrabajo.Articulo.Get(id);
            string rutaDirectorioprincipal = _hostEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioprincipal, articulodesdeBd.Urlmagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (articulodesdeBd == null)
            {
                return Json(new { success = false, message = "Error al borrar artículo" });
            }
            _contenedorTrabajo.Articulo.Remove(articulodesdeBd);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Artículo borrada correctamente" });
        }



        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Articulo.GetAll(includeProperties: "Categoria") });
        }
        #endregion
    }
}
