using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Services.Base
{
    public interface IServicesBase<T, U> where T : class where U : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task Create(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
