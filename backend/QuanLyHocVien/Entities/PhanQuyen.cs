namespace QuanLyHocVien.Entities
{
  public class PhanQuyen
  {
    public int PhanQuyenId { get; set; }
    public required string TenQuyen {  get; set; }
    public IEnumerable<TaiKhoanPhanQuyen>? TaiKhoanPhanQuyen { get; set; }
  }
}
