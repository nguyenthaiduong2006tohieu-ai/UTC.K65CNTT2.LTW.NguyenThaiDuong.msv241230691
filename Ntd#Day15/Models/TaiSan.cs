using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntd_Day15.Models;

public partial class TaiSan
{
    public int MaTS { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn loại tài sản")]
    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên tài sản không được để trống")]
    public string TenTS { get; set; } = null!;

    [Required(ErrorMessage = "Nguyên giá không được để trống")]
    [Range(1, 2000, ErrorMessage = "Nguyên giá phải là số từ 1 đến 2000")]
    public decimal? NguyenGia { get; set; }

    [RegularExpression(@"^.*\.(jpg|jpeg|png|webp)$", ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; }
}