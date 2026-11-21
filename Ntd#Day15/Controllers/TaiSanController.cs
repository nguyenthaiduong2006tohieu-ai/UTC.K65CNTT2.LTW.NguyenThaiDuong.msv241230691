using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ntd_Day15.Models;

namespace Ntd_Day15.Controllers
{
    public class TaiSanController : Controller
    {
        private readonly QltaiSanContext _db;
        public TaiSanController(QltaiSanContext db) => _db = db;

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaiSan ts)
        {
            if (ModelState.IsValid)
            {
                _db.TaiSans.Add(ts);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }
    }
}