using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class TaiKhoanLichHocServicer : ITaiKhoanLichHocServicer
  {
    private readonly AppDbContext appDbContext;
    public TaiKhoanLichHocServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<TaiKhoanLichHoc> ITaiKhoanLichHocServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.TaiKhoanLichHoc.AsQueryable();

      var obj = PageResult<TaiKhoanLichHoc>.PageToResult(pagination, res);
      return new PageResult<TaiKhoanLichHoc>(pagination, obj);
    }

    public TaiKhoanLichHoc Post(TaiKhoanLichHoc entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoanLichHoc.Where(e => e.TaiKhoanId == entity.TaiKhoanId && e.LichHocId == entity.LichHocId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public TaiKhoanLichHoc Put(TaiKhoanLichHoc entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoanLichHoc.Where(e => e.TaiKhoanId == entity.TaiKhoanId && e.LichHocId == entity.LichHocId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public int Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
