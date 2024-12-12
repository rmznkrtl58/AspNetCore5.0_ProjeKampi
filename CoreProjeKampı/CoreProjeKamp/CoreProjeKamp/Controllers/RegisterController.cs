using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterDal());

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Writer w)
		{
            WriterValidator wv = new WriterValidator();
            //using FluentValidation.Results;
            ValidationResult results =wv.Validate(w);
			//wv->nesnemdeki proplarımın doğruluğunun kontrolü
			if (results.IsValid)//doğrulama başarılıysa
			{
                w.WriterStatus = true;
                w.WriterAbout = "Açıklama";
                wm.TAdd(w);
                return RedirectToAction("Index", "Blog");
            }
			else
			{
				foreach(var x in results.Errors)
				{
					ModelState.AddModelError(x.PropertyName,x.ErrorMessage);
				}
			}
			return View();
          
		}
	}
}
