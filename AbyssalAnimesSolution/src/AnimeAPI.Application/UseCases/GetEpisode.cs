using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class GetEpisode : IUseCase<Task<EpisodeDTO>, Tuple<int, int>>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public GetEpisode(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<EpisodeDTO> Execute(Tuple<int, int> ids)
    {
        var e = await _unitOfWork.EpisodeRepository.GetEpisodeAnime(ids.Item1, ids.Item2);
        e.UpdateInfo(string.Empty, string.Empty, CompressionHelper.Decompress(e.EpisodeData));
        var result = _mapper.Map<EpisodeDTO>(e);

        return result;
    }
}
