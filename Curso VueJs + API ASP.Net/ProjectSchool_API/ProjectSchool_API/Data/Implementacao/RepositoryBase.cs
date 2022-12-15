using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Data.Interface;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data.Implementacao
{
    public class RepositoryBase<T> : IRepositoryBase<T>  where T : class
    {
        protected readonly DataContext Context;
        
        public RepositoryBase(DataContext context)
        {
            Context = context;
        }

        //GERAL
        public void Add<T>(T entity)
        {
            Context.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            Context.Remove(entity);
        }

        public void Update<T>(T entity) 
        {
            Context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await Context.SaveChangesAsync() > 0);
        }
    }
}