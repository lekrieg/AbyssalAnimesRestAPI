// ////////////////////////
// File: EpisodeRepository.cs
// Created at: 12 01, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 12, 01, 2023
// ////////////////////////

using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AnimeAPI.Infra.Data.Repositories;

public class EpisodeRepository : BaseRepository<Episode>
{
    public EpisodeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Episode> GetEpisodeAnime(int? id, int? animeId)
    {
        return (await _dbSet.Include(e => e.Anime).SingleOrDefaultAsync(e => e.AnimeId == animeId && e.Id == id))!;
    }
}