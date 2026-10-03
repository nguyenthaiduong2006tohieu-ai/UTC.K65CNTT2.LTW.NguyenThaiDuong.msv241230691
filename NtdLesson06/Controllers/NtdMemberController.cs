using Microsoft.AspNetCore.Mvc;
using NtdLesson06Models.Models;

namespace NtdLesson06Models.Controllers
{
    public class NtdMemberController : Controller
    {
        // mock data
        private static readonly List<NtdMember> _NtdMembers = new List<NtdMember>()
        {
            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdMemberUserName = "DuongNguyen",
                NtdMemberPassword = "123456a@",
                NtdMemberEmail = "duongnguyen@gmail.com",
                NtdMemberFullName = "Nguyễn Thái Dương"
            },

            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdMemberUserName = "NguyenVanA",
                NtdMemberPassword = "123456a@",
                NtdMemberEmail = "nguyenvana@gmail.com",
                NtdMemberFullName = "Nguyễn Văn A"
            },

            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdMemberUserName = "NguyenVanB",
                NtdMemberPassword = "123456a@",
                NtdMemberEmail = "nguyenvanb@gmail.com",
                NtdMemberFullName = "Nguyễn Văn B"
            },

            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdMemberUserName = "NguyenVanC",
                NtdMemberPassword = "123456a@",
                NtdMemberEmail = "nguyenvanc@gmail.com",
                NtdMemberFullName = "Nguyễn Văn C"
            },

            new NtdMember
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdMemberUserName = "NguyenVanD",
                NtdMemberPassword = "123456a@",
                NtdMemberEmail = "nguyenvand@gmail.com",
                NtdMemberFullName = "Nguyễn Văn D"
            }
        };

        // GET: LIST
        public IActionResult NtdIndex()
        {
            return View(_NtdMembers);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <returns></returns>
        public IActionResult NtdCreate()
        {
            return View();
        }
        /// <summary>
        /// Create - submit form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NtdCreate(NtdMember NtdMember)
        {
            NtdMember.NtdMemberId = Guid.NewGuid().ToString();
            _NtdMembers.Add(NtdMember);
            return RedirectToAction("NtdIndex");
        }
        /// <summary>
        /// NtdEdit
        /// </summary>
        /// <returns></returns>
        public IActionResult NtdEdit(string id)
        {
            var NtdMember = _NtdMembers.FirstOrDefault(x => x.NtdMemberId.Equals(id));
            return View(NtdMember);
        }

        /// <summary>
        /// NtdEdit - submit form
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NtdEdit(string id, NtdMember NtdMember)
        {
            for (int i = 0; i < _NtdMembers.Count; i++)
            {
                if (_NtdMembers[i].NtdMemberId == id)
                {
                    _NtdMembers[i].NtdMemberId = NtdMember.NtdMemberId;
                    _NtdMembers[i].NtdMemberUserName = NtdMember.NtdMemberUserName;
                    _NtdMembers[i].NtdMemberPassword = NtdMember.NtdMemberPassword;
                    _NtdMembers[i].NtdMemberFullName = NtdMember.NtdMemberFullName;
                    _NtdMembers[i].NtdMemberEmail = NtdMember.NtdMemberEmail;

                    break;
                }
            }

            return RedirectToAction("NtdIndex");
        }
        /// <summary>
        /// Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult NtdDetails(string id)
        {
            var NtdMember = _NtdMembers.FirstOrDefault(x => x.NtdMemberId.Equals(id));
            return View(NtdMember);
        }
        /// <summary>
        /// Delete - Get (Hiển thị trang xác nhận xóa)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult NtdDelete(string id)
        {
            var NtdMember = _NtdMembers.FirstOrDefault(x => x.NtdMemberId.Equals(id));
            return View(NtdMember);
        }

        /// <summary>
        /// Delete - Submit (Xóa thành viên khỏi danh sách)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("NtdDelete")]
        public IActionResult NtdDeleteConfirmed(string id)
        {
            var NtdMember = _NtdMembers.FirstOrDefault(x => x.NtdMemberId == id);
            if (NtdMember != null)
            {
                _NtdMembers.Remove(NtdMember);
            }
            return RedirectToAction("NtdIndex");
        }
        public IActionResult NtdGetDetails()
        {
            var NtdMember = new NtdMember()
            {
                NtdMemberId = Guid.NewGuid().ToString(),
                NtdMemberUserName = "DuongNguyen",
                NtdMemberPassword = "Duong2468",
                NtdMemberFullName = "Nguyễn Thái Dương",
                NtdMemberEmail = "duongnguyen@gmail.com"
            };
            return View(NtdMember);
        }
    }
}