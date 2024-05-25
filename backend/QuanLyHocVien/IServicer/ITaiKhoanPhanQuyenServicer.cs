using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface ITaiKhoanPhanQuyenServicer
  {
    PageResult<TaiKhoanPhanQuyen> GetAll(Pagination pagination);
    TaiKhoanPhanQuyen Post(TaiKhoanPhanQuyen entity);
    TaiKhoanPhanQuyen Put(TaiKhoanPhanQuyen entity);
    int Delete(int id);
  }
}
