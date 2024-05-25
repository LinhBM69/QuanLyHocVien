using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class KhoaHocLichHocServicer : IKhoaHocLichHocServicer
  {
    private readonly AppDbContext appDbContext;
    public KhoaHocLichHocServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<KhoaHocLichHoc> IKhoaHocLichHocServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.KhoaHocLichHoc.AsQueryable();

      var obj = PageResult<KhoaHocLichHoc>.PageToResult(pagination, res);
      return new PageResult<KhoaHocLichHoc>(pagination, obj);
    }

    public KhoaHocLichHoc Post(KhoaHocLichHoc entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.KhoaHocLichHoc.Where(e => e.KhoaHocId == entity.KhoaHocId && e.LichHocId == entity.LichHocId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public KhoaHocLichHoc Put(KhoaHocLichHoc entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.KhoaHocLichHoc.Where(e => e.KhoaHocId == entity.KhoaHocId && e.LichHocId == entity.LichHocId).FirstOrDefault();
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
