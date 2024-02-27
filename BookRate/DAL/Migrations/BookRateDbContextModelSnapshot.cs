﻿// <auto-generated />
using System;
using BookRate.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookRate.Migrations
{
    [DbContext(typeof(BookRateDbContext))]
    partial class BookRateDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookNarrative", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("NarrativesId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "NarrativesId");

                    b.HasIndex("NarrativesId");

                    b.ToTable("BookNarrative");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FirstPublished")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookRate.DAL.Models.BookEdition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CoverType")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EditionId")
                        .HasColumnType("int");

                    b.Property<string>("Ibsn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PagesCount")
                        .HasColumnType("int");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("EditionId");

                    b.ToTable("BookEditions");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Commentary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCommented")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("Commentaries");
                });

            modelBuilder.Entity("BookRate.DAL.Models.CommentaryLike", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("CommentaryId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("DateLiked")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("UserId", "CommentaryId");

                    b.HasIndex("CommentaryId");

                    b.HasIndex("UserId1");

                    b.ToTable("CommentaryLikes");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Contributor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeathDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Contributors");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Edition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Editions");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Narrative", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThreeLetterIsolanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Narratives");
                });

            modelBuilder.Entity("BookRate.DAL.Models.NarrativeRevard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateRevarded")
                        .HasColumnType("datetime2");

                    b.Property<int>("NarrativeId")
                        .HasColumnType("int");

                    b.Property<int>("RevardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NarrativeId");

                    b.HasIndex("RevardId");

                    b.ToTable("NarrativeRevards");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Rate", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRated")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("StarsRate")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Revard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Revards");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("EndReadDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartReadDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookRate.DAL.Models.ReviewLike", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("ReviewId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("DateLiked")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ReviewId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId1");

                    b.ToTable("ReviewLikes");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("BookRate.DAL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Interests")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ContributorNarrative", b =>
                {
                    b.Property<int>("ContributorsId")
                        .HasColumnType("int");

                    b.Property<int>("NarrativesId")
                        .HasColumnType("int");

                    b.HasKey("ContributorsId", "NarrativesId");

                    b.HasIndex("NarrativesId");

                    b.ToTable("ContributorNarrative");
                });

            modelBuilder.Entity("ContributorRole", b =>
                {
                    b.Property<int>("ContributorsId")
                        .HasColumnType("int");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.HasKey("ContributorsId", "RolesId");

                    b.HasIndex("RolesId");

                    b.ToTable("ContributorRole");
                });

            modelBuilder.Entity("GenreNarrative", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("int");

                    b.Property<int>("NarrativesId")
                        .HasColumnType("int");

                    b.HasKey("GenresId", "NarrativesId");

                    b.HasIndex("NarrativesId");

                    b.ToTable("GenreNarrative");
                });

            modelBuilder.Entity("NarrativeSetting", b =>
                {
                    b.Property<int>("NarrativesId")
                        .HasColumnType("int");

                    b.Property<int>("SettingsId")
                        .HasColumnType("int");

                    b.HasKey("NarrativesId", "SettingsId");

                    b.HasIndex("SettingsId");

                    b.ToTable("NarrativeSetting");
                });

            modelBuilder.Entity("BookNarrative", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.Narrative", null)
                        .WithMany()
                        .HasForeignKey("NarrativesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookRate.DAL.Models.Book", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Serie", "Serie")
                        .WithMany("Books")
                        .HasForeignKey("SerieId");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("BookRate.DAL.Models.BookEdition", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Book", "Book")
                        .WithMany("BookEditions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.Edition", "Edition")
                        .WithMany("BookEditions")
                        .HasForeignKey("EditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Edition");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Commentary", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Review", "Review")
                        .WithMany("Commentaries")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.User", "User")
                        .WithMany("Commentaries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookRate.DAL.Models.CommentaryLike", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Commentary", "Commentary")
                        .WithMany("CommentaryLikes")
                        .HasForeignKey("CommentaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.User", null)
                        .WithMany("CommentaryLikes")
                        .HasForeignKey("UserId1");

                    b.Navigation("Commentary");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookRate.DAL.Models.NarrativeRevard", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Narrative", "Narrative")
                        .WithMany("NarrativeRevards")
                        .HasForeignKey("NarrativeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.Revard", "Revard")
                        .WithMany("NarrativeRevards")
                        .HasForeignKey("RevardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Narrative");

                    b.Navigation("Revard");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Rate", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Book", "Book")
                        .WithMany("Rates")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.User", "User")
                        .WithMany("Rates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Review", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookRate.DAL.Models.ReviewLike", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Review", "Review")
                        .WithMany("ReviewLikes")
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.User", null)
                        .WithMany("ReviewLikes")
                        .HasForeignKey("UserId1");

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ContributorNarrative", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Contributor", null)
                        .WithMany()
                        .HasForeignKey("ContributorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.Narrative", null)
                        .WithMany()
                        .HasForeignKey("NarrativesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContributorRole", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Contributor", null)
                        .WithMany()
                        .HasForeignKey("ContributorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreNarrative", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.Narrative", null)
                        .WithMany()
                        .HasForeignKey("NarrativesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NarrativeSetting", b =>
                {
                    b.HasOne("BookRate.DAL.Models.Narrative", null)
                        .WithMany()
                        .HasForeignKey("NarrativesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookRate.DAL.Models.Setting", null)
                        .WithMany()
                        .HasForeignKey("SettingsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookRate.DAL.Models.Book", b =>
                {
                    b.Navigation("BookEditions");

                    b.Navigation("Rates");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Commentary", b =>
                {
                    b.Navigation("CommentaryLikes");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Edition", b =>
                {
                    b.Navigation("BookEditions");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Narrative", b =>
                {
                    b.Navigation("NarrativeRevards");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Revard", b =>
                {
                    b.Navigation("NarrativeRevards");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Review", b =>
                {
                    b.Navigation("Commentaries");

                    b.Navigation("ReviewLikes");
                });

            modelBuilder.Entity("BookRate.DAL.Models.Serie", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookRate.DAL.Models.User", b =>
                {
                    b.Navigation("Commentaries");

                    b.Navigation("CommentaryLikes");

                    b.Navigation("Rates");

                    b.Navigation("ReviewLikes");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
