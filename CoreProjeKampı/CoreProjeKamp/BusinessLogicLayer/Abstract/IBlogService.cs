using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetListBlogWithCategory();
        List<Blog> GetListBlogByWriter(int id);
        List<Blog> GetLast3BlogList();
        List<Blog> GetLast5BlogList();
        List<Blog> BlogFilterListWithCategory(int id);
        List<Blog> GetBlogListByCategory(int id);
    }
}
