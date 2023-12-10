// ////////////////////////
// File: AnimeConfiguration.cs
// Created at: 11 26, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 26, 2023
// ////////////////////////

using AnimeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeAPI.Infra.Data.EntitiesConfiguration;

public class AnimeConfiguration : IEntityTypeConfiguration<Anime>
{
	public void Configure(EntityTypeBuilder<Anime> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
		builder.Property(x => x.Description).HasMaxLength(400);
		builder.Property(x => x.Image);
		builder.Property(x => x.ReleaseSeason).HasMaxLength(50);
		builder.Property(x => x.ReleaseDate);
		builder.Property(x => x.TotalEpisodesAmount);
		builder.Property(x => x.Studio).HasMaxLength(100);

		builder.HasMany(a => a.Genres).WithMany(g => g.Animes);
		
	}
}