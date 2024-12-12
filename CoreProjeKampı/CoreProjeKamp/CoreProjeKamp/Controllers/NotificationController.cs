using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        public IActionResult Index()
        {
            var values = nm.TGetList();
            return View(values);
        }
    }
}
