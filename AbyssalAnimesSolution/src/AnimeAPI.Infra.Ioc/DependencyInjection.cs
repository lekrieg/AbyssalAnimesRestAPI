// ////////////////////////
// File: DependencyInjection.cs
// Created at: 12 9, 2023
// Description:
// 
// Modified by: danie
// 12, 9, 2023
// ////////////////////////

using System;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Interfaces;
using AnimeAPI.Infra.Data.Context;
using AnimeAPI.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AnimeAPI.Infra.Ioc;

public static class DependencyInjection
{
	public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseNpgsql(configuration.GetConnectionString("ConnectionString"),
				b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

		services.AddScoped<IBaseRepository<Anime>, AnimeRepository>();
		services.AddScoped<IBaseRepository<Episode>, EpisodeRepository>();
		services.AddScoped<IBaseRepository<Genre>, GenreRepository>();
		services.AddScoped<IBaseRepository<Status>, StatusRepository>();
		services.AddScoped<IDisposable, UnitOfWork>();

		return services;
	}
}