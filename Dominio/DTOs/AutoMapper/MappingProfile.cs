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
        /*public MappingProfile() 
        {
            CreateMap<AnimeDTO, Anime>();
            CreateMap<Anime, AnimeDTO>()
                .ForMember(x => x.PorcentagemConcluida, opt => opt.Ignore());
                    // .AfterMap((src, dest) => dest.PorcentagemConcluida = CalcularPorcentagemConcluida(src));
        }*/

        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AnimeDTO, Anime>();
                cfg.CreateMap<Anime, AnimeDTO>()
                    .ForMember(dest => dest.PorcentagemConcluida, opt => opt.Ignore());
                // Adicione outras configurações de mapeamento, se necessário
            });

            return config.CreateMapper();
        }
    }
}
