using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminWriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterDal());
		public IActionResult Index()
		{
			var values = wm.TGetList();
			return View(values);
		}
	}
}
