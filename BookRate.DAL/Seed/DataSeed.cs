using BookRate.Common.Enums;
using BookRate.DAL.Context;
using BookRate.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BookRate.DAL.Seed
{
    public class DataSeed
    {
        public static void SeedDatabase(BookRateDbContext context)
        {
            context.Database.Migrate();

            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin" },
                    new Role { Name = "User" },
                    new Role { Name = "Author" },
                    new Role { Name = "Translator" },
                    new Role { Name = "Illustrator" }
                };
                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            if (!context.Genres.Any())
            {
                var genres = new List<Genre>
                {
                    new Genre { Name = "Fiction", Description = "Literary works based on imagination rather than fact." },
                    new Genre { Name = "Science Fiction", Description = "Fiction based on speculative scientific concepts, such as futuristic technology, space exploration, and extraterrestrial life." },
                    new Genre { Name = "Mystery", Description = "Fiction dealing with the solution of a crime or the unraveling of secrets." },
                    new Genre { Name = "Romance", Description = "Fictional stories revolving around love and romantic relationships." },
                    new Genre { Name = "Thriller", Description = "Fiction characterized by fast-paced plots, intense action, and suspenseful storylines." },
                    new Genre { Name = "Fantasy", Description = "Fictional stories often set in imaginary worlds featuring magical or supernatural elements." },
                    new Genre { Name = "Historical Fiction", Description = "Fiction set in the past, often featuring real historical events, figures, or settings." },
                    new Genre { Name = "Horror", Description = "Fiction intended to evoke fear, dread, or disgust in the reader, often through supernatural or macabre themes." },
                    new Genre { Name = "Adventure", Description = "Fictional stories involving exciting or daring experiences, often in exotic or dangerous settings." },
                    new Genre { Name = "Dystopian", Description = "Fiction set in a society characterized by oppressive government control and societal decay." },
                    new Genre { Name = "Detective Fiction", Description = "Fictional works that involve a detective or similar character solving a mystery or crime." },
                    new Genre { Name = "War Fiction", Description = "Fictional works set against the backdrop of war, exploring its effects on individuals and society." },
                    new Genre { Name = "Magical Realism", Description = "A genre where magical elements are a natural part of an otherwise mundane, realistic environment." },
                    new Genre { Name = "Contemporary Fiction", Description = "Fiction set in the present time, often dealing with current social issues and concerns." },
                    new Genre { Name = "Classic Literature", Description = "Works of literature that are considered to be of the highest quality and have stood the test of time." },
                    new Genre { Name = "Philosophical Literature", Description = "Fiction that explores philosophical ideas and themes, often through narrative and character development." },
                    new Genre { Name = "Children's Books", Description = "Books written for children, typically featuring engaging stories and colorful illustrations." }
                };

                context.Genres.AddRange(genres);
                context.SaveChanges();
            }

            if (!context.Settings.Any())
            {
                var settings = new List<Setting>
                {
                    new Setting { Name = "Victorian England" },
                    new Setting { Name = "Post-War America" },
                    new Setting { Name = "Contemporary Tokyo" },
                    new Setting { Name = "Regency England" },
                    new Setting { Name = "Imperial Russia" },
                    new Setting { Name = "Vietnam" },
                    new Setting { Name = "Southeast Asia" },
                    new Setting { Name = "California (United States)" },
                    new Setting { Name = "Montana (United States)" }
                };

                context.Settings.AddRange(settings);
                context.SaveChanges();
            }

            if (!context.Photos.Any())
            {
                var photos = new List<Photo>
                {
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/JaneAusten.jpg") },
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/ErnestHemingway.jpg") },
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/HarukiMurakami.jpg") },
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/JaneAusten.jpg") },
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/JaneAusten.jpg") },
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/JaneAusten.jpg") },
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/JaneAusten.jpg") },
                    new Photo { Data = GetPhotoData("../BookRate.DAL/Seed/Photos/JaneAusten.jpg") },
                };

                context.Photos.AddRange(photos);
                context.SaveChanges();
            }

            if (!context.Contributors.Any())
            {
                var contributor1 = new Contributor
                {
                    LastName = "Christie",
                    FirstName = "Agatha",
                    BirthDate = new DateTime(1890, 9, 15),
                    DeathDate = new DateTime(1976, 1, 12),
                    Biography = "Agatha Christie was an English writer known for her sixty-six detective novels and fourteen short story collections, particularly those revolving around fictional detectives Hercule Poirot and Miss Marple.",
                    BirthPlace = "Torquay, Devon, England",
                    Photo = context.Photos.FirstOrDefault(p => p.Id == 1),
                    ContributorRoles = new List<ContributorRole> { new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Author") ?? new Role { Name = "Author" } } },
                    Genres = new List<Genre>
                    {
                        context.Genres.FirstOrDefault(g => g.Name == "Mystery") ?? new Genre { Name = "Mystery", Description = "Fiction dealing with the solution of a crime or the unraveling of secrets." },
                        context.Genres.FirstOrDefault(g => g.Name == "Detective Fiction") ?? new Genre { Name = "Detective Fiction", Description = "Fictional works that involve a detective or similar character solving a mystery or crime." }
                    }
                };

                var contributor2 = new Contributor
                {
                    LastName = "Hemingway",
                    FirstName = "Ernest",
                    BirthDate = new DateTime(1899, 7, 21),
                    DeathDate = new DateTime(1961, 7, 2),
                    Biography = "Ernest Hemingway was an American novelist, short-story writer, journalist, and sportsman. His economical and understated style had a strong influence on 20th-century fiction, while his life of adventure and his public image influenced later generations.",
                    BirthPlace = "Oak Park, Illinois, United States",
                    Photo = context.Photos.FirstOrDefault(p => p.Id == 2),
                    ContributorRoles = new List<ContributorRole> { new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Author") ?? new Role { Name = "Author" } } },
                    Genres = new List<Genre>
                    {
                        context.Genres.FirstOrDefault(g => g.Name == "Literary Fiction") ?? new Genre { Name = "Literary Fiction", Description = "Fictional works of literary merit, often focusing on character development and narrative style." },
                        context.Genres.FirstOrDefault(g => g.Name == "War Fiction") ?? new Genre { Name = "War Fiction", Description = "Fictional works set against the backdrop of war, exploring its effects on individuals and society." }
                    }
                };

                var contributor3 = new Contributor
                {
                    LastName = "Murakami",
                    FirstName = "Haruki",
                    BirthDate = new DateTime(1949, 1, 12),
                    Biography = "Haruki Murakami is a Japanese writer. His books and stories have been bestsellers in Japan and internationally, with his work being translated into fifty languages and selling millions of copies outside his native country.",
                    BirthPlace = "Kyoto, Japan",
                    Photo = context.Photos.FirstOrDefault(p => p.Id == 3),
                    ContributorRoles = new List<ContributorRole> { new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Author") ?? new Role { Name = "Author" } } },
                    Genres = new List<Genre>
                    {
                        context.Genres.FirstOrDefault(g => g.Name == "Magical Realism") ?? new Genre { Name = "Magical Realism", Description = "A genre where magical elements are a natural part of an otherwise mundane, realistic environment." },
                        context.Genres.FirstOrDefault(g => g.Name == "Contemporary Fiction") ?? new Genre { Name = "Contemporary Fiction", Description = "Fiction set in the present time, often dealing with current social issues and concerns." }
                    }
                };

                var contributor4 = new Contributor
                {
                    LastName = "Austen",
                    FirstName = "Jane",
                    BirthDate = new DateTime(1775, 12, 16),
                    DeathDate = new DateTime(1817, 7, 18),
                    Biography = "Jane Austen was an English novelist known primarily for her six major novels, which interpret, critique and comment upon the British landed gentry at the end of the 18th century.",
                    BirthPlace = "Steventon, Hampshire, England",
                    Photo = context.Photos.FirstOrDefault(p => p.Id == 4),
                    ContributorRoles = new List<ContributorRole> { new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Author") ?? new Role { Name = "Author" } } },
                    Genres = new List<Genre>
                    {
                        context.Genres.FirstOrDefault(g => g.Name == "Romance") ?? new Genre { Name = "Romance", Description = "Fictional stories revolving around love and romantic relationships." },
                        context.Genres.FirstOrDefault(g => g.Name == "Classic Literature") ?? new Genre { Name = "Classic Literature", Description = "Works of literature that are considered to be of the highest quality and have stood the test of time." }
                    }
                };

                var contributor5 = new Contributor
                {
                    LastName = "Tolstoy",
                    FirstName = "Leo",
                    BirthDate = new DateTime(1828, 9, 9),
                    DeathDate = new DateTime(1910, 11, 20),
                    Biography = "Leo Tolstoy was a Russian writer who is regarded as one of the greatest authors of all time. He is best known for his novels War and Peace and Anna Karenina, often cited as pinnacles of realist fiction.",
                    BirthPlace = "Yasnaya Polyana, Tula Governorate, Russian Empire",
                    ContributorRoles = new List<ContributorRole> { new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Author") ?? new Role { Name = "Author" } } },
                    Genres = new List<Genre>
                    {
                        context.Genres.FirstOrDefault(g => g.Name == "Historical Fiction") ?? new Genre { Name = "Historical Fiction", Description = "Fiction set in the past, often featuring real historical events, figures, or settings." },
                        context.Genres.FirstOrDefault(g => g.Name == "Philosophical Literature") ?? new Genre { Name = "Philosophical Literature", Description = "Fiction that explores philosophical ideas and themes, often through narrative and character development." }
                    }
                };

                var contributor6 = new Contributor()
                {
                    LastName = "Doe",
                    FirstName = "John",
                    BirthDate = new DateTime(1985, 3, 10),
                    Biography = "John Doe is a talented writer known for his compelling narratives.",
                    BirthPlace = "New York, USA",
                    ContributorRoles = new List<ContributorRole> { new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Translator") } }
                };

                var contributor7 = new Contributor()
                {
                    LastName = "Smith",
                    FirstName = "Emma",
                    BirthDate = new DateTime(1978, 8, 22),
                    Biography = "Emma Smith is a versatile artist with skills in writing, illustration, and editing.",
                    BirthPlace = "London, UK",
                    ContributorRoles = new List<ContributorRole>
                        {
                            new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Author") },
                            new ContributorRole { Role = context.Roles.FirstOrDefault(r => r.Name == "Illustrator") }
                        },
                    Genres = new List<Genre> { context.Genres.FirstOrDefault(g => g.Name == "Fiction"), context.Genres.FirstOrDefault(g => g.Name == "Children's Books") }
                };

                context.Contributors.AddRange(contributor1, contributor2, contributor3, contributor4, contributor5, contributor6, contributor7);
                context.SaveChanges();
            }

            if (!context.Rewards.Any())
            {
                var rewards = new List<Reward>
                {
                    new Reward
                    {
                        Name = "BookBrowse Fiction Award",
                        Description = "Since 2000, BookBrowse has asked its members and subscribers to select the best books published each year. Through a rigorous voting process, this shortlist is then honed down to find the BookBrowse Awards Winners.",
                        Website = "https://www.bookbrowse.com/awards/detail/index.cfm/book_award_number/7/bookbrowse-awards"
                    },
                    new Reward
                    {
                        Name = "Pulitzer Prize for Fiction",
                        Description = "Joseph Pulitzer, a renowned journalist, established this award in 1917. Since 1984 Pulitzer winners have received their prizes from the president of Columbia University at a luncheon in May in the rotunda of the Low Library in the presence of family members, professional associates, board members, and the faculty of the School of Journalism.",
                        Website = "https://www.pulitzer.org/"
                    },
                     new Reward
                    {
                        Name = "Pulitzer Prize for Nonfiction",
                        Description = "Joseph Pulitzer, a renowned journalist, established this award in 1917. Since 1984 Pulitzer winners have received their prizes from the president of Columbia University at a luncheon in May in the rotunda of the Low Library in the presence of family members, professional associates, board members, and the faculty of the School of Journalism.",
                        Website = "https://www.pulitzer.org/"
                    },
                    new Reward
                    {
                        Name = "Pulitzer Prize for Biography",
                        Description = "Joseph Pulitzer, a renowned journalist, established this award in 1917. Since 1984 Pulitzer winners have received their prizes from the president of Columbia University at a luncheon in May in the rotunda of the Low Library in the presence of family members, professional associates, board members, and the faculty of the School of Journalism.",
                        Website = "https://www.pulitzer.org/"
                    },
                    new Reward
                    {
                        Name = "Booker Prize",
                        Description = "Awarded in October each year, the Booker Prize is the UK's top literary prize and the most watched single-book award in the English-speaking world. As of 2014 the award is open to authors worldwide so long as their work is in English and published in the UK. The International Booker Prize is awarded each May for a single work of fiction, translated into English and published in Ireland or the UK.",
                        Website = "https://thebookerprizes.com/"
                    },
                    new Reward
                    {
                        Name = "John Newbery Medal",
                        Description = "The Newbery Medal is awarded in January each year by the American Library Association for the most distinguished American children's book published the previous year.",
                        Website = "https://www.ala.org/alsc/awardsgrants/bookmedia/newbery#:~:text=The%20Newbery%20Medal%20was%20named,to%20American%20literature%20for%20children."
                    },
                    new Reward
                    {
                        Name = "Michael Printz Award",
                        Description = "Michael L. Printz Award for Excellence in Young Adult Literature",
                        Website = "https://www.ala.org/yalsa/printz"
                    },
                    new Reward
                    {
                        Name = "Edgar Award for Best Novel",
                        Description = "The Newbery Medal is awarded in January each year by the American Library Association for the most distinguished American children's book published the previous year.",
                        Website = "https://edgarawards.com/"
                    }

                };

                context.Rewards.AddRange(rewards);
                context.SaveChanges();
            }

            if (!context.Narratives.Any())
            {
                var narratives = new List<Narrative>
                {
                    new Narrative
                    {
                        Title = "Murder on the Orient Express",
                        Description = "Hercule Poirot investigates the murder of a wealthy American aboard the luxurious Orient Express train.",
                        OriginalTitle = "Murder on the Orient Express",
                        ThreeLetterIsolanguageName = "eng",
                        NarrativeContributorRoles = new List<NarrativeContributorRole>
                        {
                            new NarrativeContributorRole { ContributorRoleId = context.ContributorRoles.First(c => c.Contributor.LastName == "Christie" && c.Role.Name == "Author").Id }
                        },
                        Genres = new List<Genre> { context.Genres.First(g => g.Name == "Mystery"), context.Genres.First(g => g.Name == "Detective Fiction") },
                        Settings = new List<Setting> { context.Settings.First(s=>s.Name== "Victorian England"), context.Settings.First(s => s.Name == "Contemporary Tokyo") },
                        NarrativeRewards = new List<NarrativeReward>
                        {
                            new NarrativeReward { RewardId = context.Rewards.First(r => r.Name == "BookBrowse Fiction Award").Id, DateRewarded = new DateTime(2010, 2, 5) },
                            new NarrativeReward { RewardId = context.Rewards.First(r => r.Name == "Pulitzer Prize for Fiction").Id, DateRewarded = new DateTime(2004, 10, 12) },
                        },
                    },
                    new Narrative
                    {
                        Title = "The Old Man and the Sea",
                        Description = "An aging fisherman sets out on a journey to catch a giant marlin, testing his endurance and strength against the elements.",
                        OriginalTitle = "The Old Man and the Sea",
                        ThreeLetterIsolanguageName = "eng",
                        NarrativeContributorRoles = new List<NarrativeContributorRole>
                        {
                            new NarrativeContributorRole { ContributorRoleId = context.ContributorRoles.First(c => c.Contributor.LastName == "Hemingway" && c.Role.Name == "Author").Id }
                        },
                        Genres = new List<Genre> { context.Genres.First(g => g.Name == "Literary Fiction"), context.Genres.First(g => g.Name == "Adventure") },
                        Settings = new List<Setting> { context.Settings.First(s=>s.Name== "Post-War America") },
                        NarrativeRewards = new List<NarrativeReward>
                        {
                            new NarrativeReward { RewardId = context.Rewards.First(r => r.Name == "Booker Prize").Id, DateRewarded = new DateTime(2012, 2, 5) },
                            new NarrativeReward { RewardId = context.Rewards.First(r => r.Name == "Michael Printz Award").Id, DateRewarded = new DateTime(2003, 10, 12) },
                        },
                    },
                    new Narrative
                    {
                        Title = "Norwegian Wood",
                        Description = "A young man reflects on his college days, his relationships, and the loss of a close friend.",
                        OriginalTitle = "Norwegian Wood",
                        ThreeLetterIsolanguageName = "eng",
                        NarrativeContributorRoles = new List<NarrativeContributorRole>
                        {
                            new NarrativeContributorRole { ContributorRoleId = context.ContributorRoles.First(c => c.Contributor.LastName == "Austen" && c.Role.Name == "Author").Id }
                        },
                        Genres = new List<Genre> { context.Genres.First(g => g.Name == "Contemporary Fiction") },
                        Settings = new List<Setting> { context.Settings.First(s=>s.Name== "Contemporary Tokyo") }
                    },
                    new Narrative
                    {
                        Title = "Pride and Prejudice",
                        Description = "A witty and independent-minded woman clashes with a proud and wealthy gentleman, leading to unexpected consequences.",
                        OriginalTitle = "Pride and Prejudice",
                        ThreeLetterIsolanguageName = "eng",
                        NarrativeContributorRoles = new List<NarrativeContributorRole>
                        {
                            new NarrativeContributorRole { ContributorRoleId = context.ContributorRoles.First(c => c.Contributor.LastName == "Austen" && c.Role.Name == "Author").Id }
                        },
                        Genres = new List<Genre> { context.Genres.First(g => g.Name == "Romance"), context.Genres.First(g => g.Name == "Classic Literature") },
                        Settings = new List<Setting> { context.Settings.First(s=>s.Name== "Regency England") }
                    },
                    new Narrative
                    {
                        Title = "War and Peace",
                        Description = "A sweeping epic of love and war set against the backdrop of Napoleon's invasion of Russia.",
                        OriginalTitle = "Война и Мир",
                        ThreeLetterIsolanguageName = "eng",
                        NarrativeContributorRoles = new List<NarrativeContributorRole>
                        {
                            new NarrativeContributorRole { ContributorRoleId = context.ContributorRoles.First(c => c.Contributor.LastName == "Tolstoy" && c.Role.Name == "Author").Id },
                            new NarrativeContributorRole { ContributorRoleId = context.ContributorRoles.First(c => c.Contributor.LastName == "Doe" && c.Role.Name == "Translator").Id }
                        },
                        Genres = new List<Genre> { context.Genres.First(g => g.Name == "Historical Fiction"), context.Genres.First(g => g.Name == "Philosophical Literature") },
                        Settings = new List<Setting> { context.Settings.First(s=>s.Name== "Imperial Russia") }
                    },

                    new Narrative
                    {
                        Title = "The Sun Also Rises",
                        Description = "The quintessential novel of the Lost Generation, The Sun Also Rises (Fiesta) is one of Ernest Hemingway's masterpieces and a classic example of his spare but powerful writing style. A poignant look at the disillusionment and angst of the post-World War I generation, the novel introduces two of Hemingway's most unforgettable characters: Jake Barnes and Lady Brett Ashley. The story follows the flamboyant Brett and the hapless Jake as they journey from the wild nightlife of 1920s Paris to the brutal bullfighting rings of Spain with a motley group of expatriates. It is an age of moral bankruptcy, spiritual dissolution, unrealized love, and vanishing illusions. First published in 1926, The Sun Also Rises helped to establish Hemingway as one of the greatest writers of the twentieth century.",
                        ThreeLetterIsolanguageName = "eng",
                        NarrativeContributorRoles = new List<NarrativeContributorRole>
                        {
                            new NarrativeContributorRole { ContributorRoleId = context.ContributorRoles.First(c => c.Contributor.LastName == "Hemingway" && c.Role.Name == "Author").Id }
                        },
                        Genres = new List<Genre> { context.Genres.First(g => g.Name == "Fiction"), context.Genres.First(g => g.Name == "Historical Fiction"), context.Genres.First(g => g.Name == "Classic Literature")},
                        Settings = new List<Setting> { context.Settings.First(s=>s.Name== "Victorian England"), context.Settings.First(s => s.Name == "Contemporary Tokyo") }
                    },
                };

                context.Narratives.AddRange(narratives);
                context.SaveChanges();
            }

            if (!context.Editions.Any())
            {
                var editions = new List<Edition>
                {
                    new Edition { Name = "Pan Books", Website="https://www.panmacmillan.com/"},
                    new Edition { Name = "Scribner", Website="https://www.simonandschusterpublishing.com/scribner/"},
                    new Edition { Name = "Plume", Website="https://www.plumepress.com/"},
                    new Edition { Name = "Видавництво Ранок", Website="https://www.ranok.com.ua/"},
                    new Edition { Name = "Arrow Books", Website="https://en.wikipedia.org/wiki/Random_House"},
                    new Edition { Name = "Sourcebooks Fire", Website="https://www.sourcebooks.com/"},
                };

                context.Editions.AddRange(editions);
                context.SaveChanges();
            }

            if (!context.Books.Any())
            {
                var books = new List<Book> {
                    new Book {
                        Title = "Murder on the Orient Express",
                        FirstPublished = new DateTime(1934, 1, 1),
                        Narratives = new List<Narrative> { context.Narratives.First(n=> n.Title == "Murder on the Orient Express") },
                        BookEditions = new List<BookEdition> {
                            new BookEdition {
                                CoverType = (int)CoverType.Paperback,
                                PagesCount = 274 ,
                                EditionDate = new DateTime(2004,6,4),
                                Isbn = "9780007119318",
                                Edition = context.Editions.First(e => e.Name == "Pan Books"),
                                PhotoUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1486131451i/853510.jpg"
                            }
                        }
                    },
                    new Book {
                        Title = "The Old Man and the Sea",
                        FirstPublished = new DateTime(1952, 9, 1),
                        Narratives = new List<Narrative> { context.Narratives.First(n=> n.Title == "The Old Man and the Sea") },
                        BookEditions = new List<BookEdition> {
                            new BookEdition {
                                CoverType = (int)CoverType.Hardcover,
                                PagesCount = 96,
                                EditionDate = new DateTime(1996,1,1),
                                Isbn = "9780684830490",
                                Edition = context.Editions.First(e => e.Name == "Scribner"),
                                PhotoUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1713542603i/11297.jpg"
                            }
                        }
                    },
                    new Book {
                        Title = "Norwegian Wood",
                        FirstPublished = new DateTime(1952, 9, 1),
                        Narratives = new List<Narrative> { context.Narratives.First(n=> n.Title == "Norwegian Wood") },
                        BookEditions = new List<BookEdition> {
                            new BookEdition {
                                CoverType = (int)CoverType.Paperback,
                                PagesCount = 296,
                                EditionDate = new DateTime(2000,9,12),
                                Isbn = "9780375704024",
                                Edition = context.Editions.First(e => e.Name == "Pan Books"),
                                PhotoUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1329189714i/2165.jpg"
                            }
                        }
                    },
                    new Book {
                        Title = "Pride and Prejudice",
                        FirstPublished = new DateTime(1952, 9, 1),
                        Narratives = new List<Narrative> { context.Narratives.First(n=> n.Title == "Pride and Prejudice") },
                        BookEditions = new List<BookEdition> {
                            new BookEdition {
                                CoverType = (int)CoverType.Paperback,
                                PagesCount = 279,
                                EditionDate = new DateTime(2000,10,10),
                                Isbn = "9780375704024",
                                Edition = context.Editions.First(e => e.Name == "Plume"),
                                PhotoUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1320399351i/1885.jpg"
                            }
                        }
                    },
                    new Book {
                        Title = "War and Peace",
                        FirstPublished = new DateTime(1952, 9, 1),
                        Narratives = new List<Narrative> { context.Narratives.First(n=> n.Title == "War and Peace") },
                        BookEditions = new List<BookEdition> {
                            new BookEdition {
                                CoverType = (int)CoverType.Paperback,
                                PagesCount = 1392,
                                EditionDate = new DateTime(1998,6,25),
                                Isbn = "9780670034697",
                                Edition = context.Editions.First(e => e.Name == "Arrow Books"),
                                PhotoUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1579107863i/18241.jpg"
                            }
                        }
                    },
                    new Book {
                        Title = "The Sun Also Rises",
                        FirstPublished = new DateTime(1952, 9, 1),
                        Narratives = new List<Narrative> { context.Narratives.First(n=> n.Title == "The Sun Also Rises") },
                        BookEditions = new List<BookEdition> {
                            new BookEdition {
                                CoverType = (int)CoverType.Paperback,
                                PagesCount = 189,
                                EditionDate = new DateTime(2003,1,1),
                                Isbn = "9780684800714",
                                Edition = context.Editions.First(e => e.Name == "Arrow Books"),
                                PhotoUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1355359043i/46168.jpg"
                            }
                        }
                    },
                    new Book {
                        Title = "The Complete Short Stories of Ernest Hemingway",
                        FirstPublished = new DateTime(1952, 9, 1),
                        Narratives = new List<Narrative> {
                            context.Narratives.First(n=> n.Title == "The Sun Also Rises"),
                            context.Narratives.First(n => n.Title == "The Old Man and the Sea")
                        },
                        BookEditions = new List<BookEdition> {
                            new BookEdition {
                                CoverType = (int)CoverType.Paperback,
                                PagesCount = 304,
                                EditionDate = new DateTime(2003,1,1),
                                Isbn = "9780684843322",
                                Edition = context.Editions.First(e => e.Name == "Arrow Books"),
                                PhotoUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1523546158i/4625.jpg"
                            }
                        }
                    }
                };

                context.Books.AddRange(books);
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        Email = "user1@gmail.com",
                        Password = "user1pasword".GetHashCode().ToString(),
                        Username = "User1",
                        LastName = "Ivanov",
                        FirstName = "Ivan",
                        Patronymic = "Ivanovich",
                        PhotoId = 5,
                        Interests = "Love fiction and my dog",
                        Roles = new List<Role> { context.Roles.First(r => r.Name == "User") }
                    },

                     new User
                     {
                        Email = "user2@gmail.com",
                        Password = "user2pasword".GetHashCode().ToString(),
                        Username = "User2",
                        LastName = "Petrov",
                        FirstName = "Petro",
                        Patronymic = "Ivanovich",
                        PhotoId = 6,
                        Interests = "Garden enjoyer, interested in biology.",
                        Roles = new List<Role> { context.Roles.First(r => r.Name == "User") }
                     },

                    new User
                    {
                        Email = "admin@gmail.com",
                        Password = "admin_pasword".GetHashCode().ToString(),
                        Username = "admin",
                        LastName = "admin_123123",
                        FirstName = "admin_123123",
                        Patronymic = "admin_123123",
                        Roles = new List<Role> { context.Roles.First(r => r.Name == "Admin") }
                    },

                    new User
                    {
                        Email = "author1@gmail.com",
                        Password = "author1pasword".GetHashCode().ToString(),
                        Username = "Author1",
                        LastName = "Donald",
                        FirstName = "Trump",
                        PhotoId = 7,
                        Interests = "My country is only my interest.",
                        Roles = new List<Role> { context.Roles.First(r => r.Name == "User"), context.Roles.First(r => r.Name == "Author") }
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Shelves.Any())
            {
                var shelves = new List<Shelf>
                {
                    new Shelf
                    {
                        Name = "Best about gardening",
                        Description = "This are all books you need to start your own garden.",
                        IsPublic = true,
                        User = context.Users.First(u => u.Username == "User2"),
                        Books = new List<Book>
                        {
                            context.Books.First(b => b.Title == "The Old Man and the Sea"),
                            context.Books.First(b => b.Title == "Murder on the Orient Express")
                        }
                    },
                    new Shelf
                    {
                        Name = "Best about seeds",
                        Description = "",
                        IsPublic = false,
                        User = context.Users.First(u => u.Username == "User2"),
                        Books = new List<Book>
                        {
                            context.Books.First(b => b.Title == "War and Peace"),
                            context.Books.First(b => b.Title == "The Old Man and the Sea")
                        }
                    },
                    new Shelf
                    {
                        Name = "President literature",
                        Description = "Read this to get knowlenge about how to rule the country",
                        IsPublic = true,
                        User = context.Users.First(u => u.Username == "Author1"),
                        Books = new List<Book>
                        {
                            context.Books.First(b => b.Title == "War and Peace"),
                        }
                    }
                };
            }

            if (!context.Rates.Any())
            {
                var rates = new List<Rate>
                {
                    new Rate
                    {
                        StarsRate = 5,
                        User = context.Users.First(u => u.Username == "Author1"),
                        Book = context.Books.First(b => b.Title == "War and Peace"),
                        DateRated = DateTime.Now
                    },
                    new Rate
                    {
                        StarsRate = 4,
                        User = context.Users.First(u => u.Username == "User1"),
                        Book = context.Books.First(b => b.Title == "War and Peace"),
                        DateRated = DateTime.Now
                    },
                    new Rate
                    {
                        StarsRate = 2,
                        User = context.Users.First(u => u.Username == "User2"),
                        Book = context.Books.First(b => b.Title == "War and Peace"),
                        DateRated = DateTime.Now
                    },
                    new Rate
                    {
                        StarsRate = 4,
                        User = context.Users.First(u => u.Username == "User2"),
                        Book = context.Books.First(b => b.Title == "The Old Man and the Sea"),
                        DateRated = DateTime.Now
                    },
                    new Rate
                    {
                        StarsRate = 1,
                        User = context.Users.First(u => u.Username == "Author1"),
                        Book = context.Books.First(b => b.Title == "The Old Man and the Sea"),
                        DateRated = DateTime.Now
                    },
                };

                context.Rates.AddRange(rates);
                context.SaveChanges();
            }

            if (!context.Reviews.Any())
            {
                var reviews = new List<Review>
                {
                    new Review
                    {
                        RateId = context.Rates.First(r => r.User.Username == "Author1" && r.Book.Title == "The Old Man and the Sea").Id,
                        Title = "Not as bad as I expected",
                        Text = "Ernest Hemingway's \"The Old Man and the Sea\" is a timeless novella that exemplifies the struggle and triumph of the human spirit. The story follows Santiago, an aged Cuban fisherman who embarks on an epic battle with a giant marlin in the Gulf Stream. Hemingway's spare, evocative prose vividly captures the stark beauty of the sea and the grueling physical and emotional endurance required for Santiago's quest. The novella's profound themes of resilience, dignity, and man's relationship with nature resonate deeply, making it a powerful and enduring piece of literature. Hemingway's masterful storytelling ensures that \"The Old Man and the Sea\" remains a poignant and inspiring read.",
                        DatePosted = DateTime.Now,
                        StartReadDate = new DateTime(2021, 5, 4),
                        EndReadDate = new DateTime(2021, 6, 1)
                    },
                    new Review
                    {
                        RateId = context.Rates.First(r => r.User.Username == "User1" && r.Book.Title == "War and Peace").Id,
                        Title = "Almost the best i have ever read",
                        Text = "Leo Tolstoy's \"War and Peace\" is a monumental work of literature that intricately weaves together the lives of several aristocratic families against the backdrop of the Napoleonic Wars. The novel's sprawling narrative encompasses a vast array of characters, each richly developed and uniquely flawed, from the introspective Pierre Bezukhov to the spirited Natasha Rostov and the stoic Prince Andrei Bolkonsky. Tolstoy's profound exploration of themes such as fate, free will, and the nature of history is matched by his meticulous attention to historical detail and his philosophical reflections on war and peace. Despite its length and complexity, \"War and Peace\" remains a deeply engaging and rewarding read, offering a profound insight into human nature and the forces that shape our lives.",
                        DatePosted = DateTime.Now,
                        StartReadDate = new DateTime(2020, 10, 4),
                        EndReadDate = new DateTime(2021, 8, 25)
                    },
                    new Review
                    {
                        RateId = context.Rates.First(r => r.User.Username == "User2" && r.Book.Title == "War and Peace").Id,
                        Title = "Bad",
                        Text = "Leo Tolstoy's \"War and Peace\" is a monumental work of literature that intricately weaves together the lives of several aristocratic families against the backdrop of the Napoleonic Wars. The novel's sprawling narrative encompasses a vast array of characters, each richly developed and uniquely flawed, from the introspective Pierre Bezukhov to the spirited Natasha Rostov and the stoic Prince Andrei Bolkonsky. Tolstoy's profound exploration of themes such as fate, free will, and the nature of history is matched by his meticulous attention to historical detail and his philosophical reflections on war and peace. Despite its length and complexity, \"War and Peace\" remains a deeply engaging and rewarding read, offering a profound insight into human nature and the forces that shape our lives.",
                        DatePosted = DateTime.Now,
                        StartReadDate = new DateTime(2023, 10, 4),
                        EndReadDate = new DateTime(2024, 8, 25)
                    }
                };
            }
        }

        private static byte[] GetPhotoData(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Photo file not found.", path);
            }

            byte[] photoData;
            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    photoData = reader.ReadBytes((int)stream.Length);
                }
            }

            return photoData;
        }
    }
}
