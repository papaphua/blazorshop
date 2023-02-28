using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUriToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1b2ee365-8f02-45e1-af5d-9e7e50568a61"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("25a3cda6-0c5a-4365-9b41-a9098c398bf9"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("5c0949ca-5fd2-4036-965d-38bf6e441290"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("60c8ffd6-623b-4f5a-9cc1-79149d43655b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6394f772-a0cc-4be1-9358-e78e204c523e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("71d24a73-0b3f-4519-aa45-01378b54b957"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("7ab2072c-802c-4af8-933b-94836c843f2a"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("88e8fec2-9210-41cc-b1da-b8910d8d4e06"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a236269d-e493-4f62-9a25-bf4862611dce"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("eedc3b88-5081-477f-817d-5f2771b77061"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f9312fcc-fd62-4d8b-af03-531fe983ab2c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("5ba89aa6-99ee-41ed-94f4-e51e4b32eb7b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("84ff4288-8d72-4f05-98f4-6ff1f10cb95b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("bbd88938-d25a-4247-8794-8382ed47cd4a"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Product");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("5ba89aa6-99ee-41ed-94f4-e51e4b32eb7b"), "Books", "books" },
                    { new Guid("84ff4288-8d72-4f05-98f4-6ff1f10cb95b"), "Video Games", "video-games" },
                    { new Guid("bbd88938-d25a-4247-8794-8382ed47cd4a"), "Movies", "movies" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("1b2ee365-8f02-45e1-af5d-9e7e50568a61"), new Guid("bbd88938-d25a-4247-8794-8382ed47cd4a"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "Back to the Future", 10.39m, "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg" },
                    { new Guid("25a3cda6-0c5a-4365-9b41-a9098c398bf9"), new Guid("84ff4288-8d72-4f05-98f4-6ff1f10cb95b"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "Xbox", 29.99m, "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg" },
                    { new Guid("5c0949ca-5fd2-4036-965d-38bf6e441290"), new Guid("84ff4288-8d72-4f05-98f4-6ff1f10cb95b"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "Half-Life 2", 3.29m, "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg" },
                    { new Guid("60c8ffd6-623b-4f5a-9cc1-79149d43655b"), new Guid("bbd88938-d25a-4247-8794-8382ed47cd4a"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "Toy Story", 9.39m, "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg" },
                    { new Guid("6394f772-a0cc-4be1-9358-e78e204c523e"), new Guid("84ff4288-8d72-4f05-98f4-6ff1f10cb95b"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "Super Nintendo Entertainment System", 19.99m, "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg" },
                    { new Guid("71d24a73-0b3f-4519-aa45-01378b54b957"), new Guid("5ba89aa6-99ee-41ed-94f4-e51e4b32eb7b"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "The Hitchhiker's Guide to the Galaxy", 9.99m, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg" },
                    { new Guid("7ab2072c-802c-4af8-933b-94836c843f2a"), new Guid("84ff4288-8d72-4f05-98f4-6ff1f10cb95b"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "Diablo II", 4.29m, "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png" },
                    { new Guid("88e8fec2-9210-41cc-b1da-b8910d8d4e06"), new Guid("5ba89aa6-99ee-41ed-94f4-e51e4b32eb7b"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "Ready Player One", 7.99m, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg" },
                    { new Guid("a236269d-e493-4f62-9a25-bf4862611dce"), new Guid("84ff4288-8d72-4f05-98f4-6ff1f10cb95b"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "Day of the Tentacle", 5.55m, "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg" },
                    { new Guid("eedc3b88-5081-477f-817d-5f2771b77061"), new Guid("5ba89aa6-99ee-41ed-94f4-e51e4b32eb7b"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "Nineteen Eighty-Four", 6.99m, "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg" },
                    { new Guid("f9312fcc-fd62-4d8b-af03-531fe983ab2c"), new Guid("bbd88938-d25a-4247-8794-8382ed47cd4a"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "The Matrix", 8.99m, "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg" }
                });
        }
    }
}
