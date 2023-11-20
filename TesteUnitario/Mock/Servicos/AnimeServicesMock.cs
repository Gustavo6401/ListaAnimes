using AutoMapper;
using Dominio.DTOs;
using Dominio.DTOs.AutoMapper;
using Dominio.Interfaces.Repositories;
using Dominio.Interfaces.Services;

namespace TesteUnitario.Mock.Servicos;

public class AnimeServicesMock : IAnimeServices
{
    private IAnimeRepository Repository { get; }
    private IMapper Mapper { get; }
    public AnimeServicesMock(IAnimeRepository repository) 
    {
        Repository = repository;
        Mapper = MappingProfile.Initialize();
    }
    public async Task Create(AnimeDTO entity)
    {
        var model = Mapper.Map<Anime>(entity);

        await Repository.Create(model);
    }

    public async Task Delete(int id)
    {
        await Repository.Delete(id);
    }

    public async Task<IList<AnimeDTO>> GetAll()
    {
        IList<Anime> entity = await Repository.GetAll();

        return Mapper.Map<IList<AnimeDTO>>(entity);
    }

    public async Task<AnimeDTO> GetById(int id)
    {
        Anime entity = await Repository.GetById(id);

        return Mapper.Map<AnimeDTO>(entity);
    }

    public async Task<AnimeDTO> GetByName(string nome)
    {
        Anime anime = await Repository.GetByName(nome);

        return Mapper.Map<AnimeDTO>(anime);
    }

    public async Task Update(AnimeDTO entity)
    {
        var model = Mapper.Map<Anime>(entity);

        await Repository.Update(model);
    }
}
