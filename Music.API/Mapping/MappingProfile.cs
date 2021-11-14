using AutoMapper;
using MusicWeb.API.DTOs;
using MusicWeb.API.DTOs.Auth;
using MusicWeb.Core.Models;
using MusicWeb.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artist, ArtistAddEditDTO>().ReverseMap();
            CreateMap<Artist, ArtistResultDTO>().ReverseMap();
            CreateMap<Artist, ArtistWithMusicResultDTO>().ReverseMap();

            CreateMap<Artist, ArtistIdDTO>().ReverseMap();
            

            CreateMap<Music, MusicAddEditDTO>()
                  .ForMember(dest =>
                    dest.ArtistIds,
                    opt => opt.MapFrom(src => src.Artists))
                .ReverseMap();
            CreateMap<Music, MusicResultDTO>()
                .ForMember(dest=>dest.Producer,
                opt=>opt.MapFrom(src=>src.Producer))
                .ReverseMap();
            CreateMap<Music, MusicArtistDTO>().ReverseMap();

            CreateMap<Producer, ProducerAddDTO>().ReverseMap();
            CreateMap<Producer, ProducerDTO>().ReverseMap();
            CreateMap<Producer, ProducerAddEditDTO>().ReverseMap();
            CreateMap<Producer, ProducerResultDTO>().ReverseMap();


            CreateMap<UserSignUpDTO, User>()
                    .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email))
                    .ReverseMap();


        }
    }
}
