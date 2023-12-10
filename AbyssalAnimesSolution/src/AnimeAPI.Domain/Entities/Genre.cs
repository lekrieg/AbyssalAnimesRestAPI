// ////////////////////////
// File: Genre.cs
// Created at: 11 27, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 27, 2023
// ////////////////////////

using System.Collections.Generic;

namespace AnimeAPI.Domain.Entities;

public class Genre : Entity
{
	public string Name { get; private set; }

	public ICollection<Anime> Animes { get; set; }
	
	public Genre(int id, string name)
	{
		Id = id;
		Name = name;
	}

	public void UpdateInfo(string name)
	{
		Name = name;
	}
}