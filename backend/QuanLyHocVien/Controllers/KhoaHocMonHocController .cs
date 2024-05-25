using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/khoahocmonhoc")]
  [ApiController]
  public class KhoaHocMonHocController : ControllerBase
  {
    private readonly IKhoaHocMonHocServicer iServicer;
    public KhoaHocMonHocController(IKhoaHocMonHocServicer iServicer)
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
    public IActionResult Post(KhoaHocMonHoc taiKhoan)
    {
      iServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(KhoaHocMonHoc taiKhoan)
    {
      iServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
