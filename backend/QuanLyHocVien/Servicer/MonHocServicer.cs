using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class MonHocServicer : IMonHocServicer
  {
    private readonly AppDbContext appDbContext;
    public MonHocServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<MonHoc> IMonHocServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.MonHoc.AsQueryable();

      var obj = PageResult<MonHoc>.PageToResult(pagination, res);
      return new PageResult<MonHoc>(pagination, obj);
    }

    public MonHoc Post(MonHoc entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.MonHoc.Where(e => e.MonHocId == entity.MonHocId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public MonHoc Put(MonHoc entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.MonHoc.Where(e => e.MonHocId == entity.MonHocId).FirstOrDefault();
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
