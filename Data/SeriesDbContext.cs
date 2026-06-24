using Microsoft.EntityFrameworkCore;
using AllSeriesApi.Models;

namespace AllSeriesApi.Data;

public class SeriesDbContext(DbContextOptions<SeriesDbContext> options) : DbContext(options)
{
    public DbSet<Series> Series { get; set; }
    public DbSet<Anime> Animes { get; set; }
    public DbSet<Film> Films { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Series>()
        .Property(x => x.Name)
        .HasMaxLength(100)
        .IsRequired();

        modelBuilder
        .Entity<Series>()
        .Property(x => x.Rating)
        .IsRequired();

        modelBuilder
        .Entity<Series>()
        .Property(x => x.Episodes)
        .IsRequired();

        modelBuilder
        .Entity<Series>()
        .Property(x => x.Seasons)
        .IsRequired();

        modelBuilder
        .Entity<Film>()
        .Property(x => x.Name)
        .HasMaxLength(100)
        .IsRequired();

        modelBuilder
        .Entity<Film>()
        .Property(x => x.Rating)
        .IsRequired();

        modelBuilder
        .Entity<Film>()
        .Property(x => x.NumberOfMovies)
        .IsRequired();
    
        
        modelBuilder
        .Entity<Anime>()
        .Property(x => x.Name)
        .HasMaxLength(100)
        .IsRequired();

        modelBuilder
        .Entity<Anime>()
        .Property(x => x.Rating)
        .IsRequired();

        modelBuilder
        .Entity<Anime>()
        .Property(x => x.Episodes)
        .IsRequired();

        modelBuilder
        .Entity<Anime>()
        .Property(x => x.Seasons)
        .IsRequired();
    }
}
