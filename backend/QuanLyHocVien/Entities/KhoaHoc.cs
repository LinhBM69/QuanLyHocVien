namespace QuanLyHocVien.Entities
{
  public class KhoaHoc
  {
    public int KhoaHocId { get; set; }
    public required string TenKhoaHoc {  get; set; }
    public IEnumerable<KhoaHocMonHoc>? KhoaHocMonHoc { get; set; }
    public IEnumerable<KhoaHocLichHoc>? KhoaHocLichHoc { get; set; }
  }
}
