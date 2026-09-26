using Microsoft.AspNetCore.Mvc;
using TvcLesson06Models.Models;

namespace TvcLesson06Models.Controllers
{
    public class TvcMemberController : Controller
    {
        // mock data
        private static readonly List<TvcMember> _tvcMembers = new List<TvcMember>()
        {
            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "DuongNguyen",
                TvcMemberPassword = "123456a@",
                TvcMemberEmail = "duongnguyen@gmail.com",
                TvcMemberFullName = "Nguyễn Thái Dương"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "NguyenVanA",
                TvcMemberPassword = "123456a@",
                TvcMemberEmail = "nguyenvana@gmail.com",
                TvcMemberFullName = "Nguyễn Văn A"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "NguyenVanB",
                TvcMemberPassword = "123456a@",
                TvcMemberEmail = "nguyenvanb@gmail.com",
                TvcMemberFullName = "Nguyễn Văn B"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "NguyenVanC",
                TvcMemberPassword = "123456a@",
                TvcMemberEmail = "nguyenvanc@gmail.com",
                TvcMemberFullName = "Nguyễn Văn C"
            },

            new TvcMember
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "NguyenVanD",
                TvcMemberPassword = "123456a@",
                TvcMemberEmail = "nguyenvand@gmail.com",
                TvcMemberFullName = "Nguyễn Văn D"
            }
        };

        // GET: LIST
        public IActionResult TvcIndex()
        {
            return View(_tvcMembers);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public IActionResult TvcCreate()
        {
            return View();
        }
        /// <summary>
        /// Create - submit form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TvcCreate(TvcMember tvcMember)
        {
            tvcMember.TvcMemberId = Guid.NewGuid().ToString();
            _tvcMembers.Add(tvcMember);
            return RedirectToAction("TvcIndex");
        }
        /// <summary>
        /// TvcEdit
        /// </summary>
        /// <returns></returns>
        public IActionResult TvcEdit(string id)
        {
            var tvcMember = _tvcMembers.FirstOrDefault(x => x.TvcMemberId.Equals(id));
            return View(tvcMember);
        }

        /// <summary>
        /// TvcEdit - submit form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TvcEdit(string id, TvcMember tvcMember)
        {
            for (int i = 0; i < _tvcMembers.Count; i++)
            {
                if (_tvcMembers[i].TvcMemberId == id)
                {
                    _tvcMembers[i].TvcMemberId = tvcMember.TvcMemberId;
                    _tvcMembers[i].TvcMemberUserName = tvcMember.TvcMemberUserName;
                    _tvcMembers[i].TvcMemberPassword = tvcMember.TvcMemberPassword;
                    _tvcMembers[i].TvcMemberFullName = tvcMember.TvcMemberFullName;
                    _tvcMembers[i].TvcMemberEmail = tvcMember.TvcMemberEmail;

                    break;
                }
            }

            return RedirectToAction("TvcIndex");
        }
        /// <summary>
        /// Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult TvcDetails(string id)
        {
            var tvcMember = _tvcMembers.FirstOrDefault(x => x.TvcMemberId.Equals(id));
            return View(tvcMember);
        }
        /// <summary>
        /// Delete - Get (Hiển thị trang xác nhận xóa)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult TvcDelete(string id)
        {
            var tvcMember = _tvcMembers.FirstOrDefault(x => x.TvcMemberId.Equals(id));
            return View(tvcMember);
        }

        /// <summary>
        /// Delete - Submit (Xóa thành viên khỏi danh sách)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("TvcDelete")]
        public IActionResult TvcDeleteConfirmed(string id)
        {
            var tvcMember = _tvcMembers.FirstOrDefault(x => x.TvcMemberId == id);
            if (tvcMember != null)
            {
                _tvcMembers.Remove(tvcMember);
            }
            return RedirectToAction("TvcIndex");
        }
        public IActionResult TvcGetDetails()
        {
            var tvcMember = new TvcMember()
            {
                TvcMemberId = Guid.NewGuid().ToString(),
                TvcMemberUserName = "DuongNguyen",
                TvcMemberPassword = "Duong2468",
                TvcMemberFullName = "Nguyễn Thái Dương",
                TvcMemberEmail = "duongnguyen@gmail.com"
            };
            return View(tvcMember);
        }
    }
}