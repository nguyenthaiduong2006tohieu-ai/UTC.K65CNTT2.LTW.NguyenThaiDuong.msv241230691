using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson12.Data;

public class LearnerController : Controller
{
    private readonly SchoolContext db;
    public LearnerController(SchoolContext context) { db = context; }

    // 1. Action Index cho lọc đồng bộ
    public IActionResult Index(int? mid)
    {
        if (mid == null)
        {
            var learners = db.Learners.Include(m => m.Major).ToList();
            return View(learners);
        }
        else
        {
            var learners = db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major).ToList();
            return View(learners);
        }
    }

    // 2. Action trả về PartialView cho AJAX
    public IActionResult LearnerByMajorID(int mid)
    {
        var learners = db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major).ToList();
        return PartialView("LearnerTable", learners);
    }
}