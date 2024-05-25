using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface IPhanQuyenServicer
  {
    PageResult<PhanQuyen> GetAll(Pagination pagination);
    PhanQuyen Post(PhanQuyen entity);
    PhanQuyen Put(PhanQuyen entity);
    int Delete(int id);
  }
}
