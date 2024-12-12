using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjeKamp.Controllers
{
    public class DashboardController : Controller
    {
       
        public IActionResult Index()
        {
            //Aşağıdaki işlemler solide aykırdır düzeltilecek
            using (var ent=new Context())
            {
                var userinfo = User.Identity.Name;
                var usermail = ent.Users.Where(x => x.UserName == userinfo).Select(x => x.Email).FirstOrDefault();
                var userid = ent.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
                ViewBag.v1 = ent.Blogs.Count().ToString();
                ViewBag.v2 = ent.Blogs.Where(x => x.WriterId == userid).Count();
                ViewBag.v3 = ent.Categories.Count();
            }
            return View();
        }
    }
}
