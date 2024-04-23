using System.ComponentModel.DataAnnotations;

namespace AnimeAPI.Application.DTOs;

public class EpisodeDTO
{
    /*
     * A controler vai receber uma lista de IformFile,
     * vai converter e preencher as coisas para o DTO, o dto é mapeado para a entidade
     * na hora de baixar eu converto tudo pra lista IFormFile de volta
     * 
     * se eu nao passar o id, preciso retornar a lista inteira
     */
    public int Id { get; set; }

    [Required(ErrorMessage = "Anime id is required!")]
    public int AnimeId { get; set; }

    [Required(ErrorMessage = "Episode needs a name!")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Episode needs a file type!")]
    public string FileType { get; set; }

    [Required(ErrorMessage = "Theres no episode!")]
    public byte[] EpisodeData { get; set; }
}
