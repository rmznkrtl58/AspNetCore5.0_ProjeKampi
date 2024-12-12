using CoreProjeKamp.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreProjeKamp.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager= signInManager;	
        }
        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserLoginViewModel u)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(u.UserName, u.Password, false, true);
				//3.p->çerezler hatırlansınmı?
				//4.p->5 defa yanlış girildiğinde
				//belli bir süre banlansı nmı?

				if (result.Succeeded) 
				{
					return RedirectToAction("Index", "Category", new {Area="Admin"});
				}
				else
				{
					return View();
				}
            }
            return View();
        }
		public async Task<IActionResult> WriterLogout()
		{
		   await _signInManager.SignOutAsync();
		   return RedirectToAction("Index", "Login");
		}
    }
}





//Authentication="kimlik doğrulaması"
//Authorization = "kimlik yetkikendirme"
//Claim = ""kullanıcı hakkında bilgiler tutan yapılar diyebiliriz."
//Kısaca Claim anlatmamız gerekirse Örneğin:Youtobe'a giriş yaptık ve
//Youtobe bize izleyici rolü tanımladı,bu tanımlama ile beraber istediğmiz
//video'yu izleyebiliyoruz.Ama diyelim ki yaşımız 18'den küçük ve bazı korku
//gerilim videoları +18 sınır konulması gerekiyor,İşte burada yaş aralığını ölçebilmek
//için ilgili kullanıcıların yaş değerlerinin claim olarak atanması sağlanmalı ve
//claim bazlı bir yetkilendirme yapılmalıdır.





//----------------identitysiz login işlemi------------------
//1.YOLLLLL
//var userinfo = ent.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
// if (userinfo != null)//userinfo değişkenimin içi doluysa aşağıyı yap
//{
//	HttpContext.Session.SetString("username", userinfo.WriterMail);
//	return RedirectToAction("Index", "Blog");
//}
//else
//{
//	return View();
//}



//2.yol//aşağısı solide aykırı sonra refactoring yapılacak
//Context ent = new Context();
////2.YOLLLL
//var userinfo = ent.Writers.FirstOrDefault(x => x.WriterMail == w.WriterMail && x.WriterPassword == w.WriterPassword);
//if (userinfo != null)
//{       //talepler
//    var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Name,w.WriterMail)
//                };
//    //kullanıcı kimliği doğrulama adında değişken
//    var useridentity = new ClaimsIdentity(claims, "a");
//    //Talep prensipleri
//    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
//    await HttpContext.SignInAsync(principal);
//    return RedirectToAction("Index", "Category", new { area = "Admin" });
//}
//else
//{
//    return View();
//}