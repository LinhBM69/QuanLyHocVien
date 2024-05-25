namespace QuanLyHocVien.Entities
{
  public class TaiKhoanPhanQuyen
  {
    public int TaiKhoanId { get; set; }
    public int PhanQuyenId { get; set; }
    public required PhanQuyen PhanQuyen { get; set; }
    public required TaiKhoan TaiKhoan { get; set; }
  }
}
