using Bayi.Business.Factory;
using Bayi.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bayi.Business.BaseRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected BayiDbContext _dbContext; 
        private IDbFactory _dbFactory; 
        private DbSet<T> _dbSet;
        public Repository(IDbFactory dbFactory)
        {

            _dbFactory = dbFactory;
            _dbContext = this._dbFactory.Init();  
            _dbSet = _dbContext.Set<T>(); 
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        public bool Delete(T entity)
        {
            this.Update(entity);
            return true;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Update(T entity)
        {
            _dbSet.Attach(entity); 
            _dbContext.Entry(entity).State = EntityState.Modified; 
            return entity;
        }
    }
}
