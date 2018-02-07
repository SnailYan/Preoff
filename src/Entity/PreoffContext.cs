using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Preoff.Entity
{
    public partial class PreoffContext : DbContext
    {
        public virtual DbSet<All> All { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Town> Town { get; set; }
        public virtual DbSet<Village> Village { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public PreoffContext(DbContextOptions<PreoffContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<All>(entity =>
            {
                entity.HasKey(e => e.Areacode);

                entity.ToTable("all");

                entity.Property(e => e.Areacode)
                    .HasColumnName("areacode")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Areaname)
                    .HasColumnName("areaname")
                    .HasMaxLength(100);

                entity.Property(e => e.Towercode)
                    .HasColumnName("towercode")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Areacode);

                entity.Property(e => e.Areacode)
                    .HasColumnName("areacode")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Areaname)
                    .HasColumnName("areaname")
                    .HasMaxLength(100);

                entity.Property(e => e.Towercode)
                    .HasColumnName("towercode")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.HasKey(e => e.Areacode);

                entity.Property(e => e.Areacode)
                    .HasColumnName("areacode")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Areaname)
                    .HasColumnName("areaname")
                    .HasMaxLength(100);

                entity.Property(e => e.Towercode)
                    .HasColumnName("towercode")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Areacode);

                entity.Property(e => e.Areacode)
                    .HasColumnName("areacode")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Areaname)
                    .HasColumnName("areaname")
                    .HasMaxLength(100);

                entity.Property(e => e.Towercode)
                    .HasColumnName("towercode")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(e => e.Areacode);

                entity.Property(e => e.Areacode)
                    .HasColumnName("areacode")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Areaname)
                    .HasColumnName("areaname")
                    .HasMaxLength(100);

                entity.Property(e => e.Towercode)
                    .HasColumnName("towercode")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Village>(entity =>
            {
                entity.HasKey(e => e.Areacode);

                entity.Property(e => e.Areacode)
                    .HasColumnName("areacode")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.Areaname)
                    .HasColumnName("areaname")
                    .HasMaxLength(100);

                entity.Property(e => e.Towercode)
                    .HasColumnName("towercode")
                    .HasMaxLength(3);
            });
        }
    }
}
