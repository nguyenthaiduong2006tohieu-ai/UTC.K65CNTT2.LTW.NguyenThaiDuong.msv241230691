using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ntd_Day14.Models;

namespace Ntd_Day14.Controllers
{
    public class SachController : Controller
    {
        private readonly QlnhaSachContext _db;
        public SachController(QlnhaSachContext db) => _db = db;

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTL = new SelectList(_db.TheLoais, "MaTl", "TenTl");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Sach sach)
        {
            if (ModelState.IsValid)
            {
                _db.Saches.Add(sach);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.MaTL = new SelectList(_db.TheLoais, "MaTl", "TenTl", sach.MaTl);
            return View(sach);
        }
    }
}