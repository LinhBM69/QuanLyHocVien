namespace QuanLyHocVien.Entities
{
  public class TaiKhoan
  {
    public int TaiKhoanId { get; set;}
    public required string Email { get; set;}
    public required string HoVaTen { get; set;}
    public required string MatKhau { get; set;}
    public string? SoDienThoai { get; set;}
    public IEnumerable<TaiKhoanPhanQuyen>? TaiKhoanPhanQuyen { get; set;}
    public IEnumerable<TaiKhoanHocVien>? TaiKhoanHocVien { get; set;}
    public IEnumerable<TaiKhoanLichHoc>? TaiKhoanLichHoc { get; set;}
  }
}
