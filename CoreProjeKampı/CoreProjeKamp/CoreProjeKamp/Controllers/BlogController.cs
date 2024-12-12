using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace CoreProjeKamp.Controllers
{
	
	public class BlogController : Controller
	{   
		BlogManager bm = new BlogManager(new EfBlogDal());
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [AllowAnonymous]
        public IActionResult Index()
		{
			var values = bm.GetListBlogWithCategory();
			return View(values);
		}
        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
		{
			TempData["blogId"] = id;
			ViewBag.ID = id;//viewcomponente id'yi taşımak için
			//blogreadall sayfasına viewbag vasıtasıyla id'yi taşıcaz
			var values=bm.TGetListById(id);
			return View(values);
		}
        //authentice olan yazarın bloglarının listesi
        
        public IActionResult BlogListByWriter()
		{
            var userinfo = User.Identity.Name;
            //Solide aykırı yazacaz
            Context ent = new Context();
            var usermail = ent.Users.Where(x => x.UserName == userinfo).Select(x => x.Email).FirstOrDefault();
            int userid = ent.Writers.Where(x => x.WriterMail == usermail).Select(x => x.WriterId).FirstOrDefault();
            var bloglist = bm.BlogFilterListWithCategory(userid);
			return View(bloglist);
		}
		[HttpGet]
		public IActionResult AddBlog()
		{
			//Dropdown liste kategorilerin listelenmesi
			List<SelectListItem> categorylist = (from x in cm.TGetList()
												 select new SelectListItem
												 {
													 Text = x.CategoryName,
													 Value = x.CategoryId.ToString()
												 }
										  ).ToList();
			ViewBag.dc=categorylist;
			return View();
		}
		Context ent=new Context();
        [HttpPost]
        public IActionResult AddBlog(Blog b)
        {   var userinfo=User.Identity.Name;
			var userMail = ent.Users.Where(x => x.UserName == userinfo).Select(x => x.Email).FirstOrDefault();
			var id = ent.Writers.Where(z => z.WriterMail == userMail).Select(x => x.WriterId).FirstOrDefault();
			BlogValidator bv = new BlogValidator();
			//use fluent.validation
			ValidationResult results=bv.Validate(b);
			if (results.IsValid)
			{
				b.WriterId = id;//Authantice olan kullancının id'sini alacaz sonra
                b.BlogStatus = true;
				b.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				var categoryid = cm.GetCategoryValue(b.CategoryId);
				b.CategoryId = Convert.ToInt32(categoryid);
				bm.TAdd(b);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
			else
			{
				foreach(var x in results.Errors)
				{
					ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
				}
			}
			return View();
        }
		[HttpGet]
		public IActionResult EditBlog(int id) 
		{
			List<SelectListItem> Categorylist = (from x in cm.TGetList()
												 select new SelectListItem
												 {
													 Text = x.CategoryName,
													 Value = x.CategoryId.ToString().ToString()
												 }).ToList();
			ViewBag.dc= Categorylist;
			var findblog=bm.TGetById(id);
			return View(findblog);
		}
        [HttpPost]
        public IActionResult EditBlog(Blog b)
        {
            var userinfo = User.Identity.Name;
            var userMail = ent.Users.Where(x => x.UserName == userinfo).Select(x => x.Email).FirstOrDefault();
            var id = ent.Writers.Where(z => z.WriterMail == userMail).Select(x => x.WriterId).FirstOrDefault();
            b.BlogStatus= true;
			b.BlogDate = DateTime.Parse(DateTime.Now.ToShortDateString());
			b.WriterId = id;//Authantice olan kullancının id'sini alacaz sonra
			bm.TUpdate(b);
            return RedirectToAction("BlogListByWriter","Blog");
        }
		public IActionResult DeleteBlog(int id)
		{
            var findblog = bm.TGetById(id);
            findblog.BlogStatus = false;
            bm.TUpdate(findblog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }
    }
}
