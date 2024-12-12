using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.ViewComponents.Blog
{
	public class FooterLast3Blogs:ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogDal());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetLast3BlogList();
			return View(values);
		}
	}
}
