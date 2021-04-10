using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlavCrypto.Api.Repositories.Migrations
{
    public partial class AddCryptocurrencyHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptocurrencyHistoryList",
                columns: table => new
                {
                    CryptocurrencyHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CryptocurrencyId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptocurrencyHistoryList", x => x.CryptocurrencyHistoryId);
                    table.ForeignKey(
                        name: "FK_CryptocurrencyHistoryList_CryptocurrencyList_CryptocurrencyId",
                        column: x => x.CryptocurrencyId,
                        principalTable: "CryptocurrencyList",
                        principalColumn: "CryptocurrencyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptocurrencyHistoryList_CryptocurrencyId",
                table: "CryptocurrencyHistoryList",
                column: "CryptocurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptocurrencyHistoryList");
        }
    }
}
