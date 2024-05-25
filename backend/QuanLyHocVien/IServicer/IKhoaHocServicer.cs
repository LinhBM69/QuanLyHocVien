using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface IKhoaHocServicer
  {
    PageResult<KhoaHoc> GetAll(Pagination pagination);
    KhoaHoc Post(KhoaHoc entity);
    KhoaHoc Put(KhoaHoc entity);
    int Delete(int id);
  }
}
