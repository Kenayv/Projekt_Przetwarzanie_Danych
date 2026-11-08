public static class DbSeeder
{
    public static void Seed(AppDbContext db)
    {
        if (db.Users.Any()) return; // dane już są

        var categories = new[]
        {
            new Category { Name = "Telefony", Description = "Smartfony i akcesoria" },
            new Category { Name = "Portfele i dokumenty" },
            new Category { Name = "Klucze" },
            new Category { Name = "Zwierzęta" }
        };
        db.Categories.AddRange(categories);

        var jan = new User
        {
            Email = "jan@example.com",
            PasswordHash = "fake-hash-1",
            FirstName = "Jan",
            LastName = "Kowalski",
            PhoneNumber = "123456789",
            Settings = new UserSettings { Theme = Theme.Dark, Language = "PL" }
        };
        var anna = new User
        {
            Email = "anna@example.com",
            PasswordHash = "fake-hash-2",
            FirstName = "Anna",
            LastName = "Nowak",
            Settings = new UserSettings()
        };
        db.Users.AddRange(jan, anna);

        var listing1 = new Listing
        {
            User = jan,
            Category = categories[0],
            Title = "Zgubiłem iPhone'a",
            Description = "Czarny iPhone w niebieskim etui, zgubiony w tramwaju.",
            Type = ListingType.Lost,
            Latitude = 50.2649,
            Longitude = 19.0238,
            EventDate = DateTime.UtcNow.AddDays(-2),
            ExpiresAt = DateTime.UtcNow.AddDays(28),
            EventCity = "Katowice"
        };
        var listing2 = new Listing
        {
            User = anna,
            Category = categories[2],
            Title = "Znaleziono klucze",
            Description = "Pęk trzech kluczy z brelokiem w kształcie kota.",
            Type = ListingType.Found,
            Latitude = 50.2599,
            Longitude = 19.0216,
            EventDate = DateTime.UtcNow.AddDays(-1),
            ExpiresAt = DateTime.UtcNow.AddDays(29),
            EventCity = "Katowice"
        };
        db.Listings.AddRange(listing1, listing2);

        db.Messages.Add(new Message
        {
            Sender = anna,
            Receiver = jan,
            Listing = listing1,
            Content = "Cześć, chyba znalazłam twój telefon!"
        });

        db.SaveChanges();
    }
}