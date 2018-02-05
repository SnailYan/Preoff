using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JwtAuthsample.Models
{
    public partial class CoreTestContext : DbContext
    {
        public virtual DbSet<Tuser> Tuser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoreTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tuser>(entity =>
            {
                entity.ToTable("TUser");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CName)
                    .HasColumnName("C_Name")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.CValue)
                    .HasColumnName("C_Value")
                    .HasColumnType("nchar(10)");
            });
        }
    }
}
