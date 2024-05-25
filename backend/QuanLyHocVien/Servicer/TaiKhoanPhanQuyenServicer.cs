using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class TaiKhoanPhanQuyenServicer : ITaiKhoanPhanQuyenServicer
  {
    private readonly AppDbContext appDbContext;
    public TaiKhoanPhanQuyenServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<TaiKhoanPhanQuyen> ITaiKhoanPhanQuyenServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.TaiKhoanPhanQuyen.AsQueryable();

      var obj = PageResult<TaiKhoanPhanQuyen>.PageToResult(pagination, res);
      return new PageResult<TaiKhoanPhanQuyen>(pagination, obj);
    }

    public TaiKhoanPhanQuyen Post(TaiKhoanPhanQuyen entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoanPhanQuyen.OrderByDescending(e => e.TaiKhoanId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public TaiKhoanPhanQuyen Put(TaiKhoanPhanQuyen entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoanPhanQuyen.Where(e => e.TaiKhoanId == entity.TaiKhoanId && e.PhanQuyenId == entity.PhanQuyenId).FirstOrDefault();
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
