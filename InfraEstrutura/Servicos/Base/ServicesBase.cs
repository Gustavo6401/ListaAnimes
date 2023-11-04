using AutoMapper;
using Dominio.Interfaces.Repositories.Base;
using Dominio.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Servicos.Base
{
    public class ServicesBase<T, U> : IServiceBase<T, U> where T : class where U : class
    {
        private IRepository<U> _repository;
        private readonly IMapper _mapper;

        public ServicesBase(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task CreateAsync(T entity)
        {
            var model = _mapper.Map<U>(entity);

            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<T>>(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<T>(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            var model = _mapper.Map<U>(entity);

            await _repository.UpdateAsync(model);
        }
    }
}
