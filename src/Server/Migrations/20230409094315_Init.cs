using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsTfaEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Securities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationCodeExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewEmailConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Securities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Securities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "Video Games", "video-games" },
                    { new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "Movies", "movies" },
                    { new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "Books", "books" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CustomerPermission" },
                    { 2, "AdminPermission" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Customer" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Slug" },
                values: new object[,]
                {
                    { new Guid("08c89497-8ba9-4a34-94b2-64e4122071e5"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "A life simulation game where the player moves to a deserted island and builds a community with anthropomorphic animals", "https://animal-crossing.com/new-horizons/assets/img/share-tw.jpg", "Animal Crossing: New Horizons", 59.99m, "animal-crossing-new-horizons" },
                    { new Guid("0fd90cbc-d9c6-4374-a211-53609d5f8010"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "An open-world role-playing game set in a dystopian future where the player takes on the role of a mercenary navigating through the criminal underworld of Night City", "https://upload.wikimedia.org/wikipedia/en/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg", "Cyberpunk 2077", 59.99m, "cyberpunk-2077" },
                    { new Guid("14d50e9f-4efa-4a0f-b382-f27bf40c1c35"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "An action game set in a post-apocalyptic world where the player must deliver supplies and build connections between isolated cities", "https://cdn1.epicgames.com/offer/0a9e3c5ab6684506bd624a849ca0cf39/EGS_DeathStrandingDirectorsCut_KOJIMAPRODUCTIONS_S4_1200x1600-5f99e16507795f9b497716b470cfd876", "Death Stranding", 49.99m, "death-stranding" },
                    { new Guid("14d5ce23-0430-456d-a2c1-76fff83310db"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A novel about a man on a solo mission to save the world from extinction", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1597695864i/54493401.jpg", "Project Hail Mary", 24.99m, "project-hail-mary" },
                    { new Guid("2565207c-fc12-4f42-955a-de5c4db864b3"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A novel about a woman who finds herself in a library between life and death, with the opportunity to try out different versions of her life", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1602190253i/52578297.jpg", "The Midnight Library", 21.99m, "the-midnight-library" },
                    { new Guid("25d700a4-bd2a-4796-9635-9ba3c4f99638"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A novel about a robot who observes the world and learns about human behavior", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1603206535i/54120408.jpg", "Klara and the Sun", 27.99m, "klara-and-the-sun" },
                    { new Guid("2666a2c1-2913-437d-89d9-27b1bcaf1eee"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A non-fiction book about the Sackler family and their role in the opioid crisis", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1611952534i/43868109.jpg", "Empire of Pain", 26.99m, "empire-of-pain" },
                    { new Guid("31d0b276-db72-407d-b85a-640546209629"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "A roguelike action game where the player takes on the role of Prince Zagreus attempting to escape from the underworld", "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpghttps://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpg", "Hades", 24.99m, "hades" },
                    { new Guid("40f97688-236d-4012-9914-a531f461e24a"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A novel about a woman's journey through the Dust Bowl era of the 1930s", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1594925043i/53138081.jpg", "The Four Winds", 25.99m, "the-four-winds" },
                    { new Guid("54fd0d47-da90-4997-9ccc-bbe032c584aa"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A drama film about a woman who embarks on a journey through the American West after the economic collapse of a company town", "https://upload.wikimedia.org/wikipedia/en/a/a5/Nomadland_poster.jpeg", "Nomadland", 14.99m, "nomadland" },
                    { new Guid("56a8bf13-5700-4d23-8f86-8722dec7fd30"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A war drama film about a group of Vietnam War veterans who return to the country in search of treasure and their fallen squad leader's remains", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQ6Y8U3gK1QlfBmjVh_mx9-Ll_YzI3d6K2DQIMQQkUxLuew5K7N", "Da 5 Bloods", 14.99m, "da-5-bloods" },
                    { new Guid("5815f23b-2633-4fbe-aa47-50df5affef25"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A drama film about a recording session with Ma Rainey and her band in 1920s Chicago", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQbwaPsGL1aZVMgWOFxy3vTTEKm-Mdsqr4g5ZH_EOVLTXqVKOEU", "Ma Rainey's Black Bottom", 14.99m, "ma-raineys-black-bottom" },
                    { new Guid("5ea5e9d2-ccf6-47c9-be49-37d0c132898b"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A drama film about a heavy metal drummer who begins to lose his hearing", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRBan44FQYlb0XJ-54n54uUojA9QxH7s6lhppT9mSsLOGRcSnai", "Sound of Metal", 14.99m, "sound-of-metal" },
                    { new Guid("629eff2c-5d7b-4bbe-882b-6c771c34c2ce"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "A survival horror game set in a post-apocalyptic United States where the player must navigate through dangerous environments and fight off infected creatures and hostile human factions", "https://image.api.playstation.com/vulcan/img/rnd/202010/2618/w48z6bzefZPrRcJHc7L8SO66.png", "The Last of Us Part II", 59.99m, "the-last-of-us-part-ii" },
                    { new Guid("67b9188d-be85-44c6-b5e4-540bf214f9fd"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A historical legal drama film about the trial of seven defendants charged with conspiracy and inciting riots at the 1968 Democratic National Convention in Chicago", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpYXw7g_VNc6BgTpeO_teA9iFcaz56RNKE4yke-CfHLulmC4mC", "The Trial of the Chicago 7", 14.99m, "the-trial-of-the-chicago-7" },
                    { new Guid("6f036b08-19c1-45e5-a5d4-79717698f3ad"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A novel about the intersection of the digital and real worlds", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601474686i/53733106.jpg", "No One Is Talking About This", 23.99m, "no-one-is-talking-about-this" },
                    { new Guid("6f298842-6153-42fb-99a9-83bac1234c35"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A novel about a mother's intense desire for perfection and the consequences of her actions", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1609854219i/52476830.jpg", "The Push", 20.99m, "the-push" },
                    { new Guid("83a3d527-a65b-42ca-8152-14165dd93ae3"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "A first-person shooter game where the player takes on the role of the Doom Slayer and battles demons from hell", "https://upload.wikimedia.org/wikipedia/en/9/9d/Cover_Art_of_Doom_Eternal.png", "Doom Eternal", 59.99m, "doom-eternal" },
                    { new Guid("885a2b5b-bf5e-4aaf-a111-b9115bc32f53"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A thriller about a detective investigating a murder at an isolated hotel in the Swiss Alps", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1612344489i/56935099.jpg", "The Sanatorium", 19.99m, "the-sanatorium" },
                    { new Guid("938de6d4-059f-49ad-b858-5770604dc789"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A drama film about a man with dementia and his daughter's struggles to care for him", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRY6PkexuVznH6FEgo0by3HRofrGLE9cK6MoC2SiyZHponQb3oY", "The Father", 14.99m, "the-father" },
                    { new Guid("a473f956-5c61-4caf-8222-0e06d7a555d3"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "An open-world action-adventure game set in a post-apocalyptic Hyrule", "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg", "The Legend of Zelda: Breath of the Wild", 59.99m, "the-legend-of-zelda-breath-of-the-wild" },
                    { new Guid("add59d50-d5f5-44e6-8e9a-b9cd6baeae6c"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "An animated film about a middle school music teacher who dreams of being a jazz musician", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSWzrHSIZFXCrHAgxd2omcvTVB5jqPkmCVemT0XYPj-CWgRoMs_", "Soul", 14.99m, "soul" },
                    { new Guid("bc32d054-4cfa-452c-8c0e-8302c9954610"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A drama film about a Korean American family who moves to Arkansas in search of the American Dream", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRO2Ubq5Jw9K26Yf2FIs5Hn4qAmBw9iN5f33KXfOS9-7SrDji-a", "Minari", 14.99m, "minari" },
                    { new Guid("c28ba653-0afb-44ce-b33f-5c1373371286"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "A battle royale party game where the player competes with up to 60 players in various obstacle courses", "https://upload.wikimedia.org/wikipedia/en/thumb/5/5e/Fall_Guys_cover.jpg/220px-Fall_Guys_cover.jpg", "Fall Guys: Ultimate Knockout", 19.99m, "fall-guys-ultimate-knockout" },
                    { new Guid("d349df35-bcb5-4d5c-b89d-ab88526cf76c"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "An action-adventure game set in 13th century Japan where the player takes on the role of a samurai warrior fighting against invading Mongol forces", "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg", "Ghost of Tsushima", 49.99m, "ghost-of-tsushima" },
                    { new Guid("daee071e-df7d-4130-9b58-d8814ae8fc16"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A thriller film about a woman seeking revenge against those who wronged her best friend", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt0E2TEuop7cpx_XAPCUh0iWdoPBqk4ykJKCpfNGFwlwIf-yTx", "Promising Young Woman", 14.99m, "promising-young-woman" },
                    { new Guid("e2ae8851-cd29-4073-b41d-4be31488ff8e"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A non-fiction book about the woman who helped develop CRISPR gene-editing technology", "https://m.media-amazon.com/images/I/41an9tLSfBL._SX327_BO1,204,203,200_.jpg", "The Code Breaker", 28.99m, "the-code-breaker" },
                    { new Guid("e88cf2d1-3fdf-4c72-a293-87a829e62d82"), new Guid("4bbd0af1-4218-4f6f-8fc3-f965f4e29e47"), "A science fiction action film about a secret agent who must prevent World War III through time inversion", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4o4eBZdZWCR0iNFjiu1p4BKAIwIOkm_tZr3A-WUu4IAAcrq57", "Tenet", 14.99m, "tenet" },
                    { new Guid("f2d3ec4b-0c96-4b0b-b6e8-8d6158969534"), new Guid("8d5b05c2-61f2-43f1-85c9-fad602cd7dcd"), "A memoir about a woman's relationship with her Korean mother and the grieving process after her mother's death", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601937850i/54814676.jpg", "Crying in H Mart", 22.99m, "crying-in-h-mart" },
                    { new Guid("f6dd5d7a-fd43-4c90-a3d8-97fb6b09f3a4"), new Guid("3fbe47e2-7ae0-481f-a70c-de9b43467935"), "An action-adventure game where the player takes on the role of Miles Morales as he becomes the new Spider-Man and fights crime in New York City", "https://image.api.playstation.com/vulcan/ap/rnd/202008/1020/T45iRN1bhiWcJUzST6UFGBvO.png", "Marvel's Spider-Man: Miles Morales", 49.99m, "spider-man-miles-morales" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Securities_UserId",
                table: "Securities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Securities");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
