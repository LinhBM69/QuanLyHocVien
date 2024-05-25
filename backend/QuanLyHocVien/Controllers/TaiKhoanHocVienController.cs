using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/taikhoanhocvien")]
  [ApiController]
  public class TaiKhoanHocVienController : ControllerBase
  {
    private readonly ITaiKhoanHocVienServicer iServicer;
    public TaiKhoanHocVienController(ITaiKhoanHocVienServicer iServicer)
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
    public IActionResult Post(TaiKhoanHocVien taiKhoan)
    {
      iServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(TaiKhoanHocVien taiKhoan)
    {
      iServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
