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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerdal;

		public WriterManager(IWriterDal writerdal)
		{
			_writerdal = writerdal;
		}

		public void TAdd(Writer t)
		{
			_writerdal.Insert(t);
		}

		public void TDelete(Writer t)
		{
			_writerdal.Delete(t);
		}

		public Writer TGetById(int id)
		{
			return _writerdal.GetById(id);
		}

		public List<Writer> TGetList()
		{
			return _writerdal.GetListAll();
		}

		public List<Writer> TGetListById(int id)
		{
			return _writerdal.GetListAll(x => x.WriterId == id);
		}

		public void TUpdate(Writer t)
		{
			_writerdal.Update(t);
		}
	}
}
