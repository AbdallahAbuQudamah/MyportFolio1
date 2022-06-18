using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyportFolio1.Models
{
    public partial class MyportfolioDBContext : DbContext
    {
        public MyportfolioDBContext()
        {
        }

        public MyportfolioDBContext(DbContextOptions<MyportfolioDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbaboutme> Tbaboutmes { get; set; }
        public virtual DbSet<Tbcontctme> Tbcontctmes { get; set; }
        public virtual DbSet<Tbmycard> Tbmycards { get; set; }
        public virtual DbSet<Tbmyserf> Tbmyserves { get; set; }
        public virtual DbSet<Tbresme> Tbresmes { get; set; }
        public virtual DbSet<Tbslider> Tbsliders { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Tbaboutme>(entity =>
            {
                entity.ToTable("TBAboutme");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Age).HasMaxLength(10);

                entity.Property(e => e.Contri).HasMaxLength(10);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Img).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(25);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Tbcontctme>(entity =>
            {
                entity.ToTable("TBcontctme");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(10);

                entity.Property(e => e.Subjectuser).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(25);

                entity.Property(e => e.Useremail).HasMaxLength(200);
            });

            modelBuilder.Entity<Tbmycard>(entity =>
            {
                entity.ToTable("TBmycard");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Img).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Tbmyserf>(entity =>
            {
                entity.ToTable("TBmyserves");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Tbresme>(entity =>
            {
                entity.ToTable("TBResme");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Dis).HasMaxLength(200);

                entity.Property(e => e.Exp).HasMaxLength(200);

                entity.Property(e => e.Skills).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Tbslider>(entity =>
            {
                entity.ToTable("TBslider");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Job).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
