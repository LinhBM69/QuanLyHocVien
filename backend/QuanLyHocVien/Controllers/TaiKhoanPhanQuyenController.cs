using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/taikhoanphanquyen")]
  [ApiController]
  public class TaiKhoanPhanQuyenController : ControllerBase
  {
    private readonly ITaiKhoanPhanQuyenServicer iServicer;
    public TaiKhoanPhanQuyenController(ITaiKhoanPhanQuyenServicer iServicer)
    {
      this.iServicer = iServicer;
    }

    [HttpGet ("getall")]
    public IActionResult GetAll(int pageSize, int pageNumber)
    {
      Pagination pagination = new Pagination();
      pagination.PageSize = pageSize;
      pagination.PageNumber = pageNumber;
      var res = iServicer.GetAll(pagination);
      return Ok(res);
    }

    [HttpPost]
    public IActionResult Post(TaiKhoanPhanQuyen taiKhoan)
    {
      iServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(TaiKhoanPhanQuyen taiKhoan)
    {
      iServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
