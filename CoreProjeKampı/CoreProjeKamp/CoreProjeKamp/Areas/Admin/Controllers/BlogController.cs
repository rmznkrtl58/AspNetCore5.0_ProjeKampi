using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Extensions;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using CoreProjeKamp.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreProjeKamp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    { 
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IActionResult Index(int page=1)
        {
            var values = bm.GetListBlogWithCategory().ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddBlog()
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            WriterManager wm = new WriterManager(new EfWriterDal());
            //DropDowna Veri çekme 1 Category
            List<SelectListItem> cl = (from x in cm.TGetList()
                                       select new SelectListItem
                                       {
                                           Text = x.CategoryName,
                                           Value = x.CategoryId.ToString()
                                       }
                                    ).ToList();
            //DropDowna Veri çekme 2 Blog
            List<SelectListItem> wl = (from x in wm.TGetList()
                                       select new SelectListItem
                                       {
                                           Text=x.WriterName,
                                           Value= x.WriterId.ToString()
                                       }
                                    ).ToList();
            ViewBag.c = cl;
            ViewBag.w = wl;
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(Blog b)
        {
            b.BlogDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            b.BlogStatus = true;
            b.BlogImage = "Resim Olmayacak";
            bm.TAdd(b);
            return RedirectToAction("Index", "Blog");
        }
        [HttpGet]
        public IActionResult BlogEdit(int id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            WriterManager wm = new WriterManager(new EfWriterDal());
            List<SelectListItem> cl = (from x in cm.TGetList()
                                       select new SelectListItem
                                       {
                                           Text=x.CategoryName,
                                           Value = x.CategoryId.ToString()
                                       }
                                    ).ToList();
            List<SelectListItem> wl = (from x in wm.TGetList()
                                       select new SelectListItem
                                       {
                                           Text = x.WriterName,
                                           Value = x.WriterId.ToString()
                                       }
                                   ).ToList();
            ViewBag.c = cl;
            ViewBag.w = wl;
            var values=bm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult BlogEdit(Blog b)
        {
            b.BlogDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            b.BlogStatus = true;
            b.BlogImage = "Resim Olmayacak";
            bm.TUpdate(b);
            return RedirectToAction("Index","Blog");
        }
        public IActionResult BlogDelete(int id)
        {
            var findblog = bm.TGetById(id);
            findblog.BlogStatus = false;
            bm.TUpdate(findblog);
            return RedirectToAction("Index", "Blog");
        }
    }
}
