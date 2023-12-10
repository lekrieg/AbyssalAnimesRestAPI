// ////////////////////////
// File: IBaseReçlskt.cs
// Created at: 11 26, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 26, 2023
// ////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnimeAPI.Domain.Interfaces;

public interface IBaseRepository <T>
{
	Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
		Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
		string includeProperties = "");
	
	Task<T> GetByIdAsync(int? id);
	
	Task Insert(T item);
	
	Task UpdateAsync(T item);
	
	Task DeleteAsync(int? id);
	
	Task DeleteAsync(T item);
}