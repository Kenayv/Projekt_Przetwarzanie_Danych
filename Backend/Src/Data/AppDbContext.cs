using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Listing> Listings => Set<Listing>();
    public DbSet<Message> Messages => Set<Message>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();

        modelBuilder.Entity<Listing>()
            .Property(l => l.Type).HasConversion<string>();

        modelBuilder.Entity<Listing>()
            .Property(l => l.Status).HasConversion<string>();

        modelBuilder.Entity<UserSettings>()
            .HasKey(s => s.UserId);

        modelBuilder.Entity<UserSettings>()
            .HasOne(s => s.User)
            .WithOne(u => u.Settings)
            .HasForeignKey<UserSettings>(s => s.UserId);

        modelBuilder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict);
            
        modelBuilder.Entity<Message>()
            .HasOne(m => m.Receiver)
            .WithMany()
            .HasForeignKey(m => m.ReceiverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}