using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1eca57d5-dfc5-4c00-929c-f5b455755a4b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("201378da-bcad-4de5-a7c4-0fe0a6f0ea38"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("24c1f87f-ba52-460f-84e2-522a01eebc0a"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3ab7bb15-676b-43be-b99d-50843c361e2e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("661ffb9c-0f89-4d6a-941a-4d62644f628c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("9de3940c-4a41-4420-8738-3e667cae8c8a"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("b341a57e-be02-4d36-a2d2-ac8613ca8d8b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c4d46f60-d9b5-4465-9e3f-970d61c922a6"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("de74b89d-5a43-43f5-95cd-a7b52f0b52bc"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e9e3ae26-9c2a-4cd6-92f9-383c86bee331"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("fbe4a6df-f629-4e40-8905-12f5628cc975"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("4a94e4f3-813f-4c65-a932-3da9648446ec"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("717ea110-9e0e-430a-9025-09b245ac56ab"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("896d5690-59ae-428e-b442-d08e771153ad"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("1d6bf658-f7ad-46b3-b89f-013a6befe2ae"), "Movies", "movies" },
                    { new Guid("88f63a98-1e18-4d6a-8119-646fd857c811"), "Books", "books" },
                    { new Guid("8f1fdfd6-c292-4616-b54d-95cdd94df1be"), "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Customer" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("04df0aef-e2f7-47ed-b6cb-b456a2f1ed8c"), new Guid("8f1fdfd6-c292-4616-b54d-95cdd94df1be"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "Day of the Tentacle", 5.55m, "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg" },
                    { new Guid("49ad6e98-c372-4f1d-ba02-ddbc3c50a2b2"), new Guid("1d6bf658-f7ad-46b3-b89f-013a6befe2ae"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "The Matrix", 8.99m, "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg" },
                    { new Guid("59fd64f7-ec7f-438d-b1d4-bbebc20bcca7"), new Guid("1d6bf658-f7ad-46b3-b89f-013a6befe2ae"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "Toy Story", 9.39m, "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg" },
                    { new Guid("c3413f6a-8cb5-45cc-95a3-284e0651a377"), new Guid("88f63a98-1e18-4d6a-8119-646fd857c811"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "The Hitchhiker's Guide to the Galaxy", 9.99m, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg" },
                    { new Guid("c5b5113c-6ef1-4657-9ad8-7c17db352e54"), new Guid("1d6bf658-f7ad-46b3-b89f-013a6befe2ae"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "Back to the Future", 10.39m, "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg" },
                    { new Guid("d2880df4-d96c-4518-baa0-4475caedc7af"), new Guid("88f63a98-1e18-4d6a-8119-646fd857c811"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "Nineteen Eighty-Four", 6.99m, "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg" },
                    { new Guid("dac25194-5b61-414f-abfa-8d2119c2db31"), new Guid("8f1fdfd6-c292-4616-b54d-95cdd94df1be"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "Super Nintendo Entertainment System", 19.99m, "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg" },
                    { new Guid("e029324d-5b78-4407-822c-a08adc71358f"), new Guid("8f1fdfd6-c292-4616-b54d-95cdd94df1be"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "Half-Life 2", 3.29m, "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg" },
                    { new Guid("ec04eda6-1533-4317-8463-f6447dd4ee19"), new Guid("8f1fdfd6-c292-4616-b54d-95cdd94df1be"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "Xbox", 29.99m, "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg" },
                    { new Guid("f083dd7e-93de-458e-a006-729c6051491b"), new Guid("88f63a98-1e18-4d6a-8119-646fd857c811"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "Ready Player One", 7.99m, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg" },
                    { new Guid("f710b6a2-6d4c-4754-b8fc-03992b329fbc"), new Guid("8f1fdfd6-c292-4616-b54d-95cdd94df1be"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "Diablo II", 4.29m, "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("04df0aef-e2f7-47ed-b6cb-b456a2f1ed8c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("49ad6e98-c372-4f1d-ba02-ddbc3c50a2b2"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("59fd64f7-ec7f-438d-b1d4-bbebc20bcca7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c3413f6a-8cb5-45cc-95a3-284e0651a377"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c5b5113c-6ef1-4657-9ad8-7c17db352e54"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d2880df4-d96c-4518-baa0-4475caedc7af"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("dac25194-5b61-414f-abfa-8d2119c2db31"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e029324d-5b78-4407-822c-a08adc71358f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ec04eda6-1533-4317-8463-f6447dd4ee19"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f083dd7e-93de-458e-a006-729c6051491b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f710b6a2-6d4c-4754-b8fc-03992b329fbc"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1d6bf658-f7ad-46b3-b89f-013a6befe2ae"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("88f63a98-1e18-4d6a-8119-646fd857c811"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("8f1fdfd6-c292-4616-b54d-95cdd94df1be"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("4a94e4f3-813f-4c65-a932-3da9648446ec"), "Books", "books" },
                    { new Guid("717ea110-9e0e-430a-9025-09b245ac56ab"), "Movies", "movies" },
                    { new Guid("896d5690-59ae-428e-b442-d08e771153ad"), "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("1eca57d5-dfc5-4c00-929c-f5b455755a4b"), new Guid("4a94e4f3-813f-4c65-a932-3da9648446ec"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "Ready Player One", 7.99m, "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg" },
                    { new Guid("201378da-bcad-4de5-a7c4-0fe0a6f0ea38"), new Guid("896d5690-59ae-428e-b442-d08e771153ad"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "Day of the Tentacle", 5.55m, "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg" },
                    { new Guid("24c1f87f-ba52-460f-84e2-522a01eebc0a"), new Guid("896d5690-59ae-428e-b442-d08e771153ad"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "Half-Life 2", 3.29m, "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg" },
                    { new Guid("3ab7bb15-676b-43be-b99d-50843c361e2e"), new Guid("896d5690-59ae-428e-b442-d08e771153ad"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "Super Nintendo Entertainment System", 19.99m, "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg" },
                    { new Guid("661ffb9c-0f89-4d6a-941a-4d62644f628c"), new Guid("4a94e4f3-813f-4c65-a932-3da9648446ec"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "Nineteen Eighty-Four", 6.99m, "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg" },
                    { new Guid("9de3940c-4a41-4420-8738-3e667cae8c8a"), new Guid("717ea110-9e0e-430a-9025-09b245ac56ab"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "The Matrix", 8.99m, "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg" },
                    { new Guid("b341a57e-be02-4d36-a2d2-ac8613ca8d8b"), new Guid("717ea110-9e0e-430a-9025-09b245ac56ab"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "Toy Story", 9.39m, "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg" },
                    { new Guid("c4d46f60-d9b5-4465-9e3f-970d61c922a6"), new Guid("717ea110-9e0e-430a-9025-09b245ac56ab"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "Back to the Future", 10.39m, "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg" },
                    { new Guid("de74b89d-5a43-43f5-95cd-a7b52f0b52bc"), new Guid("896d5690-59ae-428e-b442-d08e771153ad"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "Diablo II", 4.29m, "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png" },
                    { new Guid("e9e3ae26-9c2a-4cd6-92f9-383c86bee331"), new Guid("896d5690-59ae-428e-b442-d08e771153ad"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "Xbox", 29.99m, "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg" },
                    { new Guid("fbe4a6df-f629-4e40-8905-12f5628cc975"), new Guid("4a94e4f3-813f-4c65-a932-3da9648446ec"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "The Hitchhiker's Guide to the Galaxy", 9.99m, "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg" }
                });
        }
    }
}
