using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NtdLesson07.Models;

namespace NtdLesson07.Controllers
{
    public class NtdMembersController : Controller
    {
        private static List<NtdMember> NtdMembers = new List<NtdMember>();
        // GET: NtdMembersController
        public ActionResult Index()
        {
            return View(NtdMembers);
        }

        // GET: NtdMembersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NtdMembersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NtdMembersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NtdMember NtdMember)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(NtdMember);
                }
                NtdMembers.Add(NtdMember);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NtdMembersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NtdMembersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NtdMembersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NtdMembersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
