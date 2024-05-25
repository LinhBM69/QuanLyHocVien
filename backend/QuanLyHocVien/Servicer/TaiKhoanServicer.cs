using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Servicer
{
  public class TaiKhoanServicer : ITaiKhoanServicer
  {
    private readonly AppDbContext appDbContext;
    public TaiKhoanServicer(AppDbContext appDbContext) { 
      this.appDbContext = appDbContext;
    }

    PageResult<TaiKhoan> ITaiKhoanServicer.GetAll(Pagination pagination)
    {
      var res = appDbContext.TaiKhoan.AsQueryable();

      var obj = PageResult<TaiKhoan>.PageToResult(pagination, res);
      return new PageResult<TaiKhoan>(pagination, obj);
    }

    public TaiKhoan Get(TaiKhoan taiKhoan)
    {
      var res = appDbContext.TaiKhoan.Where(e => e.Email == taiKhoan.Email && e.MatKhau == taiKhoan.MatKhau).FirstOrDefault();

      if(res != null)
      {
        return res;
      }
      else
      {
        return taiKhoan;
      }
    }

    public TaiKhoan Post(TaiKhoan entity)
    {
      appDbContext.Add(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoan.OrderByDescending(e => e.TaiKhoanId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return new TaiKhoan { Email = entity.Email, HoVaTen = entity.HoVaTen, MatKhau = entity.MatKhau, SoDienThoai = entity.SoDienThoai };
      }
    }

    public TaiKhoan Put(TaiKhoan entity)
    {
      appDbContext.Update(entity);
      appDbContext.SaveChanges();
      var res = appDbContext.TaiKhoan.Where(e => e.TaiKhoanId == entity.TaiKhoanId).FirstOrDefault();
      if (res != null)
      {
        return res;
      }
      else
      {
        return new TaiKhoan { Email = entity.Email, HoVaTen = entity.HoVaTen, MatKhau = entity.MatKhau, SoDienThoai = entity.SoDienThoai };
      }
    }

    public int Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
