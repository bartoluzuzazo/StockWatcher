using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj_APBD.Server.Migrations
{
    /// <inheritdoc />
    public partial class StocksInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("6355a865-f7f6-4172-8cd0-8d9f7eeb0aa0"));

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Ticker = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Ticker);
                });

            migrationBuilder.CreateTable(
                name: "StockUser",
                columns: table => new
                {
                    StocksTicker = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockUser", x => new { x.StocksTicker, x.UsersId });
                    table.ForeignKey(
                        name: "FK_StockUser_Stock_StocksTicker",
                        column: x => x.StocksTicker,
                        principalTable: "Stock",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockUser_User_UsersId",
                        column: x => x.UsersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("489e4c7c-004b-4b6c-9488-6b37f5e18c1f"), "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_StockUser_UsersId",
                table: "StockUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockUser");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("489e4c7c-004b-4b6c-9488-6b37f5e18c1f"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("6355a865-f7f6-4172-8cd0-8d9f7eeb0aa0"), "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==", "Admin" });
        }
    }
}
