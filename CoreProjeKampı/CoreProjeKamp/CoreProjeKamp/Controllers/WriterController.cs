using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using CoreProjeKamp.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreProjeKamp.Controllers
{

	public class WriterController : Controller
	{
		WriterManager wm = new WriterManager(new EfWriterDal());
        private readonly UserManager<AppUser> _userManager;
        //Registerde UserManager kullanıyom
        //CONSTRUCTOR METOD
        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
		public async Task<IActionResult> Index()
		{
			//Sisteme Authontice olan kullanıcının bilgilerini getirme
			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
			model.phone = values.PhoneNumber;
			model.mail = values.Email;
			model.username = values.UserName;
			model.imageurl= values.ImageUrl;
            return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserUpdateViewModel model)
		{
            //Sisteme Authontice olan kullanıcının bilgilerini Güncelleme İşlemi
			//şifre güncellemede farklı bir yöntem denedik aşağıda görürsün zaten
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
			values.PhoneNumber = model.phone;
			values.UserName=model.username;
			values.ImageUrl= model.imageurl;
			values.Email = model.mail;
			values.NameSurname = model.namesurname;
			values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);
			                                                       //1.p->user 2.p->passwordun geleceği değer
			var result=await _userManager.UpdateAsync(values);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				return View();
			}
		}
		public PartialViewResult WriterSidebarPartial()
		{
			var userinfo=User.Identity.Name;
			//Aşağısı solide aykırıdır
			Context ent=new Context();
			ViewBag.name = ent.Writers.Where(x => x.WriterMail == userinfo).Select(x => x.WriterName).FirstOrDefault();
			return PartialView();
		}
		[HttpGet]
		public IActionResult WriterImageAdd()
		{
			return View();
		}
		[HttpPost]
		public IActionResult WriterImageAdd(WriterImageInsert p)
		{
			//İLK ÖNCE models klasörüne writer tablomda olan propları aldım yeni bir 
			//writerımageinsert adında bir class oluşturup oradaki proplara verileri atayıp
			//sonrada writer tabloma bağlı olan proplarla eşleştirdim.:)
			//RESİM EKLEME İŞLEMİ
			Writer w = new Writer();
			if (p.WriterImage != null)//resim seçiliyse 
			{
				//uzantı
				var extension = Path.GetExtension(p.WriterImage.FileName);
				//parametreme gelen resmin dosya adı uzantı olarak alınacak ve değişkene atanacaktır
				var newimagename = Guid.NewGuid() + extension;//farklı resim adı+uzantı
															  //bir guid oluştur guid=>
															  //resim dosyası adının aynı resim olsa
															  //bile arka tarafta farklı isimlerle kaydedilmesini sağlar.
															  //Yani resim dosyalarımız karışmasın diye bize benzersiz dosya adları
															  //eklememizi sağlar.
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
				var stream = new FileStream(location, FileMode.Create);
				//dosya akışı sırasında location'dan gelen konum bilgisini alıp dosyayı o konuma oluştururu hale getir
				p.WriterImage.CopyTo(stream);//seçilen resmin copyasını streamdeki alınan konuma oluştur
				w.WriterImage = newimagename;
			}
			w.WriterMail = p.WriterMail;
			w.WriterStatus = true;
			w.WriterAbout = p.WriterAbout;
			w.WriterPassword = p.WriterPassword;
			w.WriterName = p.WriterName;
			wm.TAdd(w);
			return RedirectToAction("Index", "Blog");
		}
    }
}
