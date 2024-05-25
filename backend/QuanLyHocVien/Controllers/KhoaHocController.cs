using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/khoahoc")]
  [ApiController]
  public class KhoaHocController : ControllerBase
  {
    private readonly IKhoaHocServicer iServicer;
    public KhoaHocController(IKhoaHocServicer iServicer)
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
    public IActionResult Post(KhoaHoc taiKhoan)
    {
      iServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(KhoaHoc taiKhoan)
    {
      iServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
