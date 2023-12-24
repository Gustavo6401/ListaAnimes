﻿using AutoMapper;
using Dominio.DTOs;
using Dominio.DTOs.AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces.Repositories;
using Dominio.Interfaces.Services;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class AnimeServices : ServicesBase<AnimeDTO, Anime>, IAnimeServices
    {
        private IMapper Mapper { get; }
        private IAnimeRepository Repository { get; }

        public AnimeServices(IMapper mapper, IAnimeRepository repository) : base(repository, mapper)
        {
            Mapper = mapper;
            Repository = repository;
        }

        public async Task<List<AnimeDTO>> GetByName(string nome)
        {
            List<Anime>? anime = await Repository.GetByName(nome);

            return Mapper.Map<List<AnimeDTO>>(anime);
        }
    }
}
