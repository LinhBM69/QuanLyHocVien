using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class PhanQuyenServicer : IPhanQuyenServicer
  {
    private readonly AppDbContext appDbContext;
    public PhanQuyenServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<PhanQuyen> IPhanQuyenServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.PhanQuyen.AsQueryable();

      var obj = PageResult<PhanQuyen>.PageToResult(pagination, res);
      return new PageResult<PhanQuyen>(pagination, obj);
    }

    public PhanQuyen Post(PhanQuyen entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.PhanQuyen.Where(e => e.PhanQuyenId == entity.PhanQuyenId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public PhanQuyen Put(PhanQuyen entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.PhanQuyen.Where(e => e.PhanQuyenId == entity.PhanQuyenId).FirstOrDefault();
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
