using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Interface
{
    public interface IRepositoryBase<T> where T: class
    {
         Task<T> GetAsyncById(int id);

         void Add<T>(T entity);

        void Update<T>(T entity);

        void Delete<T>(T entity);

        Task<bool> SaveChangesAsync();
    }
}