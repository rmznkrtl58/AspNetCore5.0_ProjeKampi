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
	public class CommentManager : ICommentService
	{
		ICommentDal _commentdal;

		public CommentManager(ICommentDal commentdal)
		{
			_commentdal = commentdal;
		}

		public void TAdd(Comment t)
		{
			_commentdal.Insert(t);
		}

		public void TDelete(Comment t)
		{
			_commentdal.Delete(t);
		}

		public Comment TGetById(int id)
		{
			return _commentdal.GetById(id);
		}

		public List<Comment> TGetList()
		{
			return _commentdal.GetListAll();
		}

		public List<Comment> TGetListById(int id)
		{
			return _commentdal.GetListAll(x => x.BlogId == id);
		}

		public void TUpdate(Comment t)
		{
			_commentdal.Update(t);
		}

        public List<Comment> GetListWithBlog()
        {
			return _commentdal.GetListCommentWithBlog();
        }

        void IGenericService<Comment>.TAdd(Comment t)
        {
            throw new NotImplementedException();
        }

        void IGenericService<Comment>.TDelete(Comment t)
        {
            throw new NotImplementedException();
        }

        Comment IGenericService<Comment>.TGetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Comment> IGenericService<Comment>.TGetList()
        {
            throw new NotImplementedException();
        }

        List<Comment> IGenericService<Comment>.TGetListById(int id)
        {
            throw new NotImplementedException();
        }

        void IGenericService<Comment>.TUpdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
