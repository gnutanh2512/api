using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuangDemoAPI.Models;

namespace QuangDemoAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SinhVienController : Controller
    {
        SinhVien sv = new SinhVien();
        [HttpGet]
        public JsonResult DanhSachSinhVien() {
            var rs = sv.sinhViens();
            return new JsonResult(rs);
        }
        [HttpPost]
        public JsonResult ThemMoiSinhVien([FromBody] SinhVien sinhVien)
        {
            var rs = sv.InsertSinhVien(sinhVien);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(0, "Them moi thanh cong"));
            }
            else
            {
                return new JsonResult(new ThongBao(1, "Them moi that bai"));
            }
        }
        [HttpPut]
        public JsonResult SuaSinhVien([FromBody] SinhVien sinhVien)
        {
            var rs = sv.UpdateSinhVien(sinhVien);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(0, "Sua thanh cong"));
            }
            else
            {
                return new JsonResult(new ThongBao(1, "Sua that bai"));
            }
        }
        [HttpDelete("{id}")]
        public JsonResult XoaSinhVien(int id)
        {
            var rs = sv.DeleteSinhVien(id);
            if (rs == 0)
            {
                return new JsonResult(new ThongBao(0, "Xoa thanh cong"));
            }
            else
            {
                return new JsonResult(new ThongBao(1, "Xoa that bai"));
            }
        }
    }
}