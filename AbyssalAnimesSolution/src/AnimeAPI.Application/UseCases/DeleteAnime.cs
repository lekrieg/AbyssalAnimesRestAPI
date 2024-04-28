using AnimeAPI.Application.Interfaces;
using AnimeAPI.Infra.Data.Repositories;
using System.Threading.Tasks;

namespace AnimeAPI.Application.UseCases;

public class DeleteAnime : IUseCase<Task, int>
{
    private readonly UnitOfWork _unitOfWork;

    public DeleteAnime(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(int id)
    {
        await _unitOfWork.AnimeRepository.DeleteAsync(id);
    }
}
