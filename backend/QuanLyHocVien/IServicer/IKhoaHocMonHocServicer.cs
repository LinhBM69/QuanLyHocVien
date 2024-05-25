using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface IKhoaHocMonHocServicer
  {
    PageResult<KhoaHocMonHoc> GetAll(Pagination pagination);
    KhoaHocMonHoc Post(KhoaHocMonHoc entity);
    KhoaHocMonHoc Put(KhoaHocMonHoc entity);
    int Delete(int id);
  }
}
