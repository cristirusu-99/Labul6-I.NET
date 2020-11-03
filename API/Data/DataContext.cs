using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().HasKey(c=> new {c.Id});
            modelBuilder.Entity<Todo>().ToTable("Products");
        }
        
    }
}