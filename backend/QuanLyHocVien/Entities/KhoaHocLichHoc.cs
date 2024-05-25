namespace QuanLyHocVien.Entities
{
  public class KhoaHocLichHoc
  {
    public int KhoaHocId { get; set; }
    public int LichHocId { get; set; }
    public required KhoaHoc KhoaHoc { get; set; }
    public required LichHoc LichHoc { get; set; }
  }
}
