using Dominio.Entities;
using Dominio.Interfaces.Repositories.Base;

namespace Dominio.Interfaces.Repositories;

public interface IAnimeRepository : IRepository<Anime>
{
    Task<List<Anime>> GetByName(string nome);
}
