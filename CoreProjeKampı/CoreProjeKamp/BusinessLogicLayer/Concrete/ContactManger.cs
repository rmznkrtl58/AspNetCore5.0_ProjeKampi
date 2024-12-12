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
	public class ContactManger : IContactService
	{
		IContactDal _contactdal;

		public ContactManger(IContactDal contactdal)
		{
			_contactdal = contactdal;
		}

		public void TAdd(Contact t)
		{
			_contactdal.Insert(t);
		}

		public void TDelete(Contact t)
		{
			_contactdal.Delete(t);
		}

		public Contact TGetById(int id)
		{
			return _contactdal.GetById(id);
		}

		public List<Contact> TGetList()
		{
			return _contactdal.GetListAll();
		}

		public List<Contact> TGetListById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Contact t)
		{
			_contactdal.Update(t);
		}
	}
}
