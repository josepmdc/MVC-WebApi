using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dao.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        List<T> ReadAll();
        T ReadById(int id);
    }
}
