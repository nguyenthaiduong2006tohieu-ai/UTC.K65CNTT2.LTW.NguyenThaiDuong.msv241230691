using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NtdLesson07.Models
{
    /// <summary>
    /// Model class Member
    /// 
    /// Author: Chung trinhj
    /// </summary>
    public class NtdMember
    {
        public int Id { get; set; }

        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tài khoản có độ dài trong khoảng 3-20 ký tự")]
        public string NtdUserName { get; set; }

        [DisplayName("Mật khẩu")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu tối thiểu 8 ký tự")]
        public string NtdPassword { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string NtdEmail { get; set; }

        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập điện thoại")]
        [RegularExpression(@"^0\d{9}", ErrorMessage = "Điện phải là 10 ký tự số, bắt đầu bằng số 0 ")]
        public string NtdPhone { get; set; }
    }
}