using System;
using System.Linq;

namespace NtdLesson01
{
    public class ReportService
    {
        private readonly Database db;
        public ReportService(Database db) => this.db = db;

        public void Show10Reports()
        {
            Console.WriteLine("\n--- KẾT QUẢ 10 BÁO CÁO LINQ ---");
            Console.WriteLine("1. Số HV theo khóa: " + string.Join(", ", db.Courses.Select(c => $"{c.Ma}: {db.Registrations.Count(r => db.Classes.Any(cl => cl.Ma == r.MaLop && cl.MaKhoa == c.Ma))} HV")));
            Console.WriteLine("2. Sĩ số các lớp: " + string.Join(", ", db.Classes.Select(cl => $"{cl.Ma}: {db.Registrations.Count(r => r.MaLop == cl.Ma && !r.Huy)}/{cl.SiSo}")));
            Console.WriteLine("3. Lớp sắp khai giảng: " + string.Join(", ", db.Classes.Where(c => c.TrangThai == "SapKhaiGiang").Select(c => c.Ten)));
            Console.WriteLine("4. HV nợ học phí: " + string.Join(", ", db.Registrations.Where(r => r.Phi > r.DaDong).Select(r => $"{r.MaHV} (nợ {(r.Phi - r.DaDong):N0}đ)")));
            Console.WriteLine($"5. Tổng thực thu: {db.Registrations.Where(r => !r.Huy).Sum(r => r.DaDong):N0} đ | Nợ: {db.Registrations.Where(r => !r.Huy).Sum(r => r.Phi - r.DaDong):N0} đ");
            Console.WriteLine("6. Doanh thu theo tháng: " + string.Join(", ", db.Registrations.GroupBy(r => DateTime.Today.Month).Select(g => $"T{g.Key}: {g.Sum(x => x.DaDong):N0} đ")));
            var top = db.Courses.OrderByDescending(c => db.Registrations.Count(r => db.Classes.Any(cl => cl.Ma == r.MaLop && cl.MaKhoa == c.Ma))).FirstOrDefault();
            Console.WriteLine($"7. Khóa nhiều HV nhất: {top?.Ten}");
            Console.WriteLine("8. Lịch hẹn hôm nay: " + string.Join(", ", db.Cares.Where(c => c.NgayHen.Date == DateTime.Today).Select(c => $"{c.MaHV} ({c.NoiDung})")));
            Console.WriteLine("9. HV chưa chăm sóc: " + string.Join(", ", db.Students.Where(s => !db.Cares.Any(c => c.MaHV == s.Ma)).Select(s => s.Ten)));
            int tong = db.Registrations.Count(r => !r.Huy);
            int du = db.Registrations.Count(r => !r.Huy && r.DaDong >= r.Phi);
            Console.WriteLine($"10. Tỷ lệ hoàn thành học phí: {(tong > 0 ? (double)du / tong * 100 : 0):F1}%");
        }
    }
}