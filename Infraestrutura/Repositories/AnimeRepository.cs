﻿using Dominio.Entities;
using Dominio.Interfaces.Repositories;
using Infraestrutura.Context;
using Infraestrutura.Repositories.Base;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositories
{
    public class AnimeRepository : RepositoryBase<Anime>, IAnimeRepository
    {
        private AnimeContext Context { get; }
        public AnimeRepository(AnimeContext context) : base(context)
        {
            Context = context;
        }

        public async Task<List<Anime>> GetByName(string nome) => await Context.Animes.Where(a => a.Nome.Contains(nome)).ToListAsync();
    }
}
