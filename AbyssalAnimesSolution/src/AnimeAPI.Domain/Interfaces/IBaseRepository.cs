// ////////////////////////
// File: IBaseReçlskt.cs
// Created at: 11 26, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 26, 2023
// ////////////////////////

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeAPI.Domain.Interfaces;

public interface IBaseRepository <T>
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<T> GetByIdAsync(int? id);
	Task<T> CreateAsync(T item);
	Task<T> UpdateAsync(T item);
	Task<T> DeleteAsync(T item);
}