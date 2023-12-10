// ////////////////////////
// File: EpisodeRepository.cs
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

public class EpisodeRepository : BaseRepository<Episode>
{
	public EpisodeRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
	
	public async Task<Episode> GetEpisodeAnime(int? id)
	{
		return (await _dbSet.Include(e => e.Anime).SingleOrDefaultAsync(e => e.Id == id))!;
	}
}