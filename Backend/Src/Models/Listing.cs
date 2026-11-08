using System.ComponentModel.DataAnnotations;

public class Listing
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = "";

    [Required]
    [MaxLength(2000)]
    public string Description { get; set; } = "";

    public ListingType Type { get; set; }
    public ListingStatus Status { get; set; } = ListingStatus.Active;

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public DateTime EventDate { get; set; }
    public DateTime ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string? EventCity { get; set; }

    public List<Message> Messages { get; set; } = new();
}