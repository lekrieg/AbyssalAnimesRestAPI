// ////////////////////////
// File: Status.cs
// Created at: 11 27, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 27, 2023
// ////////////////////////

using System.Collections.Generic;

namespace AnimeAPI.Domain.Entities;

public class Status : Entity
{
	public string Name { get; set; }

	public ICollection<Anime> Animes { get; set; }
	
	public Status(int id, string name)
	{
		Id = id;
		Name = name;
	}

	public void UpdateInfo(string name)
	{
		Name = name;
	}
}