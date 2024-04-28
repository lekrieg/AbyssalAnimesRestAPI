using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class UpdateAnime : IUseCase<Task, AnimeDTO>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public UpdateAnime(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(AnimeDTO request)
    {
        var anime = _mapper.Map<Anime>(request);
        if (anime.Image != null && anime.Image.Length > 0)
        {
            anime.UpdateImage(CompressionHelper.Compress(anime.Image));
        }

        await _unitOfWork.AnimeRepository.UpdateAsync(anime);
        await _unitOfWork.Save();
    }
}
