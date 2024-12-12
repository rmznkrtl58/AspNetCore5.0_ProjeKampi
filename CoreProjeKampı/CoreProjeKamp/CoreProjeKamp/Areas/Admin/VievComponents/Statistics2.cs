using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using System.Linq;

namespace CoreProjeKamp.Areas.Admin.VievComponents
{
    public class Statistics2:ViewComponent
    {
        Context ent = new Context();
        public IViewComponentResult Invoke()
        {
            //aşağıdaki kullanım solide aykırıdır
            ViewBag.v1 = ent.Blogs.OrderByDescending(x => x.BlogId).Select(z => z.BlogTitle).FirstOrDefault().ToString();
            return View();
        }
    }
}
