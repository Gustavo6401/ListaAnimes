﻿using AutoMapper;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.AutoMapper
{
    internal class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            /*
             * 
             */
            CreateMap<AnimeDTO, Anime>();
            /*CreateMap<Anime, AnimeDTO>()
                .ForMember(x => x.PorcentagemConcluida)*/
        }
    }
}
