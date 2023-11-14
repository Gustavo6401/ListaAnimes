using AutoMapper;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            /*
             * 
             */
            CreateMap<AnimeDTO, Anime>();
            CreateMap<Anime, AnimeDTO>()
                .ForMember(x => x.PorcentagemConcluida, opt => opt.Ignore());
                    // .AfterMap((src, dest) => dest.PorcentagemConcluida = CalcularPorcentagemConcluida(src));
        }

        // Setei como pública com o único objetivo de fazer o teste unitário.
        /*public decimal CalcularPorcentagemConcluida(Anime src)
        {
            return (decimal)src.EpQueParei * 100 / src.NumeroEpisodios;
        }*/
    }
}
