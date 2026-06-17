using System.ComponentModel.DataAnnotations;

public class Place
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Category { get; set; }

    public string Address { get; set; }

    public string Note { get; set; }

    public int Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}