using System;
using System.Linq;
using System.Text;

namespace NtdLesson01
{
    internal class Program
    {
        static Database db = new Database();
        static ReportService report = new ReportService(db);

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string chon;
            do
            {
                Console.WriteLine("\n===== HỆ THỐNG QUẢN LÝ ĐÀO TẠO DEVMASTE =====");
                Console.WriteLine("1. Thêm khóa học      | 2. DS Lớp học        | 3. Thêm Học Viên");
                Console.WriteLine("4. Đăng ký & Đóng phí | 5. Ghi nhận Chăm sóc | 6. 10 Báo cáo LINQ");
                Console.WriteLine("7. Xuất file CSV      | 8. Lưu DB (JSON)     | 0. Thoát");
                Console.Write("Chọn chức năng: ");
                chon = Console.ReadLine()?.Trim();

                switch (chon)
                {
                    case "1":
                        Console.Write("Mã KH: "); string mkh = Console.ReadLine();
                        Console.Write("Tên KH: "); string tkh = Console.ReadLine();
                        Console.Write("Học phí: "); decimal.TryParse(Console.ReadLine(), out decimal hp);
                        db.Courses.Add(new Course { Ma = mkh, Ten = tkh, Phi = hp, Gio = 40, TrangThai = true });
                        Console.WriteLine("-> Thêm khóa học thành công!");
                        break;
                    case "2":
                        foreach (var c in db.Classes) Console.WriteLine($"[{c.Ma}] {c.Ten} - Khóa: {c.MaKhoa} - KG: {c.NgayKG:dd/MM/yyyy} - Max: {c.SiSo} HV");
                        break;
                    case "3":
                        Console.Write("Mã HV: "); string mhv = Console.ReadLine();
                        Console.Write("Tên: "); string thv = Console.ReadLine();
                        Console.Write("SĐT: "); string sdt = Console.ReadLine();
                        if (db.Students.Any(s => s.Sdt == sdt)) { Console.WriteLine("-> Lỗi: Trùng số điện thoại!"); break; }
                        db.Students.Add(new Student { Ma = mhv, Ten = thv, Sdt = sdt, Email = thv + "@gmail.com", NgaySinh = DateTime.Today.AddYears(-20), NgayDk = DateTime.Today });
                        Console.WriteLine("-> Thêm học viên thành công!");
                        break;
                    case "4":
                        Console.Write("Mã HV: "); string hvDk = Console.ReadLine();
                        Console.Write("Mã Lớp: "); string lopDk = Console.ReadLine();
                        var l = db.Classes.FirstOrDefault(x => x.Ma == lopDk);
                        if (db.Registrations.Any(r => r.MaHV == hvDk && r.MaLop == lopDk && !r.Huy)) { Console.WriteLine("-> Lỗi: Đã đăng ký lớp này!"); break; }
                        if (db.Registrations.Count(r => r.MaLop == lopDk && !r.Huy) >= (l?.SiSo ?? 0)) { Console.WriteLine("-> Lỗi: Lớp đã đủ sĩ số!"); break; }
                        Console.Write("Tiền nộp đợt 1: "); decimal.TryParse(Console.ReadLine(), out decimal nop);
                        decimal phiGoc = db.Courses.FirstOrDefault(k => k.Ma == l?.MaKhoa)?.Phi ?? 5000000;
                        db.Registrations.Add(new Registration { Ma = "DK" + (db.Registrations.Count + 1), MaHV = hvDk, MaLop = lopDk, Phi = phiGoc, DaDong = nop });
                        Console.WriteLine("-> Đăng ký thành công!");
                        break;
                    case "5":
                        Console.Write("Mã HV: "); string hvCs = Console.ReadLine();
                        Console.Write("Nội dung: "); string nd = Console.ReadLine();
                        db.Cares.Add(new StudentCare { Ma = "CS" + (db.Cares.Count + 1), MaHV = hvCs, Kenh = "Zalo", NoiDung = nd, KetQua = "Đã gọi", NgayCS = DateTime.Today, NgayHen = DateTime.Today });
                        Console.WriteLine("-> Ghi nhận chăm sóc thành công!");
                        break;
                    case "6":
                        report.Show10Reports();
                        break;
                    case "7":
                        db.ExportCsv();
                        Console.WriteLine("-> Đã xuất students.csv!");
                        break;
                    case "8":
                        db.Save();
                        Console.WriteLine("-> Đã lưu database.json!");
                        break;
                }
            } while (chon != "0");
            db.Save();
        }
    }
}