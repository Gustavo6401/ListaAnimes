using AutoMapper;
using Dominio.DTOs;
using Dominio.Entities;
using Dominio.Interfaces.Repositories;
using Dominio.Interfaces.Services;
using Infraestrutura.Servicos.Base;

namespace Infraestrutura.Servicos
{
    public class AnimeService : ServicesBase<AnimeDTO, Anime>, IAnimeService
    {
        private IMapper _mapper;
        private IAnimeRepository _repository;

        public AnimeService(IMapper mapper, IAnimeRepository repository) : base(repository, mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}
