using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{
    public interface IGenericService<T> where T :class
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> TGetList();
        T TGetById(int id);
        List<T> TGetListById(int id);//şartlı listeleme metodumu çağırdığım metoddur
        //ıd'ye göre listeleme yapacağım için id parametresi almam gerekiyor
    }
}
