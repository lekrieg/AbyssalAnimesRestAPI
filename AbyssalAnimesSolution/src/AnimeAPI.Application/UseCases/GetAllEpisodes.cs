using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class GetAllEpisodes : IUseCase<Task<List<EpisodeDTO>>, int>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public GetAllEpisodes(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<EpisodeDTO>> Execute(int id)
    {
        var episodes = await _unitOfWork.EpisodeRepository.GetAsync(a => a.AnimeId == id);
        foreach (var e in episodes)
        {
            e.UpdateInfo(string.Empty, string.Empty, CompressionHelper.Decompress(e.EpisodeData));
        }

        var result = _mapper.Map<List<EpisodeDTO>>(episodes);

        return result;
    }
}
