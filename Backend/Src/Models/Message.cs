using System.ComponentModel.DataAnnotations;

public class Message
{
    public int Id { get; set; }

    public int SenderId { get; set; }
    public User Sender { get; set; } = null!;

    public int ReceiverId { get; set; }
    public User Receiver { get; set; } = null!;

    public int ListingId { get; set; }
    public Listing Listing { get; set; } = null!;

    [Required]
    [MaxLength(2000)]
    public string Content { get; set; } = "";

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReadAt { get; set; }
}