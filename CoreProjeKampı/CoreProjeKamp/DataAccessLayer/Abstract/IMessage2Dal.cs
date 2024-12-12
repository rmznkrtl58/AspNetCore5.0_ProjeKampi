using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal:IGenericDal<Message2>
    {
        public List<Message2> GetListMessageWithSenderUser(int id);
        public List<Message2> GetListMessageWithReceiverUser(int id);
    }
}
