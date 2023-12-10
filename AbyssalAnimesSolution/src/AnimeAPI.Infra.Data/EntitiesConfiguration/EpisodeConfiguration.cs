// ////////////////////////
// File: EpisodeConfiguration.cs
// Created at: 11 27, 2023
// Description:
// 
// Modified by: Daniel Henrique
// 11, 27, 2023
// ////////////////////////

using AnimeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeAPI.Infra.Data.EntitiesConfiguration;

public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
{
	public void Configure(EntityTypeBuilder<Episode> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
		builder.Property(x => x.FileType).HasMaxLength(3).IsRequired();
		builder.Property(x => x.EpisodeData);

		builder.HasOne(e => e.Anime).WithMany(a => a.Episodes);
	}
}