using Microsoft.EntityFrameworkCore.Migrations;

namespace OlavCrypto.Api.Repositories.Migrations
{
    public partial class addPriceAndBalanceInUSD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "CryptocurrencyList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BalanceInUSD",
                table: "CryptocurrencyDetailsList",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "CryptocurrencyList");

            migrationBuilder.DropColumn(
                name: "BalanceInUSD",
                table: "CryptocurrencyDetailsList");
        }
    }
}
