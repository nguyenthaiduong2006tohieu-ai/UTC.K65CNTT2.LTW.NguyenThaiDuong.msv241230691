using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyAppMVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }

        public List<Book> GetBookList()
        {
            return new List<Book>
            {
                new Book { Id = 1, Title = "Chí Phèo", AuthorId = 1, GenreId = 1, Image = "/images/bag1.png", Price = 500000, Sumary = "Tác phẩm hiện thực phê phán", TotalPage = 250 },
                new Book { Id = 2, Title = "Lão Hạc", AuthorId = 1, GenreId = 1, Image = "/images/bag1.png", Price = 700000, Sumary = "Tác phẩm nhân đạo", TotalPage = 180 },
                new Book { Id = 4, Title = "Conan Phiêu lưu ký", AuthorId = 1, GenreId = 1, Image = "/images/bag1.png", Price = 550000, Sumary = "Truyện tranh phiêu lưu", TotalPage = 300 },
                new Book { Id = 6, Title = "Đường Xưa Mây Trắng", AuthorId = 1, GenreId = 1, Image = "/images/bag1.png", Price = 850000, Sumary = "Sách triết lý cuộc sống", TotalPage = 420 }
            };
        }

        public Book GetBookById(int id)
        {
            return this.GetBookList().FirstOrDefault(b => b.Id == id);
        }

        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Nam Cao" },
            new SelectListItem { Value = "2", Text = "Ngô Tất Tố" },
            new SelectListItem { Value = "3", Text = "Adamkhoom" },
            new SelectListItem { Value = "4", Text = "Thiền sư Thích Nhất Hạnh" }
        };

        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "Truyện tranh" },
            new SelectListItem { Value = "2", Text = "Văn học đương đại" },
            new SelectListItem { Value = "3", Text = "Phật học phổ thông" },
            new SelectListItem { Value = "4", Text = "Truyện cười" }
        };
    }
}