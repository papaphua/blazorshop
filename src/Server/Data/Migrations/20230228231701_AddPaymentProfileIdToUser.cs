using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentProfileIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("0da11194-c7e6-4d8d-af38-77e65332905b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("324235a8-a3cb-4b3e-9b0e-5d86aea87c26"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3757b322-f914-42be-a9ed-cbf15d874520"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("59286998-9b22-4f0e-a934-7dedf423ba22"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("651f367c-e82e-4ef9-afa7-f75ed390d724"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("695ff4ad-358e-4800-8b17-a335cc69bfcd"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("74d171d9-99a2-4040-8138-ada7abe66558"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("7892fe64-ecb1-4cb1-92b8-c8032c29491b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("87de6bbd-f300-436b-a4e3-639eaa7ae1d4"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("928ff29a-2036-4c5b-8c85-5daa5056d2c5"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ef17f681-732f-49af-86c6-21c8ee51101e"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1d65fe2d-6ee1-427f-b34d-f62c1cc080a2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("2ba4c93a-4a24-4499-8f99-222687ff60ae"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c5fe5148-c98a-417a-a4ce-316527251e53"));

            migrationBuilder.AddColumn<string>(
                name: "PaymentProfileId",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("1d84abbf-5fb1-4055-9f8c-e952ae6d6c12"), "Video Games", "video-games" },
                    { new Guid("20c387d8-1d2f-45e8-904f-c24bedf9f6a0"), "Movies", "movies" },
                    { new Guid("cbb55f75-91b5-4ac3-8ba2-bef16691c243"), "Books", "books" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("0788d25e-96d5-45e2-b031-cc3cd04a6c29"), new Guid("20c387d8-1d2f-45e8-904f-c24bedf9f6a0"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("177505ef-5778-4ea6-87aa-f6a683872c16"), new Guid("cbb55f75-91b5-4ac3-8ba2-bef16691c243"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("1e0e9a12-357b-4b75-9189-8b6558cad950"), new Guid("1d84abbf-5fb1-4055-9f8c-e952ae6d6c12"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" },
                    { new Guid("2a70858c-5d9b-4319-9bfa-102a7f9c371f"), new Guid("1d84abbf-5fb1-4055-9f8c-e952ae6d6c12"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("4d9cbb3e-6335-44a4-8438-576190065c34"), new Guid("cbb55f75-91b5-4ac3-8ba2-bef16691c243"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("59c406f7-154d-43a8-8d73-152d02b31a5f"), new Guid("1d84abbf-5fb1-4055-9f8c-e952ae6d6c12"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" },
                    { new Guid("75bdfafd-b99f-4ec3-8202-3843fb7431c2"), new Guid("20c387d8-1d2f-45e8-904f-c24bedf9f6a0"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" },
                    { new Guid("88da24f9-4602-442d-9021-5b83a9892144"), new Guid("1d84abbf-5fb1-4055-9f8c-e952ae6d6c12"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" },
                    { new Guid("bae8c51d-5da7-4899-b337-1ce4224c04b7"), new Guid("1d84abbf-5fb1-4055-9f8c-e952ae6d6c12"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" },
                    { new Guid("c6ee77a4-0157-4cdc-87e7-8366113c6405"), new Guid("20c387d8-1d2f-45e8-904f-c24bedf9f6a0"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("cd16fdc5-0fd9-4eb9-85ac-9266edffa7d1"), new Guid("cbb55f75-91b5-4ac3-8ba2-bef16691c243"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("0788d25e-96d5-45e2-b031-cc3cd04a6c29"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("177505ef-5778-4ea6-87aa-f6a683872c16"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1e0e9a12-357b-4b75-9189-8b6558cad950"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2a70858c-5d9b-4319-9bfa-102a7f9c371f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4d9cbb3e-6335-44a4-8438-576190065c34"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("59c406f7-154d-43a8-8d73-152d02b31a5f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("75bdfafd-b99f-4ec3-8202-3843fb7431c2"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("88da24f9-4602-442d-9021-5b83a9892144"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("bae8c51d-5da7-4899-b337-1ce4224c04b7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c6ee77a4-0157-4cdc-87e7-8366113c6405"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("cd16fdc5-0fd9-4eb9-85ac-9266edffa7d1"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1d84abbf-5fb1-4055-9f8c-e952ae6d6c12"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("20c387d8-1d2f-45e8-904f-c24bedf9f6a0"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("cbb55f75-91b5-4ac3-8ba2-bef16691c243"));

            migrationBuilder.DropColumn(
                name: "PaymentProfileId",
                table: "User");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("1d65fe2d-6ee1-427f-b34d-f62c1cc080a2"), "Movies", "movies" },
                    { new Guid("2ba4c93a-4a24-4499-8f99-222687ff60ae"), "Books", "books" },
                    { new Guid("c5fe5148-c98a-417a-a4ce-316527251e53"), "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("0da11194-c7e6-4d8d-af38-77e65332905b"), new Guid("c5fe5148-c98a-417a-a4ce-316527251e53"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" },
                    { new Guid("324235a8-a3cb-4b3e-9b0e-5d86aea87c26"), new Guid("2ba4c93a-4a24-4499-8f99-222687ff60ae"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("3757b322-f914-42be-a9ed-cbf15d874520"), new Guid("c5fe5148-c98a-417a-a4ce-316527251e53"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("59286998-9b22-4f0e-a934-7dedf423ba22"), new Guid("1d65fe2d-6ee1-427f-b34d-f62c1cc080a2"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("651f367c-e82e-4ef9-afa7-f75ed390d724"), new Guid("2ba4c93a-4a24-4499-8f99-222687ff60ae"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" },
                    { new Guid("695ff4ad-358e-4800-8b17-a335cc69bfcd"), new Guid("c5fe5148-c98a-417a-a4ce-316527251e53"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" },
                    { new Guid("74d171d9-99a2-4040-8138-ada7abe66558"), new Guid("c5fe5148-c98a-417a-a4ce-316527251e53"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" },
                    { new Guid("7892fe64-ecb1-4cb1-92b8-c8032c29491b"), new Guid("c5fe5148-c98a-417a-a4ce-316527251e53"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" },
                    { new Guid("87de6bbd-f300-436b-a4e3-639eaa7ae1d4"), new Guid("1d65fe2d-6ee1-427f-b34d-f62c1cc080a2"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("928ff29a-2036-4c5b-8c85-5daa5056d2c5"), new Guid("2ba4c93a-4a24-4499-8f99-222687ff60ae"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("ef17f681-732f-49af-86c6-21c8ee51101e"), new Guid("1d65fe2d-6ee1-427f-b34d-f62c1cc080a2"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" }
                });
        }
    }
}
