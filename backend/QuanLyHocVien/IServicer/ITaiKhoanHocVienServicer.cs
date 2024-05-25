using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface ITaiKhoanHocVienServicer
  {
    PageResult<TaiKhoanHocVien> GetAll(Pagination pagination);
    TaiKhoanHocVien Post(TaiKhoanHocVien entity);
    TaiKhoanHocVien Put(TaiKhoanHocVien entity);
    int Delete(int id);
  }
}
