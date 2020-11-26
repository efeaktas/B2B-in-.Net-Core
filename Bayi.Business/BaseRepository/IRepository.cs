using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.BaseRepository
{
    public interface IRepository<T> where T : class 
    {
        void Add(T entity); 
        T Update(T entity);
        bool Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
