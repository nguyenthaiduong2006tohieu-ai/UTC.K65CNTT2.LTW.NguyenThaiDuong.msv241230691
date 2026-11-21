using Microsoft.AspNetCore.Mvc;
using Ntd_Day15.Models;
namespace Ntd_Day15.ViewComponents
{
    public class LoaiTaiSanViewComponent : ViewComponent
    {
        private readonly QltaiSanContext _db;
        public LoaiTaiSanViewComponent(QltaiSanContext db) => _db = db;

        public IViewComponentResult Invoke()
        {
            var ds = _db.LoaiTaiSans.ToList();
            return View(ds);
        }
    }
}
