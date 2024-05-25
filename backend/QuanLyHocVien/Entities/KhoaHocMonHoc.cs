namespace QuanLyHocVien.Entities
{
  public class KhoaHocMonHoc
  {
    public int KhoaHocId { get; set; }
    public int MonHocId { get; set; }
    public required KhoaHoc KhoaHoc { get; set; }
    public required MonHoc MonHoc { get; set; }
  }
}
