using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> Listing();
        List<T> ListningBy(Expression<Func<T, bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
    }
}
