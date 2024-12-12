using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc.Core;
using X.PagedList;
using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using X.PagedList.Extensions;
using EntityLayer.Concrete;
using System;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        public IActionResult Index(int page=1)
        {
            var values = cm.GetListWithBlog().ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public IActionResult editcomment(int id) 
        {                      
            var values=cm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult editcomment(Comment c)
        {
            c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.CommentStatus = true;
            cm.TUpdate(c);
            return RedirectToAction("Index","Comment");
        }
    }
}
