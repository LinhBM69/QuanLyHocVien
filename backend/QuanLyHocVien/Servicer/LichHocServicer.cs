using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class LichHocServicer : ILichHocServicer
  {
    private readonly AppDbContext appDbContext;
    public LichHocServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<LichHoc> ILichHocServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.LichHoc.AsQueryable();

      var obj = PageResult<LichHoc>.PageToResult(pagination, res);
      return new PageResult<LichHoc>(pagination, obj);
    }

    public LichHoc Post(LichHoc entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.LichHoc.Where(e => e.LichHocId == entity.LichHocId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public LichHoc Put(LichHoc entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.LichHoc.Where(e => e.LichHocId == entity.LichHocId).FirstOrDefault();
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
