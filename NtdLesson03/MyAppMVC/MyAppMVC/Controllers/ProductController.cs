using Microsoft.AspNetCore.Mvc;
using MyAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAppMVC.Controllers
{
    public class ProductController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Quần Áo" },
            new Category { Id = 2, Name = "Túi xách" },
            new Category { Id = 3, Name = "Đồng hồ" },
            new Category { Id = 4, Name = "Ti vi" },
            new Category { Id = 5, Name = "Tủ lạnh" },
            new Category { Id = 6, Name = "Máy bơm" },
            new Category { Id = 7, Name = "Quạt điện" },
            new Category { Id = 8, Name = "Lò sưởi" }
        };
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Bộ đồ bơi cho trẻ em nam", Image = "/images/bag1.png", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit...", Status = true, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 2, Name = "Bộ đồ bơi cho trẻ em nữ", Image = "/images/bag1.png", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit...", Status = true, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 3, Name = "Bộ đồ bơi cho trẻ em từ 3-5 tuổi", Image = "/images/bag1.png", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit...", Status = true, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 4, Name = "Bộ đồ bơi cho trẻ em thời trang", Image = "/images/bag1.png", Price = 50000, SalePrice = 35000, CategoryId = 1, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit...", Status = true, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 5, Name = "Túi thời trang mẫu mới 2021", Image = "/images/bag1.png", Price = 50000, SalePrice = 35000, CategoryId = 2, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit...", Status = true, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) },
            new Product { Id = 6, Name = "Túi thời trang da cá sấu", Image = "/images/bag1.png", Price = 50000, SalePrice = 35000, CategoryId = 2, Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit...", Status = true, CreatedAt = new DateTime(2021, 7, 15, 12, 0, 0) }
        };
        [Route("san-pham", Name = "sanpham")]
        public IActionResult Index(int? categoryId)
        {
            var productList = products;
            if (categoryId.HasValue)
            {
                productList = products.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Categories = categories;
            ViewBag.Products = productList;
            return View();
        }
        [Route("chi-tiet-san-pham", Name = "chitiet")]
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            ViewBag.Product = product;
            return View();
        }
    }
}