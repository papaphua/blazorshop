using BlazorShop.Server.Common;
using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Entities.Joints;
using Microsoft.EntityFrameworkCore;

namespace BlazorShop.Server.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Security> Securities { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<RolePermission> RolePermissions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Relations
        modelBuilder.Entity<User>().HasOne(user => user.Role)
            .WithMany();
        modelBuilder.Entity<Product>()
            .HasMany(product => product.Comments)
            .WithOne();
        modelBuilder.Entity<Role>()
            .HasMany(role => role.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        //Seeding
        var bookCategoryId = Guid.NewGuid();
        var movieCategoryId = Guid.NewGuid();
        var videoGameCategoryId = Guid.NewGuid();

        var permissions = Enum.GetValues<Permissions>()
            .Select(permission => new Permission
            {
                Id = (int)permission,
                Name = permission.ToString()
            });
        var roles = Enum.GetValues<Roles>()
            .Select(role => new Role
            {
                Id = (int)role,
                Name = role.ToString()
            });

        modelBuilder.Entity<Permission>()
            .HasData(permissions);
        modelBuilder.Entity<Role>()
            .HasData(roles);
        modelBuilder.Entity<RolePermission>()
            .HasData(
                new RolePermission
                    { RoleId = (int)Common.Roles.Customer, PermissionId = (int)Common.Permissions.CustomerPermission },
                new RolePermission
                    { RoleId = (int)Common.Roles.Admin, PermissionId = (int)Common.Permissions.CustomerPermission },
                new RolePermission
                    { RoleId = (int)Common.Roles.Admin, PermissionId = (int)Common.Permissions.AdminPermission }
            );
        modelBuilder.Entity<Category>()
            .HasData(
                new Category { Id = bookCategoryId, Name = "Books", Slug = "books" },
                new Category { Id = movieCategoryId, Name = "Movies", Slug = "movies" },
                new Category { Id = videoGameCategoryId, Name = "Video Games", Slug = "video-games" }
            );
        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Name = "The Four Winds",
                    Description = "A novel about a woman's journey through the Dust Bowl era of the 1930s",
                    Slug = "the-four-winds",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1594925043i/53138081.jpg",
                    Price = 25.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "The Midnight Library",
                    Description =
                        "A novel about a woman who finds herself in a library between life and death, with the opportunity to try out different versions of her life",
                    Slug = "the-midnight-library",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1602190253i/52578297.jpg",
                    Price = 21.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "Klara and the Sun",
                    Description = "A novel about a robot who observes the world and learns about human behavior",
                    Slug = "klara-and-the-sun",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1603206535i/54120408.jpg",
                    Price = 27.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "Project Hail Mary",
                    Description = "A novel about a man on a solo mission to save the world from extinction",
                    Slug = "project-hail-mary",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1597695864i/54493401.jpg",
                    Price = 24.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "The Sanatorium",
                    Description =
                        "A thriller about a detective investigating a murder at an isolated hotel in the Swiss Alps",
                    Slug = "the-sanatorium",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1612344489i/56935099.jpg",
                    Price = 19.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "The Push",
                    Description =
                        "A novel about a mother's intense desire for perfection and the consequences of her actions",
                    Slug = "the-push",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1609854219i/52476830.jpg",
                    Price = 20.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "The Code Breaker",
                    Description =
                        "A non-fiction book about the woman who helped develop CRISPR gene-editing technology",
                    Slug = "the-code-breaker",
                    ImageUrl = "https://m.media-amazon.com/images/I/41an9tLSfBL._SX327_BO1,204,203,200_.jpg",
                    Price = 28.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "Crying in H Mart",
                    Description =
                        "A memoir about a woman's relationship with her Korean mother and the grieving process after her mother's death",
                    Slug = "crying-in-h-mart",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601937850i/54814676.jpg",
                    Price = 22.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "No One Is Talking About This",
                    Description = "A novel about the intersection of the digital and real worlds",
                    Slug = "no-one-is-talking-about-this",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601474686i/53733106.jpg",
                    Price = 23.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "Empire of Pain",
                    Description = "A non-fiction book about the Sackler family and their role in the opioid crisis",
                    Slug = "empire-of-pain",
                    ImageUrl =
                        "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1611952534i/43868109.jpg",
                    Price = 26.99m,
                    CategoryId = bookCategoryId
                },
                new Product
                {
                    Name = "Nomadland",
                    Description =
                        "A drama film about a woman who embarks on a journey through the American West after the economic collapse of a company town",
                    Slug = "nomadland",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a5/Nomadland_poster.jpeg",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "Minari",
                    Description =
                        "A drama film about a Korean American family who moves to Arkansas in search of the American Dream",
                    Slug = "minari",
                    ImageUrl =
                        "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRO2Ubq5Jw9K26Yf2FIs5Hn4qAmBw9iN5f33KXfOS9-7SrDji-a",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "The Trial of the Chicago 7",
                    Description =
                        "A historical legal drama film about the trial of seven defendants charged with conspiracy and inciting riots at the 1968 Democratic National Convention in Chicago",
                    Slug = "the-trial-of-the-chicago-7",
                    ImageUrl =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpYXw7g_VNc6BgTpeO_teA9iFcaz56RNKE4yke-CfHLulmC4mC",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "Ma Rainey's Black Bottom",
                    Description = "A drama film about a recording session with Ma Rainey and her band in 1920s Chicago",
                    Slug = "ma-raineys-black-bottom",
                    ImageUrl =
                        "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQbwaPsGL1aZVMgWOFxy3vTTEKm-Mdsqr4g5ZH_EOVLTXqVKOEU",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "Promising Young Woman",
                    Description =
                        "A thriller film about a woman seeking revenge against those who wronged her best friend",
                    Slug = "promising-young-woman",
                    ImageUrl =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt0E2TEuop7cpx_XAPCUh0iWdoPBqk4ykJKCpfNGFwlwIf-yTx",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "Sound of Metal",
                    Description = "A drama film about a heavy metal drummer who begins to lose his hearing",
                    Slug = "sound-of-metal",
                    ImageUrl =
                        "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRBan44FQYlb0XJ-54n54uUojA9QxH7s6lhppT9mSsLOGRcSnai",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "The Father",
                    Description = "A drama film about a man with dementia and his daughter's struggles to care for him",
                    Slug = "the-father",
                    ImageUrl =
                        "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRY6PkexuVznH6FEgo0by3HRofrGLE9cK6MoC2SiyZHponQb3oY",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "Soul",
                    Description =
                        "An animated film about a middle school music teacher who dreams of being a jazz musician",
                    Slug = "soul",
                    ImageUrl =
                        "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSWzrHSIZFXCrHAgxd2omcvTVB5jqPkmCVemT0XYPj-CWgRoMs_",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "Da 5 Bloods",
                    Description =
                        "A war drama film about a group of Vietnam War veterans who return to the country in search of treasure and their fallen squad leader's remains",
                    Slug = "da-5-bloods",
                    ImageUrl =
                        "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQ6Y8U3gK1QlfBmjVh_mx9-Ll_YzI3d6K2DQIMQQkUxLuew5K7N",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "Tenet",
                    Description =
                        "A science fiction action film about a secret agent who must prevent World War III through time inversion",
                    Slug = "tenet",
                    ImageUrl =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4o4eBZdZWCR0iNFjiu1p4BKAIwIOkm_tZr3A-WUu4IAAcrq57",
                    Price = 14.99m,
                    CategoryId = movieCategoryId
                },
                new Product
                {
                    Name = "The Legend of Zelda: Breath of the Wild",
                    Description = "An open-world action-adventure game set in a post-apocalyptic Hyrule",
                    Slug = "the-legend-of-zelda-breath-of-the-wild",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg",
                    Price = 59.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Death Stranding",
                    Description =
                        "An action game set in a post-apocalyptic world where the player must deliver supplies and build connections between isolated cities",
                    Slug = "death-stranding",
                    ImageUrl =
                        "https://cdn1.epicgames.com/offer/0a9e3c5ab6684506bd624a849ca0cf39/EGS_DeathStrandingDirectorsCut_KOJIMAPRODUCTIONS_S4_1200x1600-5f99e16507795f9b497716b470cfd876",
                    Price = 49.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "The Last of Us Part II",
                    Description =
                        "A survival horror game set in a post-apocalyptic United States where the player must navigate through dangerous environments and fight off infected creatures and hostile human factions",
                    Slug = "the-last-of-us-part-ii",
                    ImageUrl =
                        "https://image.api.playstation.com/vulcan/img/rnd/202010/2618/w48z6bzefZPrRcJHc7L8SO66.png",
                    Price = 59.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Ghost of Tsushima",
                    Description =
                        "An action-adventure game set in 13th century Japan where the player takes on the role of a samurai warrior fighting against invading Mongol forces",
                    Slug = "ghost-of-tsushima",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg",
                    Price = 49.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Hades",
                    Description =
                        "A roguelike action game where the player takes on the role of Prince Zagreus attempting to escape from the underworld",
                    Slug = "hades",
                    ImageUrl =
                        "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpghttps://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpg",
                    Price = 24.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Animal Crossing: New Horizons",
                    Description =
                        "A life simulation game where the player moves to a deserted island and builds a community with anthropomorphic animals",
                    Slug = "animal-crossing-new-horizons",
                    ImageUrl = "https://animal-crossing.com/new-horizons/assets/img/share-tw.jpg",
                    Price = 59.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Doom Eternal",
                    Description =
                        "A first-person shooter game where the player takes on the role of the Doom Slayer and battles demons from hell",
                    Slug = "doom-eternal",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9d/Cover_Art_of_Doom_Eternal.png",
                    Price = 59.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Fall Guys: Ultimate Knockout",
                    Description =
                        "A battle royale party game where the player competes with up to 60 players in various obstacle courses",
                    Slug = "fall-guys-ultimate-knockout",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/en/thumb/5/5e/Fall_Guys_cover.jpg/220px-Fall_Guys_cover.jpg",
                    Price = 19.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Marvel's Spider-Man: Miles Morales",
                    Description =
                        "An action-adventure game where the player takes on the role of Miles Morales as he becomes the new Spider-Man and fights crime in New York City",
                    Slug = "spider-man-miles-morales",
                    ImageUrl =
                        "https://image.api.playstation.com/vulcan/ap/rnd/202008/1020/T45iRN1bhiWcJUzST6UFGBvO.png",
                    Price = 49.99m,
                    CategoryId = videoGameCategoryId
                },
                new Product
                {
                    Name = "Cyberpunk 2077",
                    Description =
                        "An open-world role-playing game set in a dystopian future where the player takes on the role of a mercenary navigating through the criminal underworld of Night City",
                    Slug = "cyberpunk-2077",
                    ImageUrl =
                        "https://upload.wikimedia.org/wikipedia/en/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg",
                    Price = 59.99m,
                    CategoryId = videoGameCategoryId
                }
            );
    }
}