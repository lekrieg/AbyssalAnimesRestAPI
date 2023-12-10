// ////////////////////////
// File: UnitOfWork.cs
// Created at: 12 01, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 12, 01, 2023
// ////////////////////////

using System;
using System.Threading.Tasks;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Infra.Data.Context;

namespace AnimeAPI.Infra.Data.Repositories;

public class UnitOfWork : IDisposable
{
	private readonly ApplicationDbContext _applicationDbContext;
	private AnimeRepository _animeRepository;
	private EpisodeRepository _episodeRepository;
	private GenreRepository _genreRepository;
	private StatusRepository _statusRepository;

	public AnimeRepository AnimeRepository
	{
		get
		{
			if (_animeRepository == null)
			{
				_animeRepository = new AnimeRepository(_applicationDbContext);
			}

			return _animeRepository;
		}
	}
	
	public EpisodeRepository EpisodeRepository
	{
		get
		{
			if (_episodeRepository == null)
			{
				_episodeRepository = new EpisodeRepository(_applicationDbContext);
			}

			return _episodeRepository;
		}
	}
	
	public GenreRepository GenreRepository
	{
		get
		{
			if (_genreRepository == null)
			{
				_genreRepository = new GenreRepository(_applicationDbContext);
			}

			return _genreRepository;
		}
	}
	
	public StatusRepository StatusRepository
	{
		get
		{
			if (_statusRepository == null)
			{
				_statusRepository = new StatusRepository(_applicationDbContext);
			}

			return _statusRepository;
		}
	}
	
	public UnitOfWork(ApplicationDbContext applicationDbContext)
	{
		_applicationDbContext = applicationDbContext;
	}

	public async Task Save()
	{
		await _applicationDbContext.SaveChangesAsync();
	}

	#region DISPOSE STUFF

	private bool disposed = false;

	private async Task Dispose(bool disposing)
	{
		if (!disposed)
		{
			if (disposing)
			{
				await _applicationDbContext.DisposeAsync();
			}
		}

		disposed = true;
	}

	public async void Dispose()
	{
		await Dispose(true);
		GC.SuppressFinalize(this);
	}

	#endregion
}