using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppLastItemGroupBy
{
    public class DBcon : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ChatConsoleDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Messages> Messages { get; set; }
    }
    public class Users
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Messages
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public int UserID { get; set; }
        public virtual Users User { get; set; }
        
    }
}
