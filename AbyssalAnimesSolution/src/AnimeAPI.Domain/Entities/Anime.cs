// ////////////////////////
// File: Anime.cs
// Created at: 11 24, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 24, 2023
// ////////////////////////

using System;
using System.Collections.Generic;

namespace AnimeAPI.Domain.Entities;

public sealed class Anime : Entity
{
	public string Name { get; private set; }
	public string Description { get; private set; }
	public byte[] Image { get; private set; }
	public string ReleaseSeason { get; private set; }
	public DateTime? ReleaseDate { get; private set; }
	public string Status { get; private set; }
	public List<string> Genres { get; private set; }
	public int TotalEpisodesAmount { get; private set; }
	public string Studio { get; private set; }
	
	public ICollection<Episode> Episodes { get; set; }

	public Anime(string name, string description, byte[] image,
		string releaseSeason, DateTime? releaseDate, string status, List<string> genres,
		int totalEpisodesAmount, string studio)
	{
		Name = name;
		Description = description;
		Image = image;
		ReleaseSeason = releaseSeason;
		ReleaseDate = releaseDate;
		Status = status;
		Genres = genres;
		TotalEpisodesAmount = totalEpisodesAmount;
		Studio = studio;
	}

	public void UpdateInfo(string name, string description, byte[] image,
		string releaseSeason, DateTime? releaseDate, string status, List<string> genres,
		int totalEpisodesAmount, string studio)
	{
		Name = name;
		Description = description;
		Image = image;
		ReleaseSeason = releaseSeason;
		ReleaseDate = releaseDate;
		Status = status;
		Genres = genres;
		TotalEpisodesAmount = totalEpisodesAmount;
		Studio = studio;
	}
}