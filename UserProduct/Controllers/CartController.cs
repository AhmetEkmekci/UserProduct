using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserProduct.Models;
using UserProduct.Service;

namespace UserProduct.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataService dataService;

        public CartController(ILogger<HomeController> logger, IDataService dataService)
        {
            this.dataService = dataService;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int Id)
        {
            ViewBag.Products = await dataService.GetProducts();
            ViewBag.UserId = Id;
            var data = await dataService.GetUserCart(Id);
            return View(data);
        }

        public async Task<IActionResult> CartUpdate(int UserId, int ProductId, int Quantity)
        {
            await dataService.UpdateCart(new Domain.CartDto() 
            {
                UserId = UserId,
                Quantity = Quantity,
                ProductId = ProductId,
            });
            return Json("Ürün sepete eklendi.");
        }

        public async Task<IActionResult> CartRemoveItem(int UserId, int ProductId)
        {
            await dataService.DeleteCart(UserId, ProductId);

            return Json("Ürün kaldırıldı.");
        }

        public async Task<IActionResult> CartClear(int UserId)
        {
            await dataService.ClearUserCart(UserId);

            return Json("Sepet temizlendi.");
        }

        public async Task<IActionResult> CartData(int UserId)
        {
            var data = await dataService.GetUserCart(UserId);
            return View("_cart", data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
