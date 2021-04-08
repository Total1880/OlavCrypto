using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OlavCrypto.Api.Repositories.Migrations
{
    public partial class AddUpdatePriceDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PriceUpdateDate",
                table: "CryptocurrencyList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceUpdateDate",
                table: "CryptocurrencyList");
        }
    }
}
