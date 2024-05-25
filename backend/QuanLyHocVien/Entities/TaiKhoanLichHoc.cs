namespace QuanLyHocVien.Entities
{
  public class TaiKhoanLichHoc
  {
    public int TaiKhoanId { get;set; }
    public int LichHocId { get; set; }
    public required TaiKhoan TaiKhoan { get; set; }
    public required LichHoc LichHoc { get; set; }
  }
}
