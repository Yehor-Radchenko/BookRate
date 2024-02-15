using System;
using System.Collections.Generic;
using BookRate.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Context;

public partial class BookRateDbContext : DbContext
{
    public BookRateDbContext()
    {
        Database.EnsureCreated();
    }

    public BookRateDbContext(DbContextOptions<BookRateDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookEdition> BookEditions { get; set; }

    public virtual DbSet<Commentary> Commentaries { get; set; }

    public virtual DbSet<CommentaryLike> CommentaryLikes { get; set; }

    public virtual DbSet<Contributor> Contributors { get; set; }

    public virtual DbSet<Edition> Editions { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Narrative> Narratives { get; set; }

    public virtual DbSet<NarrativeRevard> NarrativeRevards { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Revard> Revards { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewLike> ReviewLikes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Serie> Series { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BookRate;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommentaryLike>()
        .HasKey(cl => new { cl.UserId, cl.CommentaryId });

        modelBuilder.Entity<ReviewLike>()
        .HasKey(cl => new { cl.UserId, cl.ReviewId });

        modelBuilder.Entity<Rate>()
       .HasKey(cl => new { cl.UserId, cl.BookId });

        modelBuilder.Entity<Commentary>()
            .HasOne(c => c.User)
            .WithMany(u => u.Commentaries)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ReviewLike>()
            .HasOne(rl => rl.User)
            .WithMany()
            .HasForeignKey(rl => rl.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CommentaryLike>()
            .HasOne(cl => cl.User)
            .WithMany()
            .HasForeignKey(cl => cl.UserId)
            .OnDelete(DeleteBehavior.Restrict);

    }
}
