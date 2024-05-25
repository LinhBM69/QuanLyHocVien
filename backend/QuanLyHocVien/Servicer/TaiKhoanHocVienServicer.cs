using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class TaiKhoanHocVienServicer : ITaiKhoanHocVienServicer
  {
    private readonly AppDbContext appDbContext;
    public TaiKhoanHocVienServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<TaiKhoanHocVien> ITaiKhoanHocVienServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.TaiKhoanHocVien.AsQueryable();

      var obj = PageResult<TaiKhoanHocVien>.PageToResult(pagination, res);
      return new PageResult<TaiKhoanHocVien>(pagination, obj);
    }

    public TaiKhoanHocVien Post(TaiKhoanHocVien entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoanHocVien.Where(e => e.TaiKhoanHocVienId == entity.TaiKhoanHocVienId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return entity;
      }
    }

    public TaiKhoanHocVien Put(TaiKhoanHocVien entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoanHocVien.Where(e => e.TaiKhoanHocVienId == entity.TaiKhoanHocVienId).FirstOrDefault();
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
