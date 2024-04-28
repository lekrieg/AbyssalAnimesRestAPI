// ////////////////////////
// File: DependencyInjection.cs
// Created at: 12 9, 2023
// Description:
// 
// Modified by: danie
// 12, 9, 2023
// ////////////////////////

using System;
using AnimeAPI.Application.DTOs;
using System.Threading.Tasks;
using AnimeAPI.Application.Interfaces;
using AnimeAPI.Application.UseCases;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Interfaces;
using AnimeAPI.Infra.Data.Context;
using AnimeAPI.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using AnimeAPI.Application.Mapping;

namespace AnimeAPI.Infra.Ioc;

public static class DependencyInjection
{
	public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseNpgsql(configuration.GetConnectionString("ConnectionString"),
				b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

		services.AddAutoMapper(typeof(MappingProfile));

		services.AddScoped<IBaseRepository<Anime>, AnimeRepository>();
		services.AddScoped<IBaseRepository<Episode>, EpisodeRepository>();
		services.AddScoped<IBaseRepository<Genre>, GenreRepository>();
		services.AddScoped<IBaseRepository<Status>, StatusRepository>();
        services.AddScoped<IDisposable, UnitOfWork>();

        services.AddScoped<IUseCase<Task, AnimeDTO>, AddAnime>();
		services.AddScoped<IUseCase<Task, List<EpisodeDTO>>, AddEpisode>();
		services.AddScoped<IUseCase<Task, int>, DeleteAnime>();
		services.AddScoped<IUseCase<Task, Tuple<int, int>>, DeleteEpisode>();
		services.AddScoped<IUseCase<Task<List<AnimeDTO>>>, GetAllAnimes>();
		services.AddScoped<IUseCase<Task<List<EpisodeDTO>>, int>, GetAllEpisodes>();
		services.AddScoped<IUseCase<Task<AnimeDTO>, int>, GetAnime>();
		services.AddScoped<IUseCase<Task<EpisodeDTO>, Tuple<int, int>>, GetEpisode>();
		services.AddScoped<IUseCase<Task, AnimeDTO>, UpdateAnime>();
		services.AddScoped<IUseCase<Task, EpisodeDTO>, UpdateEpisode>();

		return services;
	}
}