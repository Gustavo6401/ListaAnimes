﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Repositories.Base
{
    public interface IRepository <T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(int id);
    }
}
