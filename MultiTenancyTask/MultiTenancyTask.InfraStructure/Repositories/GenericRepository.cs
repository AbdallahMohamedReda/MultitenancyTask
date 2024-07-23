using Microsoft.EntityFrameworkCore;
using MultiTenancyTask.Domain.Repositories;
using MultiTenancyTask.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancyTask.InfraStructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly Context context;

        public GenericRepository(Context _context)
        {
            context = _context;
        }

        public async  Task add(T entity)
        {
            await context.AddAsync(entity);
           

        }

        public async Task<List<T>> find(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
