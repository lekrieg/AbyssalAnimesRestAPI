using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class AddAnime : IUseCase<Task, AnimeDTO>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public AddAnime(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(AnimeDTO request)
    {
        var anime = _mapper.Map<Anime>(request);
        anime.UpdateImage(CompressionHelper.Compress(anime.Image));
        await _unitOfWork.AnimeRepository.Insert(anime);

        await _unitOfWork.Save();
    }
}
