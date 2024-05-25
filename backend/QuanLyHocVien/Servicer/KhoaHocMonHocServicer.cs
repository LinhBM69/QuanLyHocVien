using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class KhoaHocMonHocServicer : IKhoaHocMonHocServicer
  {
    private readonly AppDbContext appDbContext;
    public KhoaHocMonHocServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<KhoaHocMonHoc> IKhoaHocMonHocServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.KhoaHocMonHoc.AsQueryable();

      var obj = PageResult<KhoaHocMonHoc>.PageToResult(pagination, res);
      return new PageResult<KhoaHocMonHoc>(pagination, obj);
    }

    public KhoaHocMonHoc Post(KhoaHocMonHoc entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.KhoaHocMonHoc.Where(e => e.KhoaHocId == entity.KhoaHocId && e.MonHocId == entity.MonHocId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public KhoaHocMonHoc Put(KhoaHocMonHoc entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.KhoaHocMonHoc.Where(e => e.KhoaHocId == entity.KhoaHocId && e.MonHocId == entity.MonHocId).FirstOrDefault();
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
