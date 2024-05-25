using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface IKhoaHocLichHocServicer
  {
    PageResult<KhoaHocLichHoc> GetAll(Pagination pagination);
    KhoaHocLichHoc Post(KhoaHocLichHoc entity);
    KhoaHocLichHoc Put(KhoaHocLichHoc entity);
    int Delete(int id);
  }
}
