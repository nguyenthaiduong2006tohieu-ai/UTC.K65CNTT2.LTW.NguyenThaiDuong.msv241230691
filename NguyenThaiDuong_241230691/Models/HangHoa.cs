using System.ComponentModel.DataAnnotations;
namespace NguyenThaiDuong_241230691.Models
{
    public partial class HangHoa
    {
        public int MaHang { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn loại hàng")]
        public int MaLoai { get; set; }

        [Required(ErrorMessage = "Tên hàng không được để trống")]
        public string TenHang { get; set; } = null!;
        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(100, 5000, ErrorMessage = "Giá phải là số và nằm trong giới hạn 100 đến 5000")]
        public decimal? Gia { get; set; }
        [Required(ErrorMessage = "Tên ảnh không được để trống")]
        [RegularExpression(@"^[\w,\s-]+\.(jpg|jpeg|png|gif)$", ErrorMessage = "Tên ảnh không hợp lệ. Vui lòng nhập tên ảnh hợp lệ (ví dụ: image.jpg)")]
        public string? Anh { get; set; }
        public virtual LoaiHang? MaLoaiNavigation { get; set; }
    }
}
