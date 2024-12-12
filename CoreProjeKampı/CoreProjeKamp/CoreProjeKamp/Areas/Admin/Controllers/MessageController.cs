using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Dal());
        public IActionResult Index()
        {
            return View();
        }
    }
}
