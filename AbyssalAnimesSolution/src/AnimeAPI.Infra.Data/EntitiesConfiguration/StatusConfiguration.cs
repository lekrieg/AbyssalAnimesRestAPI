// ////////////////////////
// File: StatusConfiguration.cs
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

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
	public void Configure(EntityTypeBuilder<Status> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).IsRequired();

		builder.HasMany(s => s.Animes).WithOne(a => a.Status);

		builder.HasData(
			new Status(1, "On hold"), new Status(2, "Canceled"),
			new Status(3, "Releasing"), new Status(4, "Not yet aired"));
	}
}