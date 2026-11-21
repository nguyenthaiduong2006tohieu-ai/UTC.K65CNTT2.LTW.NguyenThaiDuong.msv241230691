using Microsoft.AspNetCore.Mvc;
using Ntd_Day14.Models;

namespace Ntd_Day14.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext _db;
        public HomeController(QlnhaSachContext db) => _db = db;
        public IActionResult Index()
        {
            var ds = _db.Saches
                .Where(s => s.Gia != null && s.Gia >= 100)
                .ToList();
            ViewBag.TieuDe = "NGUYỄN THÁI DƯƠNG";
            return View(ds);
        }
        public IActionResult LocTheoTheLoai(int maTL, string tenTL)
        {
            var ds = _db.Saches
                .Where(s => s.MaTl == maTL)
                .ToList();
            ViewBag.TieuDe = tenTL.ToUpper();
            return PartialView("_DanhSachSach", ds);
        }
    }
}