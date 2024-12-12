using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Migrations;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    
    public class AdminManager : IAdminService
    {
        IAdminDal _admindal;

        public AdminManager(IAdminDal admindal)
        {
            _admindal = admindal;
        }

        public void TAdd(Admin t)
        {
            _admindal.Insert(t);
        }

        public void TDelete(Admin t)
        {
            _admindal.Delete(t);
        }

        public Admin TGetById(int id)
        {
            return _admindal.GetById(id);
        }

        public List<Admin> TGetList()
        {
           return _admindal.GetListAll();
        }

        public List<Admin> TGetListById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Admin t)
        {
            _admindal.Update(t);
        }
    }
}
