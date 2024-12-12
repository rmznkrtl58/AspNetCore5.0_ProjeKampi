using BusinessLogicLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace CoreProjeKamp.ViewComponents.Comment
{
	public class CommentListByBlog:ViewComponent
	{
		CommentManager cm = new CommentManager(new EfCommentDal());
		public IViewComponentResult Invoke(int id)
		{
			var values = cm.TGetListById(id);
			return View(values);
		}
	}
}
