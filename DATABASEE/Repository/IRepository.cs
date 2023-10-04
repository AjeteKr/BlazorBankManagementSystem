using DATABASEE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATABASEE.Repository
{
    public interface IRepository<T> where T : BaseModels

    {
        Task<T?> Get(int id, CancellationToken token);

        IQueryable<T> GetAll();
        Task<T> Add(T entity);

        void Update(T entity);

        Task Delete(int id);
        Task SaveAsynk(CancellationToken token);

        Task<Users?> GetUserByUsernameAndPin(string username, int pin);





    }
}
