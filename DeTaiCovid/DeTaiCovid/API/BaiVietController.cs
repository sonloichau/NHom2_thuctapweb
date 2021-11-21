using DeTaiCovid.Controllers;
using DeTaiCovid.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeTaiCovid.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private BaiVietService BaiVietService = new BaiVietService();
        [HttpGet]
        public IActionResult LayDSBaiViet()
        {
            var lstBaiViet = BaiVietService.LayDSBaiViet();
            if (lstBaiViet.Count > 0)
            {

                return Ok(lstBaiViet);
            }
            else
            {
                //bắt mã lỗi
                return BadRequest("Danh Sách trống!");
            }
        }
        [HttpPost]
        public IActionResult ThemBaiViet(BaiViet newBaiViet)
        {
            bool check = BaiVietService.ThemBaiViet(newBaiViet);
            if (check == true)
            {
                return Ok($"Thêm Bài viết{newBaiViet.BaiVietId} thành công");
            }
            else
            {
                return BadRequest($"Thêm bài viết {newBaiViet.BaiVietId} Thất bại");

            }
        }
    }
}
