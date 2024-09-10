using BaiTapKiemTra01.Models;
using Baitapkiemtraso1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baitapkiemtraso1.Controllers
{
	public class DangKyController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult DangKy(TaiKhoanViewModel taikhoan)
		{
			if (taikhoan.Username != null)
			{
				return Content(taikhoan.Username);
			}
			return View(taikhoan);
		}
		public IActionResult BaiTap2()
		{
			var sanpham = new SanPhamViewModel()
			{
				TenSP = "Bánh",
				GiaBan = 1000,
				AnhMoTa = "/images/pics07.jpg"
			};
			return View(sanpham);
		}
	}
}
