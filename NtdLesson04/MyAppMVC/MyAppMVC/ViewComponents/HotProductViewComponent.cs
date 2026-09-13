using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;
using System.Collections.Generic;

namespace MyAppMVC.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var hotProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/bag1.png", Price = 1500000 },
                new Product { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/bag1.png", Price = 1500000 },
                new Product { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/bag1.png", Price = 1500000 }
            };
            return View(hotProducts);
        }
    }
}