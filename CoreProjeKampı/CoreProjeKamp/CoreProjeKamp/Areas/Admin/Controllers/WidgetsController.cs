using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
    public class WidgetsController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
