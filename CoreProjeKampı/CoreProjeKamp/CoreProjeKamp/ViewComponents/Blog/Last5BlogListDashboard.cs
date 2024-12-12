using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.ViewComponents.Blog
{
    public class Last5BlogListDashboard:ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogDal());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetLast5BlogList();
            return View(values);
        }
    }
}
