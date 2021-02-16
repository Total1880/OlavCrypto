using Microsoft.EntityFrameworkCore.Migrations;

namespace OlavCrypto.Api.Repositories.Migrations
{
    public partial class FirstSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CryptocurrencyList",
                columns: table => new
                {
                    CryptocurrencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptocurrencyList", x => x.CryptocurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "WalletList",
                columns: table => new
                {
                    WalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletList", x => x.WalletId);
                });

            migrationBuilder.CreateTable(
                name: "CryptocurrencyWalletList",
                columns: table => new
                {
                    CryptocurrencyWalletId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalletId = table.Column<int>(type: "int", nullable: true),
                    CryptocurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptocurrencyWalletList", x => x.CryptocurrencyWalletId);
                    table.ForeignKey(
                        name: "FK_CryptocurrencyWalletList_CryptocurrencyList_CryptocurrencyId",
                        column: x => x.CryptocurrencyId,
                        principalTable: "CryptocurrencyList",
                        principalColumn: "CryptocurrencyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CryptocurrencyWalletList_WalletList_WalletId",
                        column: x => x.WalletId,
                        principalTable: "WalletList",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CryptocurrencyDetailsList",
                columns: table => new
                {
                    CryptocurrencyDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CryptocurrencyWalletId = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptocurrencyDetailsList", x => x.CryptocurrencyDetailsId);
                    table.ForeignKey(
                        name: "FK_CryptocurrencyDetailsList_CryptocurrencyWalletList_CryptocurrencyWalletId",
                        column: x => x.CryptocurrencyWalletId,
                        principalTable: "CryptocurrencyWalletList",
                        principalColumn: "CryptocurrencyWalletId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptocurrencyDetailsList_CryptocurrencyWalletId",
                table: "CryptocurrencyDetailsList",
                column: "CryptocurrencyWalletId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptocurrencyWalletList_CryptocurrencyId",
                table: "CryptocurrencyWalletList",
                column: "CryptocurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CryptocurrencyWalletList_WalletId",
                table: "CryptocurrencyWalletList",
                column: "WalletId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CryptocurrencyDetailsList");

            migrationBuilder.DropTable(
                name: "CryptocurrencyWalletList");

            migrationBuilder.DropTable(
                name: "CryptocurrencyList");

            migrationBuilder.DropTable(
                name: "WalletList");
        }
    }
}
