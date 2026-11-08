using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson12.Data;

namespace NtdLesson12.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        private readonly SchoolContext db;

        public MajorViewComponent(SchoolContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var majors = await db.Majors.ToListAsync();
            return View("RenderMajor", majors);
        }
    }
}