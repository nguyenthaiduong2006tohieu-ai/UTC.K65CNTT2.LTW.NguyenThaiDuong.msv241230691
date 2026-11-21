using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntd_Day14.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn thể loại")]
    public int MaTl { get; set; }

    [Required(ErrorMessage = "Tên sách không được để trống")]
    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(50, 1000, ErrorMessage = "Giá phải là số từ 50 đến 1000")]
    public decimal? Gia { get; set; }

    [RegularExpression(@"^.*\.(jpg|jpeg|png|webp)$", ErrorMessage = "Ảnh phải có đuôi .jpg, .jpeg, .png hoặc .webp")]
    public string? Anh { get; set; }

    public virtual TheLoai? MaTlNavigation { get; set; }
}