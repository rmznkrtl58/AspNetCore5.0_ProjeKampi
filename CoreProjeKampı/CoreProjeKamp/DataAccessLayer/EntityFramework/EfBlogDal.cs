using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfBlogDal : GenericRepository<Blog>, IBlogDal
	{   //IBlogDaldaki tanımlanan metodun içeriğini işlevini burda 
        public List<Blog> GetFilterListWithCategory(int id)
        {
			using (var ent=new Context())
			{
				return ent.Blogs.Where(x => x.WriterId == id&&x.BlogStatus==true).Include(x => x.Category).ToList();
			}
        }

        //yazıyorum sonra Business tarafında IBlogService tarafına
        //aşağıdaki metodu çağırmam için metod tanımlamam gerekli!!!
        public List<Blog> GetListWithCategory()
		{
			using (var ent =new Context())
			{
				return ent.Blogs.Include(x=>x.Category).ToList();
			}
		}

        public List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> Filter)
        {
            using (var ent = new Context())
            {
                return ent.Blogs.Include(x => x.Category).Where(Filter).ToList();
            }
        }
    }
}
