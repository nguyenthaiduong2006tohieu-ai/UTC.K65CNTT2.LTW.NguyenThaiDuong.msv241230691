namespace Lab1.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên[cite: 1]
        public string? Name { get; set; } // Họ tên[cite: 1]
        public string? Email { get; set; } // Email[cite: 1]
        public string? Password { get; set; } // Mật khẩu[cite: 1]
        public Branch? Branch { get; set; } // Ngành học[cite: 1]
        public Gender? Gender { get; set; } // Giới tính[cite: 1]
        public bool IsRegular { get; set; } // Hệ: true chính qui, false - phi cq[cite: 1]
        public string? Address { get; set; } // Địa chỉ[cite: 1]
        public DateTime DateOfBorth { get; set; } // Ngày sinh[cite: 1]
    }
}