using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animal.ResourceAccess
{
    public interface IDapperRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetItem(int id);
        T Create(T item);
        bool Update(T item);
        bool Delete(int id);

    }
}
