using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj_APBD.Server.Migrations
{
    /// <inheritdoc />
    public partial class User_Stock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockUser");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("489e4c7c-004b-4b6c-9488-6b37f5e18c1f"));

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "Stock",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.CreateTable(
                name: "User_Stock",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockTicker = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Stock", x => new { x.UserId, x.StockTicker });
                    table.ForeignKey(
                        name: "FK_User_Stock_Stock_StockTicker",
                        column: x => x.StockTicker,
                        principalTable: "Stock",
                        principalColumn: "Ticker",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Stock_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("3b3ebc7d-fa9a-4f1a-aea2-0e022aefddeb"), "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_User_Stock_StockTicker",
                table: "User_Stock",
                column: "StockTicker");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Stock");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3b3ebc7d-fa9a-4f1a-aea2-0e022aefddeb"));

            migrationBuilder.AlterColumn<string>(
                name: "Ticker",
                table: "Stock",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

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
    }
}
