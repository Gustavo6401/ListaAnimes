using Dominio.DTOs;
using Dominio.Entities;
using Dominio.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Services
{
    public interface IAnimeService : IServiceBase<AnimeDTO, Anime>
    {
    }
}
