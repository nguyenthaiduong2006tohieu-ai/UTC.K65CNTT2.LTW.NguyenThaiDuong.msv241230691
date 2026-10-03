using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NtdLesson07.Models;

namespace NtdLesson07.Controllers
{
    public class ProductsController : Controller
    {
        private static List<Category> categories = new List<Category>
        {
            new Category { Id = 1, Name = "Điện thoại" },
            new Category { Id = 2, Name = "Laptop" },
            new Category { Id = 3, Name = "Phụ kiện" }
        };

        private static List<Product> products = new List<Product>();

        public IActionResult Index()
        {
            ViewBag.Categories = categories;
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile)
        {
            if (product.SalePrice >= product.Price * 0.9f)
            {
                ModelState.AddModelError("SalePrice", "Giá khuyến mãi phải nhỏ hơn giá chuẩn ít nhất 10%");
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                string fileName = Path.GetFileName(imageFile.FileName);
                string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/products");

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                string filePath = Path.Combine(uploadDir, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                product.Image = "/products/" + fileName;
            }
            else
            {
                ModelState.AddModelError("Image", "Vui lòng chọn file ảnh sản phẩm");
            }

            if (ModelState.IsValid)
            {
                product.Id = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
                products.Add(product);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name", product.CategoryId);
            return View(product);
        }
    }
}