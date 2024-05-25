using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/taikhoanlichhoc")]
  [ApiController]
  public class TaiKhoanLichHocController : ControllerBase
  {
    private readonly ITaiKhoanLichHocServicer iServicer;
    public TaiKhoanLichHocController(ITaiKhoanLichHocServicer iServicer)
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
    public IActionResult Post(TaiKhoanLichHoc taiKhoan)
    {
      iServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(TaiKhoanLichHoc taiKhoan)
    {
      iServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
