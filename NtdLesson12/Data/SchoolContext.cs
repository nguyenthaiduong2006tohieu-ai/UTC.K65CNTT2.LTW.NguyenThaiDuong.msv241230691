using Microsoft.EntityFrameworkCore;
using NtdLesson12.Models;
using System.Collections.Generic;

namespace NtdLesson12.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Major> Majors { get; set; }
        public DbSet<Learner> Learners { get; set; }
    }
}