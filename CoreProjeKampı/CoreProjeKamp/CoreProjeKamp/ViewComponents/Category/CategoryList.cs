using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Extensions;
using System.Linq;

namespace CoreProjeKamp.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {
            var values = cm.TGetList().Take(5);
            return View(values);
        }
    }
}
