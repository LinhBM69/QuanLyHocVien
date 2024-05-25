using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class KhoaHocServicer : IKhoaHocServicer
  {
    private readonly AppDbContext appDbContext;
    public KhoaHocServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<KhoaHoc> IKhoaHocServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.KhoaHoc.AsQueryable();

      var obj = PageResult<KhoaHoc>.PageToResult(pagination, res);
      return new PageResult<KhoaHoc>(pagination, obj);
    }

    public KhoaHoc Post(KhoaHoc entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.KhoaHoc.Where(e => e.KhoaHocId == entity.KhoaHocId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public KhoaHoc Put(KhoaHoc entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.KhoaHoc.Where(e => e.KhoaHocId == entity.KhoaHocId).FirstOrDefault();
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
