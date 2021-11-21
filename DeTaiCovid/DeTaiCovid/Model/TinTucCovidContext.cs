using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DeTaiCovid.Model
{
    public partial class TinTucCovidContext : DbContext
    {
        public TinTucCovidContext()
        {
        }

        public TinTucCovidContext(DbContextOptions<TinTucCovidContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<ChuDe> ChuDes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TinTucCovid;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BaiViet>(entity =>
            {
                entity.ToTable("BaiViet");

                entity.Property(e => e.Anh)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MoTa).HasMaxLength(200);

                entity.Property(e => e.NgayTao).HasColumnType("date");

                entity.Property(e => e.NoiDung).HasMaxLength(4000);

                entity.Property(e => e.TieuDe).HasMaxLength(50);

                entity.HasOne(d => d.ChuDe)
                    .WithMany(p => p.BaiViets)
                    .HasForeignKey(d => d.ChuDeid)
                    .HasConstraintName("FK_BaiViet_ChuDe");
            });

            modelBuilder.Entity<ChuDe>(entity =>
            {
                entity.ToTable("ChuDe");

                entity.Property(e => e.SoLuongBaiViet).HasMaxLength(50);

                entity.Property(e => e.TenChuDe).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
