using AutoMapper;
using Dominio.DTOs.AutoMapper;
using Dominio.Interfaces.Repositories.Base;
using Dominio.Interfaces.Services.Base;

namespace Servicos.Base;

public class ServicesBase<T, U> : IServicesBase<T, U> where T : class where U : class
{
    private IRepository<U> Repository { get; }
    private IMapper Mapper { get; }

    public ServicesBase(IRepository<U> repository, IMapper mapper)
    {
        // Deixarei desse jeito por enquanto, não estou afim de reescrever a PORRA do código inteiro.
        Repository = repository;
        mapper = MappingProfile.Initialize();

        Mapper = mapper;
    }

    public async Task Create(T entity)
    {
        var model = Mapper.Map<U>(entity);

        await Repository.Create(model);
    }

    public async Task Delete(int id)
    {
        await Repository.Delete(id);
    }

    public async Task<IList<T>> GetAll()
    {
        IList<U> entity = await Repository.GetAll();

        return Mapper.Map<IList<T>>(entity);
    }

    public async Task<T> GetById(int id)
    {
        U entity = await Repository.GetById(id);

        return Mapper.Map<T>(entity);
    }

    public async Task Update(T entity)
    {
        var model = Mapper.Map<U>(entity);

        await Repository.Update(model);
    }
}
