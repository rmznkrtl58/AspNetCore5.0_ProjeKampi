using BusinessLogicLayer.Concrete;
using BusinessLogicLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using X.PagedList;
using X.PagedList.Extensions;


namespace CoreProjeKamp.Areas.Admin.Controllers
{
    [Area("Admin")]//şuan conroller üzerindeki ıactionresultlar olsun
    //partialler olsun Admin areası içerisinde gerçekleşeceğini programıma bildirdim
    //startuptaki app.useendpoints kısmı nedir=>uygulama sunucu üzerinde ayağa kaldırıldığı
    //an ilk çalışacak kısımdır
    //Area oluştuğunda scoffolding readmesindeki app.useendpoints içerisindeki metodu al startupdaki
    //app.userendpoints içerisine yapıştır
  
    public class CategoryController : Controller
    {
        
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IActionResult Index(int page=1)
        {
            //LİSTELEME PAKETLERİ X.PAGED LİST AND X.PAGEDLİST.MVC.CORE(8.1.0 sürümü)
            var values = cm.TGetList().ToPagedList(page,5);
            //1.p=>hangi sayfadan başlasın
            //2.p=>sayfa başına kaç tane listelesin                                                
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            CategoryValidator cv=new CategoryValidator();
            ValidationResult result = cv.Validate(c);
            if (result.IsValid)
            {
                c.CategoryStatus = true;
                cm.TAdd(c);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach(var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult CategoryDelete(int id)
        {
            var findid=cm.TGetById(id);
            findid.CategoryStatus = false;
            cm.TUpdate(findid);
            return RedirectToAction("Index","Category");
        }
        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var values =cm.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult CategoryEdit(Category c)
        {
            c.CategoryStatus = true;
            cm.TUpdate(c);
            return RedirectToAction("Index", "Category");
        }
    }
}
