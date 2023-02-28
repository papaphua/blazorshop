using BlazorShop.Server.Data.Entities;
using BlazorShop.Server.Data.Entities.JointEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorShop.Server.Data.EntityConfigurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.HasKey(product => product.Id);

        builder.HasMany(product => product.Comments)
            .WithMany()
            .UsingEntity<ProductComment>();

        builder.HasData(
            new Product
            (
                "The Hitchhiker's Guide to the Galaxy",
                "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.",
                "the-hitchhiker's-guide-to-the-galaxy",
                "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                9.99m,
                CategoryConfiguration.BookCategoryId
            ),
            new Product
            (
                "Ready Player One",
                "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.",
                "ready-player-one",
                "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                7.99m,
                CategoryConfiguration.BookCategoryId
            ),
            new Product
            (
                "Nineteen Eighty-Four",
                "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.",
                "nineteen-eighty-four",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg",
                6.99m,
                CategoryConfiguration.BookCategoryId
            ),
            new Product
            (
                "The Matrix",
                "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                "the-matrix",
                "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                8.99m,
                CategoryConfiguration.MovieCategoryId
            ),
            new Product
            (
                "Back to the Future",
                "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                "back-to-the-future",
                "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                10.39m,
                CategoryConfiguration.MovieCategoryId
            ),
            new Product
            (
                "Toy Story",
                "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                "toy-story",
                "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                9.39m,
                CategoryConfiguration.MovieCategoryId
            ),
            new Product
            (
                "Half-Life 2",
                "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                "half-life-2",
                "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                3.29m,
                CategoryConfiguration.VideoGameCategoryId
            ),
            new Product
            (
                "Diablo II",
                "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                "diablo-ii",
                "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                4.29m,
                CategoryConfiguration.VideoGameCategoryId
            ),
            new Product
            (
                "Day of the Tentacle",
                "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                "day-of-the-tentacle",
                "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                5.55m,
                CategoryConfiguration.VideoGameCategoryId
            ),
            new Product
            (
                "Xbox",
                "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                "xbox",
                "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                29.99m,
                CategoryConfiguration.VideoGameCategoryId
            ),
            new Product
            (
                "Super Nintendo Entertainment System",
                "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                "super-nintendo-entertainment-system",
                "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                19.99m,
                CategoryConfiguration.VideoGameCategoryId
            ));
    }
}