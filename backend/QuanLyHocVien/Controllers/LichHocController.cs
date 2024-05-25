using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/lichhoc")]
  [ApiController]
  public class LichHocController : ControllerBase
  {
    private readonly ILichHocServicer iServicer;
    public LichHocController(ILichHocServicer iServicer)
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
    public IActionResult Post(LichHoc taiKhoan)
    {
      iServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(LichHoc taiKhoan)
    {
      iServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
