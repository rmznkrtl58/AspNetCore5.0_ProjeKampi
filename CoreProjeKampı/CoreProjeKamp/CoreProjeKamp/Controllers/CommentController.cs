using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreProjeKamp.Controllers
{
	[AllowAnonymous]
	public class CommentController : Controller
	{   CommentManager cm = new CommentManager(new EfCommentDal());
		
		public IActionResult Index()
		{
			return View();
		}
		//public PartialViewResult CommentListByBlog()
		//{
		//	return PartialView();
		//}
		[HttpGet]
		public PartialViewResult LeaveAComment()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult LeaveAComment(Comment c)
		{
			c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			c.CommentStatus = true;
			c.BlogId = (int)TempData["blogId"];
			//sayfadaki id normalde blog controllerda blogreadalldaydı bende
			//buraya taşıdım
			cm.TAdd(c);
			return PartialView();
		}
	}
}
