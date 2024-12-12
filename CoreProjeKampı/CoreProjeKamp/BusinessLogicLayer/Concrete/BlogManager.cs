using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogdal;

		public BlogManager(IBlogDal blogdal)
		{
			_blogdal = blogdal;
		}

        public List<Blog> BlogFilterListWithCategory(int id)
        {
			return _blogdal.GetFilterListWithCategory(id);
        }

        public List<Blog> GetBlogListByCategory(int id)
        {
		 return	_blogdal.GetListAll(x => x.CategoryId == id);
        }

        public List<Blog> GetLast3BlogList()
		{
		  return _blogdal.GetListAll().OrderByDescending(x => x.BlogId).Take(3).ToList();
		}

		public List<Blog> GetLast5BlogList()
		{
			return _blogdal.GetListWithCategory(x => x.BlogStatus == true).OrderByDescending(x => x.BlogId).Take(5).ToList();
		}

		public List<Blog> GetListBlogByWriter(int id)
		{
			return _blogdal.GetListAll(x => x.WriterId == id).OrderByDescending(x=>x.WriterId).Take(5).ToList();
		}

		public List<Blog> GetListBlogWithCategory()
		{
			return _blogdal.GetListWithCategory(x=>x.BlogStatus==true);
		}

		public void TAdd(Blog t)
		{
			_blogdal.Insert(t);
		}

		public void TDelete(Blog t)
		{
			_blogdal.Delete(t);
		}

		public Blog TGetById(int id)
		{
			return _blogdal.GetById(id);
		}

		public List<Blog> TGetList()
		{
			return _blogdal.GetListAll(x=>x.BlogStatus==true);
		}

		public List<Blog> TGetListById(int id)
		{
			return _blogdal.GetListAll(x => x.BlogId == id);
		}

		public void TUpdate(Blog t)
		{
		  _blogdal.Update(t);
		}
	}
}
