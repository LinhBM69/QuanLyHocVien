using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/monhoc")]
  [ApiController]
  public class MonHocController : ControllerBase
  {
    private readonly IMonHocServicer iServicer;
    public MonHocController(IMonHocServicer iServicer)
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
    public IActionResult Post(MonHoc taiKhoan)
    {
      iServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(MonHoc taiKhoan)
    {
      iServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
