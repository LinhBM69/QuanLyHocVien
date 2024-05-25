namespace QuanLyHocVien.Entities
{
  public class LichHoc
  {
    public int LichHocId { get; set; }
    public DateTime ThoiGianBatDau {  get; set; }
    public DateTime ThoiGianKetThuc {  get; set; }
    public IEnumerable<KhoaHocLichHoc>? KhoaHocLichHoc {  get; set; }
    public IEnumerable<TaiKhoanLichHoc>? TaiKhoanLichHoc { get; set; }
  }
}
