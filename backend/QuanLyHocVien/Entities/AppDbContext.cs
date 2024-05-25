using Microsoft.EntityFrameworkCore;

namespace QuanLyHocVien.Entities
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TaiKhoan> TaiKhoan { get; set; }
    public DbSet<PhanQuyen> PhanQuyen { get; set;}
    public DbSet<TaiKhoanPhanQuyen> TaiKhoanPhanQuyen { get; set; }
    public DbSet<TaiKhoanHocVien> TaiKhoanHocVien { get; set; }
    public DbSet<KhoaHoc> KhoaHoc { get; set; }
    public DbSet<MonHoc> MonHoc { get; set; }
    public DbSet<KhoaHocMonHoc> KhoaHocMonHoc { get; set; }
    public DbSet<LichHoc> LichHoc { get; set; }
    public DbSet<KhoaHocLichHoc> KhoaHocLichHoc { get; set; }
    public DbSet<TaiKhoanLichHoc> TaiKhoanLichHoc { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<TaiKhoan>(e =>
      {
        e.ToTable(nameof(TaiKhoan));
        e.HasKey(f => f.TaiKhoanId);
      });

      modelBuilder.Entity<PhanQuyen>(e =>
      {
        e.ToTable(nameof (PhanQuyen));
        e.HasKey(f => f.PhanQuyenId);
      });

      modelBuilder.Entity<TaiKhoanPhanQuyen>(e =>
      {
        e.ToTable(nameof(TaiKhoanPhanQuyen));
        e.HasKey(f => new {f.TaiKhoanId, f.PhanQuyenId});
        e.HasOne(f => f.TaiKhoan).WithMany(f => f.TaiKhoanPhanQuyen).HasForeignKey(f => f.TaiKhoanId);
        e.HasOne(f => f.PhanQuyen).WithMany(f => f.TaiKhoanPhanQuyen).HasForeignKey(f => f.PhanQuyenId);
      });

      modelBuilder.Entity<TaiKhoanHocVien>(e =>
      {
        e.ToTable(nameof(TaiKhoanHocVien));
        e.HasKey(f => f.TaiKhoanHocVienId);
      });

      modelBuilder.Entity<KhoaHoc>(e =>
      {
        e.ToTable(nameof(KhoaHoc));
        e.HasKey(f => f.KhoaHocId);
      });

      modelBuilder.Entity<MonHoc>(e =>
      {
        e.ToTable(nameof(MonHoc));
        e.HasKey(f => f.MonHocId);
      });

      modelBuilder.Entity<KhoaHocMonHoc>(e =>
      {
        e.ToTable(nameof(KhoaHocMonHoc));
        e.HasKey(f => new {f.MonHocId, f.KhoaHocId});
        e.HasOne(f => f.KhoaHoc).WithMany(f => f.KhoaHocMonHoc).HasForeignKey(f => f.KhoaHocId);
        e.HasOne(f => f.MonHoc).WithMany(f => f.KhoaHocMonHocs).HasForeignKey(f => f.MonHocId);
      });

      modelBuilder.Entity<LichHoc>(e =>
      {
        e.ToTable(nameof(LichHoc));
        e.HasKey(f => f.LichHocId);
      });

      modelBuilder.Entity<KhoaHocLichHoc>(e =>
      {
        e.ToTable(nameof(KhoaHocLichHoc));
        e.HasKey(f => new {f.KhoaHocId, f.LichHocId});
        e.HasOne(f => f.KhoaHoc).WithMany(f => f.KhoaHocLichHoc).HasForeignKey(f => f.KhoaHocId);
        e.HasOne(f => f.LichHoc).WithMany(f => f.KhoaHocLichHoc).HasForeignKey(f => f.LichHocId);
      });

      modelBuilder.Entity<TaiKhoanLichHoc>(e =>
      {
        e.ToTable(nameof(TaiKhoanLichHoc));
        e.HasKey(f => new {f.TaiKhoanId, f.LichHocId});
        e.HasOne(f => f.TaiKhoan).WithMany(f => f.TaiKhoanLichHoc).HasForeignKey(f => f.TaiKhoanId);
        e.HasOne(f => f.LichHoc).WithMany(f => f.TaiKhoanLichHoc).HasForeignKey(f => f.LichHocId);
      });
    }
  }
}
