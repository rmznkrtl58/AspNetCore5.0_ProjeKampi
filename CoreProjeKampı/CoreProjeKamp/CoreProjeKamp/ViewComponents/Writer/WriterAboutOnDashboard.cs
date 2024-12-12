using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjeKamp.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        public IViewComponentResult Invoke()
        { 
            var userinfo = User.Identity.Name;
            //Aşağısı solide aykırıdır
            Context ent =new Context();
            var usermail = ent.Users.Where(x => x.UserName == userinfo).Select(x => x.Email).FirstOrDefault();
            var userid = ent.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            var values = wm.TGetListById(userid);
            return View(values);
        }
    }
}
