using DATABASEE.Context;
using DATABASEE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASEE.Repository
{
     public  class Repository<T> : IRepository<T> where T : BaseModels

     {

        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)

        {
            _context = context;

        }

        public async Task<T> Add(T entity)
        {

            _context.Set<T>().Add(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);

            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T?> Get(int id, CancellationToken token)
        {
          return await  _context.Set<T>().FirstOrDefaultAsync(f => f.Id==id ,token);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();

        }

        public Task SaveAsynk(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public async Task<Users?> GetUserByUsernameAndPin(string username, int pin)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Pin == pin);
        }
    }
}
