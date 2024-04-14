// ////////////////////////
// File: Episode.cs
// Created at: 11 24, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 24, 2023
// ////////////////////////

using AnimeAPI.Domain.ExtensionMethods;

namespace AnimeAPI.Domain.Entities;

public sealed class Episode : Entity
{
	public string Name { get; private set; }
	public string FileType { get; private set; }
	public byte[] EpisodeData { get; private set; }

	public int AnimeId { get; set; }
	public Anime Anime { get; set; }

	public Episode(string name, string fileType, byte[] episodeData)
	{
		Name = name;
		FileType = fileType;
		EpisodeData = episodeData;
	}

	public void UpdateInfo(string name, string fileType, byte[] episodeData)
	{
		if(!name.IsNullOrEmptyOrWhiteSpace() && !Name.Equals(name))
		{
            Name = name;
        }

        if(!fileType.IsNullOrEmptyOrWhiteSpace() && !FileType.Equals(fileType))
        {
            FileType = fileType;
        }

		EpisodeData = episodeData;
	}
}