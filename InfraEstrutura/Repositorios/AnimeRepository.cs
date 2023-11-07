using Dominio.Entities;
using Dominio.Interfaces.Repositories;
using Dominio.Interfaces.Repositories.Base;
using Infraestrutura.Contexto;
using Infraestrutura.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {
        private readonly AnimeContext _context;
        public AnimeRepository(AnimeContext context) : base(context)
        {
            _context = context;
        }
    }
}
