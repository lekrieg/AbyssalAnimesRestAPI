using AnimeAPI.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnimeAPI.Application.DTOs;

public class AnimeDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Anime name is required!")]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public byte[] Image { get; set; }
    
    public string ReleaseSeason { get; set; }
    
    public DateTime? ReleaseDate { get; set; }
    
    public int TotalEpisodesAmount { get; set; }
    
    public string Studio { get; set; }

    public int GenreId { get; set; }

    public Status Status { get; set; }
}
