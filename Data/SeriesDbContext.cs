using Microsoft.EntityFrameworkCore;
using AllSeriesApi.Models;

namespace AllSeriesApi.Data;

public class SeriesDbContext(DbContextOptions<SeriesDbContext> options) : DbContext(options)
{
    public DbSet<SeriesModel> Series { get; set; }
    public DbSet<AnimeModel> Animes { get; set; }
    public DbSet<FilmModel> Films { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<SeriesModel>()
        .Property(x => x.Id)
        .HasColumnType("binary(16)");

        modelBuilder
        .Entity<SeriesModel>()
        .Property(x => x.Name)
        .HasMaxLength(100)
        .IsRequired();

        modelBuilder
        .Entity<SeriesModel>()
        .Property(x => x.Rating)
        .IsRequired();

        modelBuilder
        .Entity<SeriesModel>()
        .Property(x => x.Episodes)
        .IsRequired();

        modelBuilder
        .Entity<SeriesModel>()
        .Property(x => x.Seasons)
        .IsRequired();

        modelBuilder.Entity<FilmModel>()
        .Property(x => x.Id)
        .HasColumnType("binary(16)");

        modelBuilder
        .Entity<FilmModel>()
        .Property(x => x.Name)
        .HasMaxLength(100)
        .IsRequired();

        modelBuilder
        .Entity<FilmModel>()
        .Property(x => x.Rating)
        .IsRequired();

        modelBuilder
        .Entity<FilmModel>()
        .Property(x => x.NumberOfMovies)
        .IsRequired();

        modelBuilder
        .Entity<AnimeModel>()
        .Property(x => x.Id)
        .HasColumnType("binary(16)");

        modelBuilder
        .Entity<AnimeModel>()
        .Property(x => x.Name)
        .HasMaxLength(100)
        .IsRequired();

        modelBuilder
        .Entity<AnimeModel>()
        .Property(x => x.Rating)
        .IsRequired();

        modelBuilder
        .Entity<AnimeModel>()
        .Property(x => x.Episodes)
        .IsRequired();

        modelBuilder
        .Entity<AnimeModel>()
        .Property(x => x.Seasons)
        .IsRequired();
    }
}
