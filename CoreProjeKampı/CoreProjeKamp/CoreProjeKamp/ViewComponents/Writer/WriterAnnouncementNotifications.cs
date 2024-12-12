using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.ViewComponents.Writer
{
    public class WriterAnnouncementNotifications:ViewComponent
    {
        NotificationManager nm = new NotificationManager(new EfNotificationDal());
        public IViewComponentResult Invoke()
        {
            var values = nm.TGetList();
            return View(values);
        }
    }
}
