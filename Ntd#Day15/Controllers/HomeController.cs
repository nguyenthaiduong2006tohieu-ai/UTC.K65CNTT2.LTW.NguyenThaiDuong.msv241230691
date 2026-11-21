using Microsoft.AspNetCore.Mvc;
using Ntd_Day15.Models;

namespace Ntd_Day15.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext _db;
        public HomeController(QltaiSanContext db) => _db = db;

        public IActionResult Index()
        {
            var ds = _db.TaiSans
                .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                .ToList();
            ViewBag.TieuDe = "NGUYỄN THÁI DƯƠNG";
            return View(ds);
        }

        public IActionResult LocTheoLoai(int maLoai, string tenLoai)
        {
            var ds = _db.TaiSans
                .Where(t => t.MaLoai == maLoai && t.NguyenGia != null)
                .ToList();
            ViewBag.TieuDe = tenLoai.ToUpper();
            return PartialView("_DanhSachTaiSan", ds);
        }
    }
}