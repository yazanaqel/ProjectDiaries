using System.ComponentModel.DataAnnotations;

namespace ProjectDiaries.Shared;

public class Diary
{
    public int Id { get; set; }
    public string? Image { get; set; }

    [Required]
    public string Title { get; set; }=string.Empty;
    [Required]
    public string Content { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;

    public DateTime DateCreated { get; set; } = DateTime.Now;
}
