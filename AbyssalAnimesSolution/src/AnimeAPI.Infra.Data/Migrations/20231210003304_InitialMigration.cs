using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimeAPI.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: false),
                    ReleaseSeason = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TotalEpisodesAmount = table.Column<int>(type: "integer", nullable: false),
                    Studio = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anime_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeGenre",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGenre", x => new { x.AnimesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_AnimeGenre_Anime_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Episode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FileType = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    EpisodeData = table.Column<byte[]>(type: "bytea", nullable: false),
                    AnimeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Episode_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Avant garde" },
                    { 4, "Boys love" },
                    { 5, "Comedy" },
                    { 6, "Demons" },
                    { 7, "Drama" },
                    { 8, "Ecchi" },
                    { 9, "Fantasy" },
                    { 10, "Girls love" },
                    { 11, "Gourmet" },
                    { 12, "Harem" },
                    { 13, "Horror" },
                    { 14, "Isekai" },
                    { 15, "Iyashikei" },
                    { 16, "Josei" },
                    { 17, "Kids" },
                    { 18, "Magic" },
                    { 19, "Mahou shoujo" },
                    { 20, "Martial arts" },
                    { 21, "Mecha" },
                    { 22, "Military" },
                    { 23, "Music" },
                    { 24, "Mystery" },
                    { 25, "Parody" },
                    { 26, "Psychological" },
                    { 27, "Reverse harem" },
                    { 28, "Romance" },
                    { 29, "School" },
                    { 30, "Sci-fi" },
                    { 31, "Seinen" },
                    { 32, "Shoujo" },
                    { 33, "Shounen" },
                    { 34, "Slice of life" },
                    { 35, "Space" },
                    { 36, "Sports" },
                    { 37, "Super power" },
                    { 38, "Supernatural" },
                    { 39, "Suspense" },
                    { 40, "Thriller" },
                    { 41, "Vampire" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "On hold" },
                    { 2, "Canceled" },
                    { 3, "Releasing" },
                    { 4, "Not yet aired" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anime_StatusId",
                table: "Anime",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenre_GenresId",
                table: "AnimeGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Episode_AnimeId",
                table: "Episode",
                column: "AnimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeGenre");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
