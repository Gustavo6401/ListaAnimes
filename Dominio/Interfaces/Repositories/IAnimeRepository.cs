using Dominio.Entities;
using Dominio.Interfaces.Repositories.Base;

namespace Dominio.Interfaces.Repositories;

public interface IAnimeRepository : IRepository<Anime>
{
    Task<Anime> GetByName(string nome);
}
