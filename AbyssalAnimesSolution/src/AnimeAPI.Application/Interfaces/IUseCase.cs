namespace AnimeAPI.Application.Interfaces;

public interface IUseCase<TResult, TRequest>
{
     TResult Execute(TRequest request);
}
