using BusinessLogicLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjeKamp.ViewComponents.Writer
{
    public class WriterMessageNotifications:ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        public IViewComponentResult Invoke()
        {
            var userinfo = User.Identity.Name;
            //aşağıyı solide aykırı yazcaz
            Context ent = new Context();
            var usermail = ent.Users.Where(x => x.UserName == userinfo).Select(x => x.Email).FirstOrDefault();
            var userid = ent.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            var values = mm.GetListMessagesByWriter(userid);
            return View(values);
        }
    }
}
