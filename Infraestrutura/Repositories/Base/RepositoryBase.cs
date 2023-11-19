using Dominio.Interfaces.Repositories.Base;
using Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private AnimeContext Context { get; }
        public RepositoryBase(AnimeContext context)
        {
            Context = context;
        }
        public async Task Create(T entity)
        {
            Context.Set<T>().Add(entity);

            await Context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var anime = await GetById(id);

            Context.Set<T>().Remove(anime);

            await Context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAll() => await Context.Set<T>().ToListAsync();

        public async Task<T> GetById(int id) => await Context.Set<T>().FindAsync(id);

        public async Task Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Detached;

            Context.Set<T>().Update(entity);

            await Context.SaveChangesAsync();
        }
    }
}
