using Blog.Core.Database;
using Blog.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private bool _disposed = false;
     
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }
        public bool Commit()
        {
            
            bool isCommited = false;

            
            using (_context.Database.BeginTransaction())
            {
                try
                {
                    isCommited = _context.SaveChanges() > 0 ? true : false;
                    
                    _context.Database.CurrentTransaction.Commit();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                   
                    _context.Database.CurrentTransaction.Rollback();

                }
            }

            return isCommited;
        }

        public void Dispose(bool disposing)
        {
            if (_disposed == false)
            {
                if (disposing)
                {
                    Dispose();
                    _disposed = true;
                    _context = null;
                }
            }
           
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IRepoBase<T> GetRepo<T>() where T : class, new()
        {
            return new RepoBase<T>(_context);
        }
    }
}
