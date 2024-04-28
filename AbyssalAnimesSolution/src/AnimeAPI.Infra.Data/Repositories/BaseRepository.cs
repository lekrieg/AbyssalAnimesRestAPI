// ////////////////////////
// File: BaseRepository.cs
// Created at: 11 29, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 29, 2023
// ////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AnimeAPI.Domain.Entities;
using AnimeAPI.Domain.Interfaces;
using AnimeAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeAPI.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Entity
{
	protected readonly ApplicationDbContext _dbContext;
	protected readonly DbSet<T> _dbSet;

	public BaseRepository(ApplicationDbContext dbContext)
	{
		_dbContext = dbContext;
		_dbSet = dbContext.Set<T>();
	}

	public async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
		Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
		string includeProperties = "")
	{
		IQueryable<T> query = _dbSet;

		if (filter != null)
		{
			query = query.Where(filter);
		}

		foreach (var p in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
		{
			query = query.Include(includeProperties);
		}

		if (orderBy != null)
		{
			return await orderBy(query).ToListAsync();
		}

		return await query.ToListAsync();
	}

	public async Task<T> GetByIdAsync(int? id)
	{
		return await _dbSet.FindAsync(id);
	}

	public Task Insert(T item)
	{
		_dbSet.Add(item);
		return Task.CompletedTask;
	}

	public Task UpdateAsync(T item)
	{
		_dbSet.Update(item);
		return Task.CompletedTask;
	}

	public async Task DeleteAsync(int? id)
	{
		T e = await _dbSet.FindAsync(id);
		await Delete(e);
	}

	public Task Delete(T item)
	{
		_dbSet.Remove(item);
		return Task.CompletedTask;
	}
}