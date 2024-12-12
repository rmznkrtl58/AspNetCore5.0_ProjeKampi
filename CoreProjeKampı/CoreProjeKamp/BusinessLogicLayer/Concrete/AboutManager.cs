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
	public class AboutManager : IAboutService
	{
		IAboutDal _aboutdal;

		public AboutManager(IAboutDal aboutdal)
		{
			_aboutdal = aboutdal;
		}

		public void TAdd(About t)
		{
			_aboutdal.Insert(t);
		}

		public void TDelete(About t)
		{
			_aboutdal.Delete(t);
		}

		public About TGetById(int id)
		{
			return _aboutdal.GetById(id);
		}

		public List<About> TGetList()
		{
			return _aboutdal.GetListAll();
		}

		public List<About> TGetListById(int id)
		{
			return _aboutdal.GetListAll(x => x.AboutId == id);
		}

		public void TUpdate(About t)
		{
			_aboutdal.Update(t);
		}
	}
}
