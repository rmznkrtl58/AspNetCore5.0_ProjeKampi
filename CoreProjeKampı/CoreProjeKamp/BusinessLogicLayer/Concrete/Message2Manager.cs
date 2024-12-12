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
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _message2Dal;

        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public List<Message2> GetListMessagesByWriter(int id)
        {
            return _message2Dal.GetListMessageWithSenderUser(id);
        }

        public List<Message2> GetListMessagesReceiverByWriter(int id)
        {
           return _message2Dal.GetListMessageWithReceiverUser(id);
        }

        public void TAdd(Message2 t)
        {
             _message2Dal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            _message2Dal.Delete(t);
        }

        public Message2 TGetById(int id)
        {
            return _message2Dal.GetById(id);
        }

        public List<Message2> TGetList()
        {
           return _message2Dal.GetListAll();
        }

        public List<Message2> TGetListById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            _message2Dal.Update(t);
        }
    }
}
