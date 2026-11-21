using Microsoft.AspNetCore.Mvc;
using NguyenThaiDuong_241230691.Models;

namespace NguyenThaiDuong_241230691.ViewComponents
{
    public class MenuLoaiHangViewComponent : ViewComponent
    {
        private readonly QlhangHoaContext _context;

        public MenuLoaiHangViewComponent(QlhangHoaContext context) => _context = context;

        public IViewComponentResult Invoke()
        {
            return View(_context.LoaiHangs.ToList());
        }
    }
}