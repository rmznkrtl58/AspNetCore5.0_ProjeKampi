using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        List<Comment> ICommentDal.GetListCommentWithBlog()
        {
            using (var ent = new Context())
            {
                return ent.Comments.Include(x => x.Blog).ToList();
            }
        }
    }
}
