using AnimeAPI.Application.Interfaces;
using AnimeAPI.Infra.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class DeleteEpisode : IUseCase<Task, Tuple<int, int>>
{
    private readonly UnitOfWork _unitOfWork;

    public DeleteEpisode(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(Tuple<int, int> ids)
    {
        var episode = _unitOfWork.EpisodeRepository.GetEpisodeAnime(ids.Item1, ids.Item2).Result;
        await _unitOfWork.EpisodeRepository.Delete(episode);
    }
}
