using Microsoft.AspNetCore.Mvc;
using StockApp.Core.Application.Interfaces.Services.IProduct;
using StockApp.Core.Application.ViewModel.Products;


namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;

        public HomeController(IProductServices services)
        {
            _productServices = services;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productServices.getAllservice());
        }

        public async Task<IActionResult> Create()
        {

            return View("SaveModels", new SaveProductViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductViewModel saveProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveModels",saveProduct);
            }

            await _productServices.addServices(saveProduct);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }


        public async Task<IActionResult> Edit(int id)
        {
            return View("SaveModels", await _productServices.getByIDservice(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductViewModel saveProduct)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveModels", saveProduct);
            }

            await _productServices.updateServices(saveProduct);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _productServices.deleteService(id);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

    }
}