using LibraryManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(200);
                entity.Property(b => b.Author).IsRequired().HasMaxLength(100);
                entity.Property(b => b.ISBN).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.HasOne(l => l.Book)
                      .WithMany(b => b.Loans)
                      .HasForeignKey(l => l.BookId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
