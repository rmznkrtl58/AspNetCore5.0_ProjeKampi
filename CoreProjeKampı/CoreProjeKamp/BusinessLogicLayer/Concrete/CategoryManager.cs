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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _Icategorydal;

        public CategoryManager(ICategoryDal ıcategorydal)
        {
            _Icategorydal = ıcategorydal;
        }

        public Category GetCategoryValue(int id)
        {
           return _Icategorydal.GetCategoryValue(id);
        }

        public void TAdd(Category t)
        {
            _Icategorydal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _Icategorydal.Delete(t);
        }

        public Category TGetById(int id)
        {
            return _Icategorydal.GetById(id);
        }

        public List<Category> TGetList()
        {
            return _Icategorydal.GetListAll(x=>x.CategoryStatus==true);
        }

		public List<Category> TGetListById(int id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Category t)
        {
            _Icategorydal.Update(t);
        }
    }
}
