// ////////////////////////
// File: GenreConfiguration.cs
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

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
	public void Configure(EntityTypeBuilder<Genre> builder)
	{
		builder.HasKey(x => x.Id);
		builder.Property(x => x.Name).IsRequired();

		builder.HasData(
			new Genre(1, "Action"), new Genre(2, "Adventure"), new Genre(3, "Avant garde"),
			new Genre(4, "Boys love"), new Genre(5, "Comedy"), new Genre(6, "Demons"),
			new Genre(7, "Drama"), new Genre(8, "Ecchi"), new Genre(9, "Fantasy"),
			new Genre(10, "Girls love"), new Genre(11, "Gourmet"), new Genre(12, "Harem"),
			new Genre(13, "Horror"), new Genre(14, "Isekai"), new Genre(15, "Iyashikei"),
			new Genre(16, "Josei"), new Genre(17, "Kids"), new Genre(18, "Magic"),
			new Genre(19, "Mahou shoujo"), new Genre(20, "Martial arts"), new Genre(21, "Mecha"),
			new Genre(22, "Military"), new Genre(23, "Music"), new Genre(24, "Mystery"),
			new Genre(25, "Parody"), new Genre(26, "Psychological"), new Genre(27, "Reverse harem"),
			new Genre(28, "Romance"), new Genre(29, "School"), new Genre(30, "Sci-fi"),
			new Genre(31, "Seinen"), new Genre(32, "Shoujo"), new Genre(33, "Shounen"),
			new Genre(34, "Slice of life"), new Genre(35, "Space"), new Genre(36, "Sports"),
			new Genre(37, "Super power"), new Genre(38, "Supernatural"), new Genre(39, "Suspense"),
			new Genre(40, "Thriller"), new Genre(41, "Vampire"));
	}
}