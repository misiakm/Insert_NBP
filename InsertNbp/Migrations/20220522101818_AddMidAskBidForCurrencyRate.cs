using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsertNbp.Web.Migrations
{
    public partial class AddMidAskBidForCurrencyRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "CurrencyRates",
                newName: "Mid");

            migrationBuilder.AddColumn<float>(
                name: "Ask",
                table: "CurrencyRates",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Bid",
                table: "CurrencyRates",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ask",
                table: "CurrencyRates");

            migrationBuilder.DropColumn(
                name: "Bid",
                table: "CurrencyRates");

            migrationBuilder.RenameColumn(
                name: "Mid",
                table: "CurrencyRates",
                newName: "Rate");
        }
    }
}
