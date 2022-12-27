using DataAccess.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _objects;

        public GenericRepository()
        {
            _objects = context.Set<T>();
        }

        public void Delete(T entity)
        {
            _objects.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _objects.Where(filter).SingleOrDefault();
        }

        public void Insert(T entity)
        {
            _objects.Add(entity);
            context.SaveChanges();
        }

        public List<T> Listing()
        {
            return _objects.ToList();

            //return filter == null ? _objects.ToList() : _objects.Where(filter).ToList();
        }

        public List<T> ListingBy(Expression<Func<T, bool>> filter)
        {
            return _objects.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            _objects.Update(entity);
            context.SaveChanges();
        }
    }
}
