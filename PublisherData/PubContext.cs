using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublisherDomain;

namespace PublisherData;

public class PubContext : DbContext
{
    public DbSet<Author> Authors { get; set; } = default!;
    public DbSet<Book> Books { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder
            .UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=PubDb;Trusted_Connection=True;MultipleActiveResultSets=true")
            .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name, DbLoggerCategory.ChangeTracking.Name },
                LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithOne(b => b.Author).IsRequired(false);

        modelBuilder.Entity<Author>().HasData(new Author { FirstName = "pierwszy", LastName = "ostatni", Id = 1 });
    }
}
