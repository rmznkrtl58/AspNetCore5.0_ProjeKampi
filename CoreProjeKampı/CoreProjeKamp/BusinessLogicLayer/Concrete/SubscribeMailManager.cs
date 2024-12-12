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
	public class SubscribeMailManager : ISubscribeMailService
	{
		ISubscribeMailDal _subscribemail;

		public SubscribeMailManager(ISubscribeMailDal subscribemail)
		{
			_subscribemail = subscribemail;
		}

		public void TAdd(SubscribeMail t)
		{
			_subscribemail.Insert(t);
		}

		public void TDelete(SubscribeMail t)
		{
			_subscribemail.Delete(t);
		}

		public SubscribeMail TGetById(int id)
		{
			return _subscribemail.GetById(id);
		}

		public List<SubscribeMail> TGetList()
		{
			return _subscribemail.GetListAll();
		}

		public List<SubscribeMail> TGetListById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(SubscribeMail t)
		{
			_subscribemail.Update(t);
		}
	}
}
