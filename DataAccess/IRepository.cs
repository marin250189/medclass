using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(object Id);

        bool Update(T entity);
        bool Delete(T entity);
        bool Add(T entity);
        bool ExecuteQuery(string query);
        DataSet Query(string query);
    }
}
