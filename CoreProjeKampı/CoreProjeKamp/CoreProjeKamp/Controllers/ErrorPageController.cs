using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.Controllers
{
	[AllowAnonymous]
	public class ErrorPageController : Controller
	{
	
		public IActionResult Error404(int code)//startupta oluşturduğum parametre ile aynı oldu
		{
			return View();
		}
		public IActionResult AccessDenied()
		{
			return View();
		}

    }
}
