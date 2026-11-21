using Microsoft.AspNetCore.Mvc;
using Ntd_Day14.Models;

namespace Ntd_Day14.ViewComponents
{
    public class TheLoaiViewComponent : ViewComponent
    {
        private readonly QlnhaSachContext _db;
        public TheLoaiViewComponent(QlnhaSachContext db) => _db = db;

        public IViewComponentResult Invoke()
        {
            var ds = _db.TheLoais.ToList();
            return View(ds);
        }
    }
}