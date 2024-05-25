namespace QuanLyHocVien.Entities
{
  public class MonHoc
  {
    public int MonHocId { get; set; }
    public required string TenMonHoc {  get; set; }
    public IEnumerable<KhoaHocMonHoc>? KhoaHocMonHocs { get; set; }
  }
}
