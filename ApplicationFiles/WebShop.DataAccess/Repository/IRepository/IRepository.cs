using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //Example: T - Category
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
