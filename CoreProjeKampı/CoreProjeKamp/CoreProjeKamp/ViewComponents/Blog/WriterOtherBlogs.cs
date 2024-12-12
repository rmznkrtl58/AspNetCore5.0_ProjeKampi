using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreProjeKamp.ViewComponents.Blog
{
	public class WriterOtherBlogs:ViewComponent
	{
		BlogManager bm = new BlogManager(new EfBlogDal());
		public IViewComponentResult Invoke()
		{
			var values = bm.GetListBlogByWriter(1);
			return View(values);
		}
	}
}
