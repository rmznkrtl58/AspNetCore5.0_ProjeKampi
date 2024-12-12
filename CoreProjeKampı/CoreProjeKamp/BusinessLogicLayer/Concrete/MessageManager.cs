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
    public class MessageManager : IMessageService
    {
        IMessageDal _mesagedal;

        public MessageManager(IMessageDal mesagedal)
        {
            _mesagedal = mesagedal;
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return _mesagedal.GetListAll(x => x.Receiver == p);
        }

        public void TAdd(Message t)
        {
            _mesagedal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _mesagedal.Delete(t);
        }

        public Message TGetById(int id)
        {
            return _mesagedal.GetById(id);
        }

        public List<Message> TGetList()
        {
           return _mesagedal.GetListAll();
        }

        public List<Message> TGetListById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message t)
        {
            _mesagedal.Update(t);
        }
    }
}
