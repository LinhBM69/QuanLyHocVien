using QuanLyHocVien.Entities;

namespace QuanLyHocVien.IServicer
{
  public interface ILichHocServicer
  {
    PageResult<LichHoc> GetAll(Pagination pagination);
    LichHoc Post(LichHoc entity);
    LichHoc Put(LichHoc entity);
    int Delete(int id);
  }
}
