using System;

namespace NtdLesson01
{
    public class Course { public string Ma, Ten, MoTa; public decimal Phi; public int Gio; public bool TrangThai; }
    public class ClassRoom { public string Ma, Ten, MaKhoa, LichHoc, TrangThai; public DateTime NgayKG; public int SiSo; }
    public class Student { public string Ma, Ten, Sdt, Email, DiaChi; public DateTime NgaySinh, NgayDk; }
    public class Registration { public string Ma, MaHV, MaLop; public decimal Phi, DaDong; public bool Huy; }
    public class StudentCare { public string Ma, MaHV, Kenh, NoiDung, KetQua; public DateTime NgayCS, NgayHen; }
}