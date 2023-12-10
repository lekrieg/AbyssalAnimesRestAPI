// ////////////////////////
// File: GenreRepository.cs
// Created at: 12 01, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 12, 01, 2023
// ////////////////////////

using System.Threading.Tasks;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Infra.Data.Repositories;

public class GenreRepository : BaseRepository<Genre>
{
	public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
	
	public async Task<Genre> GetGenreAnime(int? id)
	{
		return (await _dbSet.Include(g => g.Animes).SingleOrDefaultAsync(g => g.Id == id))!;
	}
}