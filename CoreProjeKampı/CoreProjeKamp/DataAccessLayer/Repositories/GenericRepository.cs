using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T t)
        {
            using var ent = new Context();
            ent.Remove(t);
            ent.SaveChanges();
        }

        public T GetById(int id)
        {
            using var ent = new Context();
            return ent.Set<T>().Find(id);
                   //ent.set<T>->dbset<entitiydeki tablomuz>
        }

        public List<T> GetListAll()
        {
            using var ent = new Context();
            return ent.Set<T>().ToList();
        }

		public List<T> GetListAll(Expression<Func<T, bool>> filter)
		{
            using var ent = new Context();
            return ent.Set<T>().Where(filter).ToList();
		}

		public void Insert(T t)
        {
            using var ent = new Context();
            ent.Add(t);
            ent.SaveChanges();
        }

        public void Update(T t)
        {
            using var ent = new Context();
            ent.Update(t);
            ent.SaveChanges();
        }
    }
}
