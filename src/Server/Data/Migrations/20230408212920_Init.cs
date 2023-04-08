using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
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
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
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
                    { new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "Movies", "movies" },
                    { new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "Books", "books" },
                    { new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "Video Games", "video-games" }
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
                    { new Guid("08fc14a9-df0c-4bb6-85d8-09a55fda8284"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A novel about a mother's intense desire for perfection and the consequences of her actions", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1609854219i/52476830.jpg", "The Push", 20.99m, "the-push" },
                    { new Guid("0af6ec9d-9426-472a-9d8b-a5c44ce072a3"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "A roguelike action game where the player takes on the role of Prince Zagreus attempting to escape from the underworld", "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpghttps://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpg", "Hades", 24.99m, "hades" },
                    { new Guid("0f088068-6ad6-4d59-bd7c-53b9bf02242b"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A drama film about a Korean American family who moves to Arkansas in search of the American Dream", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRO2Ubq5Jw9K26Yf2FIs5Hn4qAmBw9iN5f33KXfOS9-7SrDji-a", "Minari", 14.99m, "minari" },
                    { new Guid("12a6481e-22d5-4bbf-aa48-3bf14a8abc3a"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A non-fiction book about the woman who helped develop CRISPR gene-editing technology", "https://m.media-amazon.com/images/I/41an9tLSfBL._SX327_BO1,204,203,200_.jpg", "The Code Breaker", 28.99m, "the-code-breaker" },
                    { new Guid("1ec8e313-0612-4809-8753-16ab79ba5afa"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "An open-world role-playing game set in a dystopian future where the player takes on the role of a mercenary navigating through the criminal underworld of Night City", "https://upload.wikimedia.org/wikipedia/en/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg", "Cyberpunk 2077", 59.99m, "cyberpunk-2077" },
                    { new Guid("2157c735-30ff-4b97-8472-024d07e44306"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "An open-world action-adventure game set in a post-apocalyptic Hyrule", "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg", "The Legend of Zelda: Breath of the Wild", 59.99m, "the-legend-of-zelda-breath-of-the-wild" },
                    { new Guid("3d7bfbb1-51ef-4715-b901-04479f2b7764"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "A survival horror game set in a post-apocalyptic United States where the player must navigate through dangerous environments and fight off infected creatures and hostile human factions", "https://image.api.playstation.com/vulcan/img/rnd/202010/2618/w48z6bzefZPrRcJHc7L8SO66.png", "The Last of Us Part II", 59.99m, "the-last-of-us-part-ii" },
                    { new Guid("3e30c1b8-61b5-48d9-82a5-a67bbe187c7a"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A drama film about a recording session with Ma Rainey and her band in 1920s Chicago", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQbwaPsGL1aZVMgWOFxy3vTTEKm-Mdsqr4g5ZH_EOVLTXqVKOEU", "Ma Rainey's Black Bottom", 14.99m, "ma-raineys-black-bottom" },
                    { new Guid("47203461-7f10-44b6-96b1-830da85aa5f6"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A thriller about a detective investigating a murder at an isolated hotel in the Swiss Alps", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1612344489i/56935099.jpg", "The Sanatorium", 19.99m, "the-sanatorium" },
                    { new Guid("4b75fc46-38ac-4c6b-879b-2c43a44a6853"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A novel about the intersection of the digital and real worlds", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601474686i/53733106.jpg", "No One Is Talking About This", 23.99m, "no-one-is-talking-about-this" },
                    { new Guid("547ed959-f428-4f0e-b744-e86fd4ac5cac"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "An action game set in a post-apocalyptic world where the player must deliver supplies and build connections between isolated cities", "https://cdn1.epicgames.com/offer/0a9e3c5ab6684506bd624a849ca0cf39/EGS_DeathStrandingDirectorsCut_KOJIMAPRODUCTIONS_S4_1200x1600-5f99e16507795f9b497716b470cfd876", "Death Stranding", 49.99m, "death-stranding" },
                    { new Guid("608aa221-6a68-4197-8e32-ef53a2bc6bbb"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A memoir about a woman's relationship with her Korean mother and the grieving process after her mother's death", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601937850i/54814676.jpg", "Crying in H Mart", 22.99m, "crying-in-h-mart" },
                    { new Guid("628c9f16-e7ca-47be-b790-b90c7d5b0d71"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "An action-adventure game where the player takes on the role of Miles Morales as he becomes the new Spider-Man and fights crime in New York City", "https://image.api.playstation.com/vulcan/ap/rnd/202008/1020/T45iRN1bhiWcJUzST6UFGBvO.png", "Marvel's Spider-Man: Miles Morales", 49.99m, "spider-man-miles-morales" },
                    { new Guid("7314eeda-f664-46b3-9620-ee6d6340d40d"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "An animated film about a middle school music teacher who dreams of being a jazz musician", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSWzrHSIZFXCrHAgxd2omcvTVB5jqPkmCVemT0XYPj-CWgRoMs_", "Soul", 14.99m, "soul" },
                    { new Guid("74a6134c-dea6-4c3c-8312-a11bbc9f36d1"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "A life simulation game where the player moves to a deserted island and builds a community with anthropomorphic animals", "https://animal-crossing.com/new-horizons/assets/img/share-tw.jpg", "Animal Crossing: New Horizons", 59.99m, "animal-crossing-new-horizons" },
                    { new Guid("7592b529-1d68-4eba-81b3-3935b0b656cf"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "An action-adventure game set in 13th century Japan where the player takes on the role of a samurai warrior fighting against invading Mongol forces", "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg", "Ghost of Tsushima", 49.99m, "ghost-of-tsushima" },
                    { new Guid("7cd04ec5-a9ef-4cc1-bcda-74145b5828cb"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A drama film about a heavy metal drummer who begins to lose his hearing", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRBan44FQYlb0XJ-54n54uUojA9QxH7s6lhppT9mSsLOGRcSnai", "Sound of Metal", 14.99m, "sound-of-metal" },
                    { new Guid("83436c27-2f26-486b-8996-587f524a0ebf"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A drama film about a woman who embarks on a journey through the American West after the economic collapse of a company town", "https://upload.wikimedia.org/wikipedia/en/a/a5/Nomadland_poster.jpeg", "Nomadland", 14.99m, "nomadland" },
                    { new Guid("89de1450-e9b2-4caf-ad05-ac8a6f1c120c"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A non-fiction book about the Sackler family and their role in the opioid crisis", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1611952534i/43868109.jpg", "Empire of Pain", 26.99m, "empire-of-pain" },
                    { new Guid("ae240b03-c0fa-4f3a-9ba0-47fa5bffa3d2"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A novel about a robot who observes the world and learns about human behavior", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1603206535i/54120408.jpg", "Klara and the Sun", 27.99m, "klara-and-the-sun" },
                    { new Guid("b44f2367-578e-4e21-bfe0-ed310bc18722"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A war drama film about a group of Vietnam War veterans who return to the country in search of treasure and their fallen squad leader's remains", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQ6Y8U3gK1QlfBmjVh_mx9-Ll_YzI3d6K2DQIMQQkUxLuew5K7N", "Da 5 Bloods", 14.99m, "da-5-bloods" },
                    { new Guid("b72a33a1-1ea3-4c8a-9fd3-468ba5f69015"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A drama film about a man with dementia and his daughter's struggles to care for him", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRY6PkexuVznH6FEgo0by3HRofrGLE9cK6MoC2SiyZHponQb3oY", "The Father", 14.99m, "the-father" },
                    { new Guid("bf1bd910-e2cf-463b-b03b-a11fed145943"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A thriller film about a woman seeking revenge against those who wronged her best friend", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt0E2TEuop7cpx_XAPCUh0iWdoPBqk4ykJKCpfNGFwlwIf-yTx", "Promising Young Woman", 14.99m, "promising-young-woman" },
                    { new Guid("c0b9f4c3-e04f-446e-af08-bcd24aeae30f"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A novel about a woman who finds herself in a library between life and death, with the opportunity to try out different versions of her life", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1602190253i/52578297.jpg", "The Midnight Library", 21.99m, "the-midnight-library" },
                    { new Guid("c12bac57-0714-4599-837c-dc3a9d02ce66"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A science fiction action film about a secret agent who must prevent World War III through time inversion", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4o4eBZdZWCR0iNFjiu1p4BKAIwIOkm_tZr3A-WUu4IAAcrq57", "Tenet", 14.99m, "tenet" },
                    { new Guid("c1f325cf-b109-458b-8072-16ffee255759"), new Guid("174eb448-e412-4114-bfe2-0ff3b1a12291"), "A historical legal drama film about the trial of seven defendants charged with conspiracy and inciting riots at the 1968 Democratic National Convention in Chicago", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpYXw7g_VNc6BgTpeO_teA9iFcaz56RNKE4yke-CfHLulmC4mC", "The Trial of the Chicago 7", 14.99m, "the-trial-of-the-chicago-7" },
                    { new Guid("c9e9d889-a43f-4ae0-997c-ef653896306b"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A novel about a man on a solo mission to save the world from extinction", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1597695864i/54493401.jpg", "Project Hail Mary", 24.99m, "project-hail-mary" },
                    { new Guid("cfed4c40-a909-433f-ace3-adde857c1a86"), new Guid("73fc413d-9817-4428-9f34-4c5f80f4f3dd"), "A novel about a woman's journey through the Dust Bowl era of the 1930s", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1594925043i/53138081.jpg", "The Four Winds", 25.99m, "the-four-winds" },
                    { new Guid("e4ae1d55-3bc5-4d69-90b2-cbf08b214b0d"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "A first-person shooter game where the player takes on the role of the Doom Slayer and battles demons from hell", "https://upload.wikimedia.org/wikipedia/en/9/9d/Cover_Art_of_Doom_Eternal.png", "Doom Eternal", 59.99m, "doom-eternal" },
                    { new Guid("ebcad60a-f4a8-4eab-aad0-d803b1322756"), new Guid("defb6999-12cc-49df-bdae-1761fb589507"), "A battle royale party game where the player competes with up to 60 players in various obstacle courses", "https://upload.wikimedia.org/wikipedia/en/thumb/5/5e/Fall_Guys_cover.jpg/220px-Fall_Guys_cover.jpg", "Fall Guys: Ultimate Knockout", 19.99m, "fall-guys-ultimate-knockout" }
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
