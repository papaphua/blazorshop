using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiramtionToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("07cf8b48-3a58-47cc-b36d-132064466991"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("0c240bef-e904-4124-a3fd-ecbc549ce7e8"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("18951a92-d2d2-4c16-827b-81a82ece4658"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1bd87462-11db-4d9b-87cd-7d70d6944bee"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8b22e587-ab95-40b1-adbf-4944725041f3"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c02c2cae-e7f3-4ccb-af2c-b5ead111755e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ce457978-1ba2-4dd0-b205-bb3d2e514296"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d35cb104-73ab-4150-95dd-888eadc34fae"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e02cda27-44eb-4b8b-855e-408c044bd4b1"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e13653c5-7edc-4677-b864-c67e7249f374"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("fdb26192-6abb-4db2-adb3-78edb945bc2d"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("89b2a912-d230-4b18-b36e-ec97a4394276"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("a13a8c1a-8f09-4515-a68e-8dcd107234f0"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b4afd227-ffac-435d-867a-a57d6bb08e59"));

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationToken",
                table: "Security",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmationTokenExpiry",
                table: "Security",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("0bc89038-2c67-4d60-90a3-fa1d5097d932"), "Books", "books" },
                    { new Guid("223f63f0-67fc-44a4-aace-850c7fea95f9"), "Video Games", "video-games" },
                    { new Guid("e5ca2f1e-6382-4fac-882b-41b61da6805d"), "Movies", "movies" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("22d72124-aced-4739-9318-317edf11587f"), new Guid("e5ca2f1e-6382-4fac-882b-41b61da6805d"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("441dcedc-461c-49a6-9cc9-f48296fa6887"), new Guid("0bc89038-2c67-4d60-90a3-fa1d5097d932"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("583e480d-544d-4a3f-9691-88e43d6c7f29"), new Guid("223f63f0-67fc-44a4-aace-850c7fea95f9"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("686c7a8b-676a-4106-9829-5fb3fb9f356c"), new Guid("0bc89038-2c67-4d60-90a3-fa1d5097d932"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("6d0e8946-b44c-4d65-8b61-ae17b989af92"), new Guid("223f63f0-67fc-44a4-aace-850c7fea95f9"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" },
                    { new Guid("921c8477-2b2b-4c71-ade3-1e46f3e9bea6"), new Guid("e5ca2f1e-6382-4fac-882b-41b61da6805d"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("b6c16ecd-9c07-4397-916e-d8d001bc9099"), new Guid("0bc89038-2c67-4d60-90a3-fa1d5097d932"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" },
                    { new Guid("dd984619-4cc9-473e-8bd7-2125a331c643"), new Guid("223f63f0-67fc-44a4-aace-850c7fea95f9"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" },
                    { new Guid("e6af90ad-4c60-4a5f-8827-022883a7c73e"), new Guid("223f63f0-67fc-44a4-aace-850c7fea95f9"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" },
                    { new Guid("e87f0c26-bb02-4ef5-8100-28c2a64b24b7"), new Guid("223f63f0-67fc-44a4-aace-850c7fea95f9"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" },
                    { new Guid("fcdd54f8-20b8-4a42-9bc3-f2489fc8103b"), new Guid("e5ca2f1e-6382-4fac-882b-41b61da6805d"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("22d72124-aced-4739-9318-317edf11587f"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("441dcedc-461c-49a6-9cc9-f48296fa6887"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("583e480d-544d-4a3f-9691-88e43d6c7f29"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("686c7a8b-676a-4106-9829-5fb3fb9f356c"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6d0e8946-b44c-4d65-8b61-ae17b989af92"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("921c8477-2b2b-4c71-ade3-1e46f3e9bea6"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("b6c16ecd-9c07-4397-916e-d8d001bc9099"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("dd984619-4cc9-473e-8bd7-2125a331c643"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e6af90ad-4c60-4a5f-8827-022883a7c73e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("e87f0c26-bb02-4ef5-8100-28c2a64b24b7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("fcdd54f8-20b8-4a42-9bc3-f2489fc8103b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("0bc89038-2c67-4d60-90a3-fa1d5097d932"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("223f63f0-67fc-44a4-aace-850c7fea95f9"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("e5ca2f1e-6382-4fac-882b-41b61da6805d"));

            migrationBuilder.DropColumn(
                name: "ConfirmationToken",
                table: "Security");

            migrationBuilder.DropColumn(
                name: "ConfirmationTokenExpiry",
                table: "Security");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("89b2a912-d230-4b18-b36e-ec97a4394276"), "Movies", "movies" },
                    { new Guid("a13a8c1a-8f09-4515-a68e-8dcd107234f0"), "Video Games", "video-games" },
                    { new Guid("b4afd227-ffac-435d-867a-a57d6bb08e59"), "Books", "books" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("07cf8b48-3a58-47cc-b36d-132064466991"), new Guid("a13a8c1a-8f09-4515-a68e-8dcd107234f0"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" },
                    { new Guid("0c240bef-e904-4124-a3fd-ecbc549ce7e8"), new Guid("a13a8c1a-8f09-4515-a68e-8dcd107234f0"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" },
                    { new Guid("18951a92-d2d2-4c16-827b-81a82ece4658"), new Guid("b4afd227-ffac-435d-867a-a57d6bb08e59"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("1bd87462-11db-4d9b-87cd-7d70d6944bee"), new Guid("a13a8c1a-8f09-4515-a68e-8dcd107234f0"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("8b22e587-ab95-40b1-adbf-4944725041f3"), new Guid("89b2a912-d230-4b18-b36e-ec97a4394276"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("c02c2cae-e7f3-4ccb-af2c-b5ead111755e"), new Guid("89b2a912-d230-4b18-b36e-ec97a4394276"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("ce457978-1ba2-4dd0-b205-bb3d2e514296"), new Guid("89b2a912-d230-4b18-b36e-ec97a4394276"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" },
                    { new Guid("d35cb104-73ab-4150-95dd-888eadc34fae"), new Guid("b4afd227-ffac-435d-867a-a57d6bb08e59"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("e02cda27-44eb-4b8b-855e-408c044bd4b1"), new Guid("a13a8c1a-8f09-4515-a68e-8dcd107234f0"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" },
                    { new Guid("e13653c5-7edc-4677-b864-c67e7249f374"), new Guid("b4afd227-ffac-435d-867a-a57d6bb08e59"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" },
                    { new Guid("fdb26192-6abb-4db2-adb3-78edb945bc2d"), new Guid("a13a8c1a-8f09-4515-a68e-8dcd107234f0"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" }
                });
        }
    }
}
