using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNewEmailConfirm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("0a39d95f-f4c5-4840-a389-149d1c007a57"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("10869306-8061-4861-9fc0-0c9d1fa9e2d3"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("151c66af-913a-47ad-be7a-46a2c7ccd027"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("4f37ba31-6652-4968-bec2-1496a25888e1"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("63e2b2cb-6275-4554-bf14-ca8f22c2eeea"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6c8b1a64-961a-4e87-94d0-276fa7255cd6"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("7522d73a-474e-44fb-aac3-95c8b3068c01"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("79aa56bc-89ef-4ac3-a89d-185f0d617bb0"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("83aeb7ef-e7c3-4587-b754-7eae01af5ef7"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8e8718b8-d2f6-4ca1-9523-1ece60f9b2fe"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a1339e14-941b-485a-a35d-39e47d9fdd74"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("3a2b5108-1213-4d9d-927b-34cd0c5d56bf"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("44879ba2-306a-421a-9125-68584b35b734"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("57a7839c-5ed6-4f76-9fe4-ca179b36ee3e"));

            migrationBuilder.AddColumn<string>(
                name: "NewEmailConfirmationCode",
                table: "Security",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("b78349c3-cc9e-45df-b37e-c8c0cd4c6c35"), "Books", "books" },
                    { new Guid("c072fbfe-be6d-4f44-8cb7-21b90b3aeb6f"), "Video Games", "video-games" },
                    { new Guid("d7b96fdc-bbe1-4598-923a-d63b731a2ee8"), "Movies", "movies" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("02ab239c-8ef5-4b1e-8560-f178e60e6a61"), new Guid("d7b96fdc-bbe1-4598-923a-d63b731a2ee8"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("5d6235c1-f86c-426d-9278-68fe6e65f305"), new Guid("b78349c3-cc9e-45df-b37e-c8c0cd4c6c35"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("6d910cdb-2e94-417c-8801-a6b219d59409"), new Guid("c072fbfe-be6d-4f44-8cb7-21b90b3aeb6f"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("8ca410d5-4020-474e-8809-b227fc06ce12"), new Guid("c072fbfe-be6d-4f44-8cb7-21b90b3aeb6f"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" },
                    { new Guid("a27212e4-8022-416a-8934-d495dbb96fbb"), new Guid("d7b96fdc-bbe1-4598-923a-d63b731a2ee8"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("addb6c74-d2b0-45c7-92c5-edce08139914"), new Guid("b78349c3-cc9e-45df-b37e-c8c0cd4c6c35"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("ba41b352-4a0b-408a-854f-455f79ae8b97"), new Guid("c072fbfe-be6d-4f44-8cb7-21b90b3aeb6f"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" },
                    { new Guid("d0c5542c-06f5-4387-9e9b-2bf3187d8b4b"), new Guid("d7b96fdc-bbe1-4598-923a-d63b731a2ee8"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" },
                    { new Guid("d760a369-d883-4d23-af8f-81f3ec135fbc"), new Guid("c072fbfe-be6d-4f44-8cb7-21b90b3aeb6f"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" },
                    { new Guid("faf23ab1-8a10-49c7-9566-f06eb5c16fb6"), new Guid("c072fbfe-be6d-4f44-8cb7-21b90b3aeb6f"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" },
                    { new Guid("ff2bdd8b-15c0-4637-9494-b99893a9520a"), new Guid("b78349c3-cc9e-45df-b37e-c8c0cd4c6c35"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("02ab239c-8ef5-4b1e-8560-f178e60e6a61"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("5d6235c1-f86c-426d-9278-68fe6e65f305"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("6d910cdb-2e94-417c-8801-a6b219d59409"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("8ca410d5-4020-474e-8809-b227fc06ce12"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("a27212e4-8022-416a-8934-d495dbb96fbb"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("addb6c74-d2b0-45c7-92c5-edce08139914"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ba41b352-4a0b-408a-854f-455f79ae8b97"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d0c5542c-06f5-4387-9e9b-2bf3187d8b4b"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("d760a369-d883-4d23-af8f-81f3ec135fbc"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("faf23ab1-8a10-49c7-9566-f06eb5c16fb6"));

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: new Guid("ff2bdd8b-15c0-4637-9494-b99893a9520a"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("b78349c3-cc9e-45df-b37e-c8c0cd4c6c35"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c072fbfe-be6d-4f44-8cb7-21b90b3aeb6f"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("d7b96fdc-bbe1-4598-923a-d63b731a2ee8"));

            migrationBuilder.DropColumn(
                name: "NewEmailConfirmationCode",
                table: "Security");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("3a2b5108-1213-4d9d-927b-34cd0c5d56bf"), "Books", "books" },
                    { new Guid("44879ba2-306a-421a-9125-68584b35b734"), "Movies", "movies" },
                    { new Guid("57a7839c-5ed6-4f76-9fe4-ca179b36ee3e"), "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Uri" },
                values: new object[,]
                {
                    { new Guid("0a39d95f-f4c5-4840-a389-149d1c007a57"), new Guid("57a7839c-5ed6-4f76-9fe4-ca179b36ee3e"), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", "Day of the Tentacle", 5.55m, "day-of-the-tentacle" },
                    { new Guid("10869306-8061-4861-9fc0-0c9d1fa9e2d3"), new Guid("3a2b5108-1213-4d9d-927b-34cd0c5d56bf"), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", "Ready Player One", 7.99m, "ready-player-one" },
                    { new Guid("151c66af-913a-47ad-be7a-46a2c7ccd027"), new Guid("57a7839c-5ed6-4f76-9fe4-ca179b36ee3e"), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", "Diablo II", 4.29m, "diablo-ii" },
                    { new Guid("4f37ba31-6652-4968-bec2-1496a25888e1"), new Guid("57a7839c-5ed6-4f76-9fe4-ca179b36ee3e"), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", "Xbox", 29.99m, "xbox" },
                    { new Guid("63e2b2cb-6275-4554-bf14-ca8f22c2eeea"), new Guid("44879ba2-306a-421a-9125-68584b35b734"), "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.", "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg", "Back to the Future", 10.39m, "back-to-the-future" },
                    { new Guid("6c8b1a64-961a-4e87-94d0-276fa7255cd6"), new Guid("44879ba2-306a-421a-9125-68584b35b734"), "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.", "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg", "Toy Story", 9.39m, "toy-story" },
                    { new Guid("7522d73a-474e-44fb-aac3-95c8b3068c01"), new Guid("3a2b5108-1213-4d9d-927b-34cd0c5d56bf"), "The Hitchhiker's Guide to the Galaxy is a comedy science fiction franchise created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", "The Hitchhiker's Guide to the Galaxy", 9.99m, "the-hitchhiker's-guide-to-the-galaxy" },
                    { new Guid("79aa56bc-89ef-4ac3-a89d-185f0d617bb0"), new Guid("3a2b5108-1213-4d9d-927b-34cd0c5d56bf"), "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by the English writer George Orwell.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/1984first.jpg/330px-1984first.jpg", "Nineteen Eighty-Four", 6.99m, "nineteen-eighty-four" },
                    { new Guid("83aeb7ef-e7c3-4587-b754-7eae01af5ef7"), new Guid("57a7839c-5ed6-4f76-9fe4-ca179b36ee3e"), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", "Super Nintendo Entertainment System", 19.99m, "super-nintendo-entertainment-system" },
                    { new Guid("8e8718b8-d2f6-4ca1-9523-1ece60f9b2fe"), new Guid("44879ba2-306a-421a-9125-68584b35b734"), "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.", "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg", "The Matrix", 8.99m, "the-matrix" },
                    { new Guid("a1339e14-941b-485a-a35d-39e47d9fdd74"), new Guid("57a7839c-5ed6-4f76-9fe4-ca179b36ee3e"), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", "Half-Life 2", 3.29m, "half-life-2" }
                });
        }
    }
}
