// ////////////////////////
// File: AnimeRepository.cs
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

public class AnimeRepository : BaseRepository<Anime>
{
	public AnimeRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<Anime> GetAnimeEpisodeGenreStatus(int? id)
	{
		return (await _dbSet.Include(a => a.Episodes).Include(a => a.Genres).Include(a => a.Status).SingleOrDefaultAsync(a => a.Id == id))!;
	}
}