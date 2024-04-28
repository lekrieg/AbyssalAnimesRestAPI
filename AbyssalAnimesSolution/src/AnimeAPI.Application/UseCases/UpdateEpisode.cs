using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class UpdateEpisode : IUseCase<Task, EpisodeDTO>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public UpdateEpisode(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(EpisodeDTO request)
    {
        var episode = _mapper.Map<Episode>(request);
        if (episode.EpisodeData != null && episode.EpisodeData.Length > 0)
        {
            episode.UpdateEpisodeData(CompressionHelper.Compress(episode.EpisodeData));
        }

        await _unitOfWork.EpisodeRepository.UpdateAsync(episode);
        await _unitOfWork.Save();
    }
}
