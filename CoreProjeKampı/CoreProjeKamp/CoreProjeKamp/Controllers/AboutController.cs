using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreProjeKamp.Controllers
{
	[AllowAnonymous]
	public class AboutController : Controller
	{
		
		AboutManager abm = new AboutManager(new EfAboutDal());
		
		public IActionResult Index()
		{
			ViewBag.about1 = abm.TGetListById(2).Select(x => x.AboutDetails1).FirstOrDefault();
			ViewBag.about2 = abm.TGetListById(2).Select(x => x.AboutDetails2).FirstOrDefault();
			return View();
		}
		//public PartialViewResult AboutContentPartial()
		//{
		//	ViewBag.about1 = abm.TGetListById(2).Select(x => x.AboutDetails1);
		//	ViewBag.about2 = abm.TGetListById(2).Select(x => x.AboutDetails2);
		//	return PartialView();
		//}
	}
}
