// ////////////////////////
// File: ApplicationDbContext.cs
// Created at: 11 26, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 26, 2023
// ////////////////////////

using AnimeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Infra.Data.Context;

public class ApplicationDbContext : DbContext
{
	public DbSet<Anime> Anime { get; set; }
	public DbSet<Episode> Episode { get; set; }
	public DbSet<Genre> Genre { get; set; }
	public DbSet<Status> Status { get; set; }
	
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
	}
}