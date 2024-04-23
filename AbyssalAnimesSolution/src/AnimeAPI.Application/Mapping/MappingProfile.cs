using AnimeAPI.Application.DTOs;
using AnimeAPI.Domain.Entities;
using AutoMapper;

namespace AnimeAPI.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Episode, EpisodeDTO>().ReverseMap();
        CreateMap<Anime, AnimeDTO>().ReverseMap();
    }
}
