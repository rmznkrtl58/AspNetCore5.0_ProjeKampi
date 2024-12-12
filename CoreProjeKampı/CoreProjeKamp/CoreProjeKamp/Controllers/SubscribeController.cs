using BusinessLogicLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.Controllers
{
	[AllowAnonymous]
	public class SubscribeController : Controller
	{
		SubscribeMailManager sbm = new SubscribeMailManager(new EfSubscribeMailDal());
		[HttpGet]
		public PartialViewResult SubscribeMailPartial()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult SubscribeMailPartial(SubscribeMail s)
		{
			s.MailStatus = true;
			sbm.TAdd(s);
			return PartialView();
		}
	}
}
