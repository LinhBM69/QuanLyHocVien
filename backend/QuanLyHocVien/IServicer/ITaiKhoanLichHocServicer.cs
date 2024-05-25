using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface ITaiKhoanLichHocServicer
  {
    PageResult<TaiKhoanLichHoc> GetAll(Pagination pagination);
    TaiKhoanLichHoc Post(TaiKhoanLichHoc entity);
    TaiKhoanLichHoc Put(TaiKhoanLichHoc entity);
    int Delete(int id);
  }
}
