using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSB.api.Migrations
{
    public partial class initiatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Forfaits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Montant = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forfaits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visiteurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adresse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateEmbauche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visiteurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visiteurs_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LigneFrais",
                columns: table => new
                {
                    Mois = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisiteurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LigneFrais", x => x.Mois);
                    table.ForeignKey(
                        name: "FK_LigneFrais_Visiteurs_VisiteurId",
                        column: x => x.VisiteurId,
                        principalTable: "Visiteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FichesFrais",
                columns: table => new
                {
                    Mois = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisiteurId = table.Column<int>(type: "int", nullable: false),
                    LignesFraisMois = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EtatId = table.Column<int>(type: "int", nullable: false),
                    EtatId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ForfaitId = table.Column<int>(type: "int", nullable: false),
                    ForfaitId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Justificatifs = table.Column<int>(type: "int", nullable: false),
                    MontantValide = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateModification = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesFrais", x => new { x.VisiteurId, x.Mois });
                    table.ForeignKey(
                        name: "FK_FichesFrais_Etats_EtatId1",
                        column: x => x.EtatId1,
                        principalTable: "Etats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichesFrais_Forfaits_ForfaitId1",
                        column: x => x.ForfaitId1,
                        principalTable: "Forfaits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichesFrais_LigneFrais_LignesFraisMois",
                        column: x => x.LignesFraisMois,
                        principalTable: "LigneFrais",
                        principalColumn: "Mois",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FichesFrais_Visiteurs_VisiteurId",
                        column: x => x.VisiteurId,
                        principalTable: "Visiteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichesFrais_EtatId1",
                table: "FichesFrais",
                column: "EtatId1");

            migrationBuilder.CreateIndex(
                name: "IX_FichesFrais_ForfaitId1",
                table: "FichesFrais",
                column: "ForfaitId1");

            migrationBuilder.CreateIndex(
                name: "IX_FichesFrais_LignesFraisMois",
                table: "FichesFrais",
                column: "LignesFraisMois");

            migrationBuilder.CreateIndex(
                name: "IX_LigneFrais_VisiteurId",
                table: "LigneFrais",
                column: "VisiteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Visiteurs_RoleId",
                table: "Visiteurs",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichesFrais");

            migrationBuilder.DropTable(
                name: "Etats");

            migrationBuilder.DropTable(
                name: "Forfaits");

            migrationBuilder.DropTable(
                name: "LigneFrais");

            migrationBuilder.DropTable(
                name: "Visiteurs");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
