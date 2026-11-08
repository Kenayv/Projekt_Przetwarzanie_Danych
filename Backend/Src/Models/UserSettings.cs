using System.ComponentModel.DataAnnotations;

public class UserSettings
{
    // PK i jednocześnie FK do Users
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public Theme Theme { get; set; } = Theme.System;

    [MaxLength(5)]
    public string Language { get; set; } = "PL";
}