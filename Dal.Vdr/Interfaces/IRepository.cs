using Dal.Vdr.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Vdr.Interfaces
{
    public interface IRepository<T, Tkey>
    where T : class
    {

        T GetOne(Tkey id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        T Delete(Tkey id);
        T Put(T entity);
    }

}
