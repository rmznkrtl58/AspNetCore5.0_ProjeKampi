using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjeKamp.Areas.Admin.VievComponents
{
    public class Statistics4:ViewComponent
    {
        Context ent = new Context();
        public IViewComponentResult Invoke()
        {
            //Aşağısı solide aykırıdır
            ViewBag.v1 = ent.Admins.Where(x => x.AdminId == 1).Select(x => x.Name).FirstOrDefault();
            ViewBag.v2 = ent.Admins.Where(x => x.AdminId == 1).Select(x => x.ImageUrl).FirstOrDefault();
            ViewBag.v3 = ent.Admins.Where(x => x.AdminId == 1).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}
