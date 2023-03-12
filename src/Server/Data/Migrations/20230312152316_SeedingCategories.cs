using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorShop.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name", "Uri" },
                values: new object[,]
                {
                    { new Guid("15400e57-5233-4099-967c-5b573242e32c"), "Books", "books" },
                    { new Guid("679d1ff2-4291-4ed0-9da4-8b7461312bb2"), "Movies", "movies" },
                    { new Guid("c4c8de44-d469-42c7-876b-918fc252e500"), "Video Games", "video-games" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("15400e57-5233-4099-967c-5b573242e32c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("679d1ff2-4291-4ed0-9da4-8b7461312bb2"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c4c8de44-d469-42c7-876b-918fc252e500"));
        }
    }
}
