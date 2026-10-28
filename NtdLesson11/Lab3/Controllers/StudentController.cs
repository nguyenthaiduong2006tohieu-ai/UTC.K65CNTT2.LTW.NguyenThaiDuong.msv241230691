using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> listStudents = new List<Student>()
        {
            new Student() { Id = 101, Name = "Hải Nam", Branch = Branch.IT, Gender = Gender.Male, IsRegular = true, Address = "A1-2018", Email = "nam@gmail.com", Score = 8.5f },
            new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE, Gender = Gender.Female, IsRegular = true, Address = "A1-2019", Email = "tu@gmail.com", Score = 9.0f }
        };

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            // Kiểm tra thủ công khoảng ngày sinh từ 1963 đến 2005 để tránh xung đột định dạng phía Model
            if (s.DateOfBorth < new DateTime(1963, 1, 1) || s.DateOfBorth > new DateTime(2005, 12, 31))
            {
                ModelState.AddModelError("DateOfBorth", "Ngày sinh phải từ năm 1963 đến 2005");
            }

            if (ModelState.IsValid)
            {
                s.Id = listStudents.Any() ? listStudents.Last<Student>().Id + 1 : 101;
                listStudents.Add(s);
                return View("Index", listStudents);
            }

            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "IT" },
                new SelectListItem { Text = "BE", Value = "BE" },
                new SelectListItem { Text = "CE", Value = "CE" },
                new SelectListItem { Text = "EE", Value = "EE" }
            };
            return View(s);
        }
    }
}