using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class GetAllAnimes : IUseCase<Task<List<AnimeDTO>>>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public GetAllAnimes(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<List<AnimeDTO>> Execute()
    {
        var animes = await _unitOfWork.AnimeRepository.GetAsync();
        foreach (var a in animes)
        {
            a.UpdateImage(CompressionHelper.Decompress(a.Image));
        }

        var result = _mapper.Map<List<AnimeDTO>>(animes);

        return result;
    }
}
