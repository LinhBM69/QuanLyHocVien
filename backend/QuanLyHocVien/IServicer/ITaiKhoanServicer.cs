using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface ITaiKhoanServicer
  {
    PageResult<TaiKhoan> GetAll(Pagination pagination);
    TaiKhoan Get(TaiKhoan taiKhoan);
    TaiKhoan Post(TaiKhoan entity);
    TaiKhoan Put(TaiKhoan entity);
    int Delete(int id);
  }
}
