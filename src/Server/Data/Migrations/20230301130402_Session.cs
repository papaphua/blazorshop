using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Session : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("00c2dfe5-2c9a-4a89-aaf5-d6ac744e83fa"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("1fc62484-9272-47b1-b7f1-13bdc9854a18"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("21174904-68cd-41c4-9943-1798bf548671"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2333fb5c-c7cc-4c04-9afc-eacd99bde087"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3b02152f-6a48-4e8e-976d-2d29c950e7bb"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4fc89da9-a585-48df-b029-16f03d5c75ee"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("82194ff1-7848-4d55-8e3c-1c60fd46386a"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a8be064f-3e26-491c-892b-20f59fcc697d"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("c0a49c1a-84a2-4bd6-a107-fbcdbd3e6e6e"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("cb661e49-9a51-4004-b98d-15bd7925836b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d4722046-57a9-40e5-9ced-c53876c410f1"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("1e95dffa-5016-4937-8080-86a29a3070d7"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("24c7088c-c6ae-461b-9f63-d381491c6b1a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("da9fb591-acfc-404f-a096-2e99c8a202d5"));

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Session_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("3381175f-c163-4bf0-8b12-4f12d1205973"), "Video Games", "video-games" },
                    { new Guid("90a96b62-275b-47b3-9977-a99a44c64fc3"), "Books", "books" },
                    { new Guid("fb28a4d4-e4f1-4d03-b363-5e1468f0b166"), "Movies", "movies" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("2e25d756-5ce9-442e-bf5b-d99cc5cebf11"), new Guid("fb28a4d4-e4f1-4d03-b363-5e1468f0b166"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" },
                    { new Guid("2e40c5ee-1125-4d5e-a26e-acd0e7937403"), new Guid("3381175f-c163-4bf0-8b12-4f12d1205973"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("352a2f01-9436-4f0c-842c-919e51bf737d"), new Guid("3381175f-c163-4bf0-8b12-4f12d1205973"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" },
                    { new Guid("35eb267b-307e-41ac-9d28-63c5d1470c28"), new Guid("90a96b62-275b-47b3-9977-a99a44c64fc3"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("3bf19fe7-4333-4b1a-a43c-1f38a62faba4"), new Guid("fb28a4d4-e4f1-4d03-b363-5e1468f0b166"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("6db06615-9678-4841-bd1e-93029b3b8484"), new Guid("3381175f-c163-4bf0-8b12-4f12d1205973"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" },
                    { new Guid("cf0ce6ce-8d12-4728-9ce6-be771a7ac502"), new Guid("90a96b62-275b-47b3-9977-a99a44c64fc3"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("d2e2055a-43fe-4fb6-9fef-262e99f0ad24"), new Guid("fb28a4d4-e4f1-4d03-b363-5e1468f0b166"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("efd4ee41-8ff9-4f22-b41b-fee41f30dd69"), new Guid("90a96b62-275b-47b3-9977-a99a44c64fc3"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" },
                    { new Guid("f030ce3b-6a7b-48f0-bf93-702a5f2604cc"), new Guid("3381175f-c163-4bf0-8b12-4f12d1205973"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" },
                    { new Guid("f32631f1-60b0-418e-a099-436046cf0d2f"), new Guid("3381175f-c163-4bf0-8b12-4f12d1205973"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Session_UserId",
                table: "Session",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2e25d756-5ce9-442e-bf5b-d99cc5cebf11"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("2e40c5ee-1125-4d5e-a26e-acd0e7937403"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("352a2f01-9436-4f0c-842c-919e51bf737d"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("35eb267b-307e-41ac-9d28-63c5d1470c28"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("3bf19fe7-4333-4b1a-a43c-1f38a62faba4"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6db06615-9678-4841-bd1e-93029b3b8484"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("cf0ce6ce-8d12-4728-9ce6-be771a7ac502"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d2e2055a-43fe-4fb6-9fef-262e99f0ad24"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("efd4ee41-8ff9-4f22-b41b-fee41f30dd69"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f030ce3b-6a7b-48f0-bf93-702a5f2604cc"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("f32631f1-60b0-418e-a099-436046cf0d2f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3381175f-c163-4bf0-8b12-4f12d1205973"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("90a96b62-275b-47b3-9977-a99a44c64fc3"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("fb28a4d4-e4f1-4d03-b363-5e1468f0b166"));

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("1e95dffa-5016-4937-8080-86a29a3070d7"), "Books", "books" },
                    { new Guid("24c7088c-c6ae-461b-9f63-d381491c6b1a"), "Movies", "movies" },
                    { new Guid("da9fb591-acfc-404f-a096-2e99c8a202d5"), "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("00c2dfe5-2c9a-4a89-aaf5-d6ac744e83fa"), new Guid("24c7088c-c6ae-461b-9f63-d381491c6b1a"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("1fc62484-9272-47b1-b7f1-13bdc9854a18"), new Guid("1e95dffa-5016-4937-8080-86a29a3070d7"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("21174904-68cd-41c4-9943-1798bf548671"), new Guid("1e95dffa-5016-4937-8080-86a29a3070d7"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" },
                    { new Guid("2333fb5c-c7cc-4c04-9afc-eacd99bde087"), new Guid("da9fb591-acfc-404f-a096-2e99c8a202d5"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("3b02152f-6a48-4e8e-976d-2d29c950e7bb"), new Guid("1e95dffa-5016-4937-8080-86a29a3070d7"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("4fc89da9-a585-48df-b029-16f03d5c75ee"), new Guid("da9fb591-acfc-404f-a096-2e99c8a202d5"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" },
                    { new Guid("82194ff1-7848-4d55-8e3c-1c60fd46386a"), new Guid("da9fb591-acfc-404f-a096-2e99c8a202d5"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" },
                    { new Guid("a8be064f-3e26-491c-892b-20f59fcc697d"), new Guid("da9fb591-acfc-404f-a096-2e99c8a202d5"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" },
                    { new Guid("c0a49c1a-84a2-4bd6-a107-fbcdbd3e6e6e"), new Guid("24c7088c-c6ae-461b-9f63-d381491c6b1a"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("cb661e49-9a51-4004-b98d-15bd7925836b"), new Guid("24c7088c-c6ae-461b-9f63-d381491c6b1a"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" },
                    { new Guid("d4722046-57a9-40e5-9ced-c53876c410f1"), new Guid("da9fb591-acfc-404f-a096-2e99c8a202d5"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" }
                });
        }
    }
}
