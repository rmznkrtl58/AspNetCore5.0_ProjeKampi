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
    public class EfMessage2Dal : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetListMessageWithReceiverUser(int id)
        {   //Gönderen biziz
            using (var ent=new Context())
            {
                return ent.Message2s
                    .Include(m => m.ReceiverUser)//Alıcının Bilgilerini dahil et
                    .Where(x => x.SenderId == id)
                    .ToList();
            }
        }

        public List<Message2> GetListMessageWithSenderUser(int id)
        {
            //Alıcı biziz
            using (var ent = new Context())
            {
                return ent.Message2s
                    .Where(x => x.ReceiverId == id)//Gönderenin Bilgilerini dahil et
                    .Include(x => x.SenderUser).ToList();
                    //SenderUser'i Include etme sebebim bana mesaj atacak kişinin
                    //bilgilerine erişim sağlamam için örneğin
                    //senderuser.WriterName gibi
            }
        }
    }
}
