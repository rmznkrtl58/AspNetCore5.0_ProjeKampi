using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        //İNCLUDE METODU blog tabloma ilişkili olan tablolarımın 
        //değerlerime ulaşmam için tanımladığım metotdur.
        //IGenericDal'da tanımlamam saçma olur hepsinde include metoduma
        //ihtiyacım olmayacak gereksiz ram tüketecektir ilk aşamada IBlogDal
        //interface'imde tanımlarım sonra EfBlogDal'da implement ederim
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategory(Expression<Func<Blog, bool>> Filter);
        //belirli bir şarta göre include metodunu kullancağımız bir list metodu
        List<Blog> GetFilterListWithCategory(int id);
    }
}
