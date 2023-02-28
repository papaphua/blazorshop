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
                    { new Guid("280ef940-c13d-4b9d-9df8-57b853be7e01"), "Books", "books" },
                    { new Guid("4f73b1ef-2287-4ef6-bb5a-12992b9a89f5"), "Movies", "movies" },
                    { new Guid("e37b0c9e-8610-41b9-97d6-ff3e52dd3af7"), "Video Games", "video-games" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
