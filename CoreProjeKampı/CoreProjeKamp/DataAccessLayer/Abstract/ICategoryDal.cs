using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        //YANLIŞ KULLANIM 
        //List<Category> GetListCategory();
        //void AddCategory(Category c);
        //void DeleteCategory(Category c);
        //void UpdateCategory(Category c);
        //Category FindCategory(int id);
        public Category GetCategoryValue(int id);
    }
}
