using AnimeAPI.Application.DTOs;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.Utils;
using AnimeAPI.Infra.Data.Repositories;
using AutoMapper;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class GetAnime : IUseCase<Task<AnimeDTO>, int>
{
    private readonly IMapper _mapper;
    private readonly UnitOfWork _unitOfWork;

    public GetAnime(IMapper mapper, UnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<AnimeDTO> Execute(int id)
    {
        var a = await _unitOfWork.AnimeRepository.GetByIdAsync(id);
        a.UpdateImage(CompressionHelper.Decompress(a.Image));
        var result = _mapper.Map<AnimeDTO>(a);

        return result;
    }
}