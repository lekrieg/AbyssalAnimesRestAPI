using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class AddEpisode : IUseCase<Task, List<EpisodeDTO>>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public AddEpisode(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(List<EpisodeDTO> request)
    {
        var episodes = _mapper.Map<List<Episode>>(request);
        foreach (var episode in episodes)
        {
            episode.UpdateEpisodeData(CompressionHelper.Compress(episode.EpisodeData));

            await _unitOfWork.EpisodeRepository.Insert(episode);
        }

        await _unitOfWork.Save();
    }
}
