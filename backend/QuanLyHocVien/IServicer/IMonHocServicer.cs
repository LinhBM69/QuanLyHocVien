using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface IMonHocServicer
  {
    PageResult<MonHoc> GetAll(Pagination pagination);
    MonHoc Post(MonHoc entity);
    MonHoc Put(MonHoc entity);
    int Delete(int id);
  }
}
