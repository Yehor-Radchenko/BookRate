
using BookRate.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRate.DAL.Context;

public partial class BookRateDbContext : DbContext
{
    public BookRateDbContext(DbContextOptions<BookRateDbContext> options)
        : base(options)
    { }

    public virtual DbSet<Photo> Photos { get; set; }

    public virtual DbSet<NarrativeContributorRole> NarrativeContributorRoles { get; set; }

    public virtual DbSet<ContributorRole> ContributorRoles { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookEdition> BookEditions { get; set; }

    public virtual DbSet<Commentary> Commentaries { get; set; }

    public virtual DbSet<CommentaryLike> CommentaryLikes { get; set; }

    public virtual DbSet<Contributor> Contributors { get; set; }

    public virtual DbSet<Edition> Editions { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Narrative> Narratives { get; set; }

    public virtual DbSet<NarrativeReward> NarrativeRewards { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Reward> Rewards { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewLike> ReviewLikes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }


    public virtual DbSet<Restrict> Restricts { get; set; }

    public virtual DbSet<Serie> Series { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Shelf> Shelves { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }


    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<CommentaryLike>()
            .HasKey(cl => new { cl.UserId, cl.CommentaryId });
        modelBuilder.Entity<CommentaryLike>()
           .HasOne(cl => cl.User)
           .WithMany(u => u.CommentaryLikes)
           .HasForeignKey(cl => cl.UserId)
           .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<ReviewLike>()
            .HasKey(cl => new { cl.UserId, cl.ReviewId });
        modelBuilder.Entity<ReviewLike>()
           .HasOne(rl => rl.User)
           .WithMany(u => u.ReviewLikes)
           .HasForeignKey(rl => rl.UserId)
           .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Follow>()
           .HasKey(f => new { f.FolloweeId, f.FollowerId });


        modelBuilder.Entity<Rate>()
           .HasKey(r => r.Id);
        modelBuilder.Entity<Rate>()
          .HasIndex(r => new { r.UserId, r.BookId })
          .IsUnique();


        modelBuilder.Entity<Commentary>()
            .HasOne(c => c.User)
            .WithMany(u => u.Commentaries)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique(true);
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique(true);
        modelBuilder.Entity<User>()
           .HasIndex(u => u.PhotoId)
           .IsUnique();
        modelBuilder.Entity<User>()
                .HasOne(c => c.Photo)
                .WithOne()
                .HasForeignKey<User>(c => c.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NarrativeContributorRole>()
            .HasKey(ncr => new { ncr.NarrativeId, ncr.ContributorRoleId });
        modelBuilder.Entity<NarrativeContributorRole>()
            .HasOne(ncr => ncr.Narrative)
            .WithMany(n => n.NarrativeContributorRoles)
            .HasForeignKey(ncr => ncr.NarrativeId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<NarrativeContributorRole>()
            .HasOne(ncr => ncr.ContributorRole)
            .WithMany(c => c.NarrativeContributorRoles)
            .HasForeignKey(ncr => ncr.ContributorRoleId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<ContributorRole>()
           .HasKey(cr => cr.Id);
        modelBuilder.Entity<ContributorRole>()
            .HasIndex(cr => new { cr.ContributorId, cr.RoleId })
            .IsUnique();
        modelBuilder.Entity<ContributorRole>()
           .HasOne(cr => cr.Role)
           .WithMany(r => r.ContributorRoles)
           .HasForeignKey(cr => cr.RoleId)
           .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Genre>()
           .HasIndex(g => g.Name)
           .IsUnique();
        modelBuilder.Entity<Genre>()
           .HasMany(g => g.Narratives)
           .WithMany(n => n.Genres)
           .UsingEntity<Dictionary<string, object>>(
               "GenreNarrative",
               j => j
                   .HasOne<Narrative>()
                   .WithMany()
                   .HasForeignKey("NarrativeId")
                   .OnDelete(DeleteBehavior.Cascade),
               j => j
                   .HasOne<Genre>()
                   .WithMany()
                   .HasForeignKey("GenreId")
                   .OnDelete(DeleteBehavior.Restrict)
           );

        modelBuilder.Entity<Book>()
            .HasMany(b => b.Narratives)
            .WithMany(n => n.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookNarrative",
                j => j.HasOne<Narrative>()
                      .WithMany()
                      .HasForeignKey("NarrativeId")
                      .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne<Book>()
                      .WithMany()
                      .HasForeignKey("BookId")
                      .OnDelete(DeleteBehavior.Cascade)
            );


        modelBuilder.Entity<Setting>()
          .HasMany(g => g.Narratives)
          .WithMany(n => n.Settings)
          .UsingEntity<Dictionary<string, object>>(
              "NarrativeSetting",
              j => j
                  .HasOne<Narrative>()
                  .WithMany()
                  .HasForeignKey("NarrativeId")
                  .OnDelete(DeleteBehavior.Cascade),
              j => j
                  .HasOne<Setting>()
                  .WithMany()
                  .HasForeignKey("SettingId")
                  .OnDelete(DeleteBehavior.Restrict)
          );

        modelBuilder.Entity<Contributor>()
                .HasOne(c => c.Photo)
                .WithOne()
                .HasForeignKey<Contributor>(c => c.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Review>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BookId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Review>()
            .HasOne(r => r.Rate)
            .WithMany(rt => rt.Reviews)
            .HasForeignKey(r => r.RateId)
            .OnDelete(DeleteBehavior.Restrict);



      
    }
}
