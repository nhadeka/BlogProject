using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Database
{
    public class RepoBase<T> : IRepoBase<T> where T : class, new()
    {
        protected DbContext _context;
        protected IDbSet<T> _dbset;

        public RepoBase(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbset.Find(id);
            _dbset.Remove(entity);
        }

       

        public IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetObject(Expression<Func<T, bool>> lamda)
        {
            return _dbset.FirstOrDefault(lamda);
        }

        public void Update(T entity)
        {
           var entry = _context.Entry(entity);

            //error error!!!abort the mission
            //entry.State = EntityState.Modified;


            //change of plans! plan b=>
            _context.Set<T>().AddOrUpdate(entity);
           

        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> lamda)
        {
            return _dbset.Where(lamda).AsEnumerable<T>();
        }

        public IQueryable<T> WhereQueryable(Expression<Func<T, bool>> lamda)
        {
            return _dbset.Where(lamda).AsQueryable<T>();
        }
    }
}
