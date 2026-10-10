using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace NtdLesson08.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OrderBook> OrderBooks { get; set; }
    }
}