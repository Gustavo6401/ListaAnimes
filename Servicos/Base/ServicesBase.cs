using AutoMapper;
using Dominio.Interfaces.Repositories.Base;
using Dominio.Interfaces.Services.Base;

namespace Servicos.Base;

public class ServicesBase<T, U> : IServicesBase<T, U> where T : class where U : class
{
    private IRepository<U> Repository { get; }
    private IMapper Mapper { get; }

    public ServicesBase(IRepository<U> repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public async Task Create(T entity)
    {
        var model = Mapper.Map<U>(entity);

        await Repository.Create(model);
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(T entity)
    {
        throw new NotImplementedException();
    }
}
