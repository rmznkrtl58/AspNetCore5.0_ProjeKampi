using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.ViewComponents.Category
{
    public class CategoryListDashboard:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public IViewComponentResult Invoke()
        {
            var values = cm.TGetList();
            return View(values);
        }
    }
}
