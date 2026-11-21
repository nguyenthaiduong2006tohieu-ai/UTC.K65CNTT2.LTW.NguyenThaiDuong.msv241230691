using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenThaiDuong_241230691.Models;

namespace NguyenThaiDuong_241230691.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlhangHoaContext _context;

        public HomeController(QlhangHoaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ds = _context.HangHoas.Where(h => h.Gia >= 100).ToList();
            return View(ds);
        }

        public IActionResult LocHangTheoLoai(int maLoai)
        {
            var ds = _context.HangHoas.Where(h => h.MaLoai == maLoai && h.Gia >= 100).ToList();
            return PartialView("_DanhSachHangPartial", ds);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HangHoa hh)
        {
            if (ModelState.IsValid)
            {
                _context.HangHoas.Add(hh);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai", hh.MaLoai);
            return View(hh);
        }
    }
}