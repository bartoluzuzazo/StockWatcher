using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proj_APBD.Server.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("6355a865-f7f6-4172-8cd0-8d9f7eeb0aa0"), "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
