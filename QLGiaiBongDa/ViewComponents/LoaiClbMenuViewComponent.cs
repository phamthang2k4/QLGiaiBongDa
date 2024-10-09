using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QLGiaiBongDa.Models;
using QLGiaiBongDa.Repository;

namespace QLGiaiBongDa.ViewComponents
{
    public class LoaiClbMenuViewComponent : ViewComponent
    {
        private readonly ILoaiClbRepository _loaiClb;

        public LoaiClbMenuViewComponent(ILoaiClbRepository loaiClb)
        {
            _loaiClb = loaiClb;
        }

        public IViewComponentResult Invoke()
        {
            var loaiclb = _loaiClb.GetAllLoaiClb().OrderBy(x => x.TenClb);
            return View(loaiclb);
        }


    }
}
