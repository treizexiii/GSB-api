using Microsoft.EntityFrameworkCore.Migrations;

namespace GSB.api.Migrations
{
    public partial class adddatas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Etats",
                columns: new[] { "Id", "Libelle" },
                values: new object[,]
                {
                    { "CL", "Sasie Cloturée" },
                    { "CR", "Fiche crée, saisie en cours" },
                    { "RB", "Remboursée" },
                    { "VA", "Valdidée et mise en paiement" }
                });

            migrationBuilder.InsertData(
                table: "Forfaits",
                columns: new[] { "Id", "Libelle", "Montant" },
                values: new object[,]
                {
                    { "ETP", "Forfait Etape", 110.00m },
                    { "KM", "Forfait Kilometrique", 0.62m },
                    { "NUI", "Forfait Hotel", 80.00m },
                    { "REP", "Forfait Restaurant", 25.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Etats",
                keyColumn: "Id",
                keyValue: "CL");

            migrationBuilder.DeleteData(
                table: "Etats",
                keyColumn: "Id",
                keyValue: "CR");

            migrationBuilder.DeleteData(
                table: "Etats",
                keyColumn: "Id",
                keyValue: "RB");

            migrationBuilder.DeleteData(
                table: "Etats",
                keyColumn: "Id",
                keyValue: "VA");

            migrationBuilder.DeleteData(
                table: "Forfaits",
                keyColumn: "Id",
                keyValue: "ETP");

            migrationBuilder.DeleteData(
                table: "Forfaits",
                keyColumn: "Id",
                keyValue: "KM");

            migrationBuilder.DeleteData(
                table: "Forfaits",
                keyColumn: "Id",
                keyValue: "NUI");

            migrationBuilder.DeleteData(
                table: "Forfaits",
                keyColumn: "Id",
                keyValue: "REP");
        }
    }
}
