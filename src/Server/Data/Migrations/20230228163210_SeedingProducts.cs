using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("280ef940-c13d-4b9d-9df8-57b853be7e01"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4f73b1ef-2287-4ef6-bb5a-12992b9a89f5"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e37b0c9e-8610-41b9-97d6-ff3e52dd3af7"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("07196150-3c49-4601-a1cf-a2383751edb2"), "Video Games", "video-games" },
                    { new Guid("341daa76-1d51-41eb-8943-d58c76424d13"), "Movies", "movies" },
                    { new Guid("de0c1a5c-a187-4d5d-8d25-0d58d7faceb5"), "Books", "books" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("192ca4ec-44d6-4932-8140-370103c20f2d"), new Guid("341daa76-1d51-41eb-8943-d58c76424d13"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "Back to the Future", 10.39m, "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg" },
                    { new Guid("2859e471-bde4-49fc-9154-c8512ea5f8d7"), new Guid("07196150-3c49-4601-a1cf-a2383751edb2"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "Xbox", 29.99m, "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg" },
                    { new Guid("7e85cb08-43e7-473d-83a7-6f0ba8972909"), new Guid("07196150-3c49-4601-a1cf-a2383751edb2"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "Diablo II", 4.29m, "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png" },
                    { new Guid("990ae898-19b5-4087-9720-187bdce3b995"), new Guid("07196150-3c49-4601-a1cf-a2383751edb2"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "Super Nintendo Entertainment System", 19.99m, "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg" },
                    { new Guid("c0c52195-16a2-445d-b6eb-89a06f0651d7"), new Guid("341daa76-1d51-41eb-8943-d58c76424d13"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "The Matrix", 8.99m, "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg" },
                    { new Guid("c75dcb9d-e52c-42dd-80dd-0743f77311eb"), new Guid("07196150-3c49-4601-a1cf-a2383751edb2"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "Day of the Tentacle", 5.55m, "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg" },
                    { new Guid("ca9d5501-6ab1-454b-8671-ab8f0afe271c"), new Guid("de0c1a5c-a187-4d5d-8d25-0d58d7faceb5"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "Ready Player One", 7.99m, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg" },
                    { new Guid("e129cd08-a03e-4c84-92bd-4fd0dab5bde9"), new Guid("341daa76-1d51-41eb-8943-d58c76424d13"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "Toy Story", 9.39m, "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg" },
                    { new Guid("e1b77e29-5880-40e8-8a04-3753c36f4223"), new Guid("de0c1a5c-a187-4d5d-8d25-0d58d7faceb5"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "The Hitchhiker's Guide to the Galaxy", 9.99m, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg" },
                    { new Guid("ea9ae4cd-8bad-4a0a-9751-7f8a7830f59e"), new Guid("de0c1a5c-a187-4d5d-8d25-0d58d7faceb5"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "Nineteen Eighty-Four", 6.99m, "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg" },
                    { new Guid("f4b2119b-8b5c-4c6e-9e0e-0fd5ba865534"), new Guid("07196150-3c49-4601-a1cf-a2383751edb2"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "Half-Life 2", 3.29m, "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("192ca4ec-44d6-4932-8140-370103c20f2d"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2859e471-bde4-49fc-9154-c8512ea5f8d7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("7e85cb08-43e7-473d-83a7-6f0ba8972909"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("990ae898-19b5-4087-9720-187bdce3b995"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c0c52195-16a2-445d-b6eb-89a06f0651d7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c75dcb9d-e52c-42dd-80dd-0743f77311eb"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ca9d5501-6ab1-454b-8671-ab8f0afe271c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e129cd08-a03e-4c84-92bd-4fd0dab5bde9"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e1b77e29-5880-40e8-8a04-3753c36f4223"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ea9ae4cd-8bad-4a0a-9751-7f8a7830f59e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f4b2119b-8b5c-4c6e-9e0e-0fd5ba865534"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("07196150-3c49-4601-a1cf-a2383751edb2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("341daa76-1d51-41eb-8943-d58c76424d13"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("de0c1a5c-a187-4d5d-8d25-0d58d7faceb5"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("280ef940-c13d-4b9d-9df8-57b853be7e01"), "Books", "books" },
                    { new Guid("4f73b1ef-2287-4ef6-bb5a-12992b9a89f5"), "Movies", "movies" },
                    { new Guid("e37b0c9e-8610-41b9-97d6-ff3e52dd3af7"), "Video Games", "video-games" }
                });
        }
    }
}
