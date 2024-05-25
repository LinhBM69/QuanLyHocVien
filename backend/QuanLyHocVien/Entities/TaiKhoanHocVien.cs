namespace QuanLyHocVien.Entities
{
  public class TaiKhoanHocVien
  {
    public int TaiKhoanHocVienId { get; set; }
    public int TaiKhoanId { get; set; }
    public int TaiKhoanNameId { get; set;}
    public required TaiKhoan TaiKhoan { get; set;}
  }
}
