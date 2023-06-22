using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj_APBD.Server.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalStockFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3b3ebc7d-fa9a-4f1a-aea2-0e022aefddeb"));

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedAt",
                table: "User_Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Stock",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Stock",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stock",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sector",
                table: "Stock",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("e27586e8-e74d-46eb-9a9d-0de2206538b4"), "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e27586e8-e74d-46eb-9a9d-0de2206538b4"));

            migrationBuilder.DropColumn(
                name: "AddedAt",
                table: "User_Stock");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Sector",
                table: "Stock");

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("3b3ebc7d-fa9a-4f1a-aea2-0e022aefddeb"), "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==", "Admin" });
        }
    }
}
