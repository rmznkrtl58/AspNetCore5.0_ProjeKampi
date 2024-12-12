using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreProjeKamp.Controllers
{
	[AllowAnonymous]
	public class ContactController : Controller
	{    
		ContactManger cm = new ContactManger(new EfContactDal());
		
		[HttpGet]
		public IActionResult Index()
		{

			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact c)
		{
			c.ContactStatus = true;
			c.ContactDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			cm.TAdd(c);
			return RedirectToAction("Index","Blog");
		}
	}
}
