using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(255)]
    public string Email { get; set; } = "";

    [Required]
    public string PasswordHash { get; set; } = "";

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = "";

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = "";

    [MaxLength(20)]
    public string? PhoneNumber { get; set; }

    public UserSettings Settings { get; set; }
    public List<Listing> Listings { get; set; } = new();

}
