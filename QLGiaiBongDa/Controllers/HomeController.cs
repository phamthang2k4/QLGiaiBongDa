using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLGiaiBongDa.Models;
using System.Diagnostics;
using X.PagedList;

namespace QLGiaiBongDa.Controllers
{
    public class HomeController : Controller
    {
        QlgiaiBongDaContext db = new QlgiaiBongDaContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = from td in db.Trandaus
                             join clbNha in db.Caulacbos on td.Clbnha equals clbNha.CauLacBoId
                             join clbKhach in db.Caulacbos on td.Clbkhach equals clbKhach.CauLacBoId
                             orderby td.TranDauId ascending
                             select new
                             {
                                 td.TranDauId,
                                 td.KetQua,
                                 ClbNha = clbNha.TenClb,
                                 ClbKhach = clbKhach.TenClb,
                                 td.Anh,
                                 td.NgayThiDau
                             };
            var pagedList = lstSanPham.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }

        public IActionResult SanPhamTheoLoai(String caulacboid, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Trandaus.AsNoTracking().Where(x => (x.Clbnha == caulacboid || x.Clbkhach == caulacboid) ).OrderBy(x => x.TranDauId);
            PagedList<Trandau> lst = new PagedList<Trandau>(lstsanpham, pageNumber, pageSize);
            ViewBag.caulacboid = caulacboid;
            return View(lst);
        }

        public IActionResult TranDauDetail(string trandauid)
        {
            var sanPham = db.Trandaus.SingleOrDefault(x => x.TranDauId == trandauid);
            
            return View(sanPham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
