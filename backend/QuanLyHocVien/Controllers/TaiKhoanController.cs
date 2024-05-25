using Microsoft.AspNetCore.Mvc;
using QuanLyHocVien.Entities;
using QuanLyHocVien.IServicer;

namespace QuanLyHocVien.Controllers
{
  [Route("/api/taikhoan")]
  [ApiController]
  public class TaiKhoanController : ControllerBase
  {
    private readonly ITaiKhoanServicer itaiKhoanServicer;
    public TaiKhoanController(ITaiKhoanServicer itaiKhoanServicer)
    {
      this.itaiKhoanServicer = itaiKhoanServicer;
    }

    [HttpGet ("getall")]
    public IActionResult GetAll(int pageSize, int pageNumber)
    {
      Pagination pagination = new Pagination();
      pagination.PageSize = pageSize;
      pagination.PageNumber = pageNumber;
      var res = itaiKhoanServicer.GetAll(pagination);
      return Ok(res);
    }

    [HttpGet]
    public IActionResult Get([FromQuery]TaiKhoan taiKhoan)
    {
      var res = itaiKhoanServicer.Get(taiKhoan);
      return Ok(res);
    }

    [HttpPost]
    public IActionResult Post(TaiKhoan taiKhoan)
    {
      itaiKhoanServicer.Post(taiKhoan);
      return Ok();
    }

    [HttpPut]
    public IActionResult Put(TaiKhoan taiKhoan)
    {
      itaiKhoanServicer.Put(taiKhoan);
      return Ok();
    }
  }
}
