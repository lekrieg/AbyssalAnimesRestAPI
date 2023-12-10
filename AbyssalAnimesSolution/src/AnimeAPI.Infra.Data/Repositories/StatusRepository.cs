// ////////////////////////
// File: StatusRepository.cs
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

public class StatusRepository : BaseRepository<Status>
{
	public StatusRepository(ApplicationDbContext dbContext) : base(dbContext)
	{
	}
	
	public async Task<Status> GetStatusAnime(int? id)
	{
		return (await _dbSet.Include(s => s.Animes).SingleOrDefaultAsync(s => s.Id == id))!;
	}
}