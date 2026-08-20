using MyAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace bttl.Controllers // Dùng bttl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action Index: Tạo danh sách 4 sản phẩm
        public IActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product Name 1", ImageUrl = "/images/bag1.png" },
                new Product { Id = 2, Name = "Product Name 2", ImageUrl = "/images/bag1.png" },
                new Product { Id = 3, Name = "Product Name 3", ImageUrl = "/images/bag1.png" },
                new Product { Id = 4, Name = "Product Name 4", ImageUrl = "/images/bag1.png" }
            };

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}