using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace NtdLesson01
{
    public class Database
    {
        public List<Course> Courses { get; set; } = new List<Course> {
            new Course { Ma = "NET", Ten = "ASP.NET Core MVC UTC", Phi = 6000000, Gio = 60, TrangThai = true },
            new Course { Ma = "REACT", Ten = "ReactJS Frontend", Phi = 4500000, Gio = 45, TrangThai = true }
        };
        public List<ClassRoom> Classes { get; set; } = new List<ClassRoom> {
            new ClassRoom { Ma = "C01", Ten = "Lớp .NET K65", MaKhoa = "NET", NgayKG = DateTime.Today.AddDays(3), LichHoc = "2-4-6", SiSo = 20, TrangThai = "SapKhaiGiang" },
            new ClassRoom { Ma = "C02", Ten = "Lớp React K65", MaKhoa = "REACT", NgayKG = DateTime.Today.AddDays(-10), LichHoc = "3-5-7", SiSo = 15, TrangThai = "DangHoc" }
        };
        public List<Student> Students { get; set; } = new List<Student> {
            new Student { Ma = "HV01", Ten = "Trần Văn Chung", Sdt = "0978611889", Email = "chung@utc.edu.vn", DiaChi = "Hà Nội", NgaySinh = DateTime.Parse("2003-05-10"), NgayDk = DateTime.Today },
            new Student { Ma = "HV02", Ten = "Lê Thị Mai", Sdt = "0912345678", Email = "mai@utc.edu.vn", DiaChi = "Nam Định", NgaySinh = DateTime.Parse("2004-08-20"), NgayDk = DateTime.Today }
        };
        public List<Registration> Registrations { get; set; } = new List<Registration> {
            new Registration { Ma = "DK01", MaHV = "HV01", MaLop = "C01", Phi = 6000000, DaDong = 6000000, Huy = false },
            new Registration { Ma = "DK02", MaHV = "HV02", MaLop = "C01", Phi = 6000000, DaDong = 2000000, Huy = false }
        };
        public List<StudentCare> Cares { get; set; } = new List<StudentCare> {
            new StudentCare { Ma = "CS01", MaHV = "HV02", Kenh = "Zalo", NoiDung = "Thu học phí đợt 2", KetQua = "Hẹn nộp", NgayCS = DateTime.Today, NgayHen = DateTime.Today }
        };

        public void Save() => File.WriteAllText("database.json", JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
        public void ExportCsv() => File.WriteAllText("students.csv", "Ma,Ten,Sdt\n" + string.Join("\n", Students.Select(s => $"{s.Ma},{s.Ten},{s.Sdt}")), Encoding.UTF8);
        public static void Log(string msg) => File.AppendAllText("error.log", $"[{DateTime.Now}] {msg}\n");
    }
}