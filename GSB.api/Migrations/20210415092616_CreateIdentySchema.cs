using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSB.api.Migrations
{
    public partial class CreateIdentySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichesFrais_Etats_EtatId1",
                table: "FichesFrais");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesFrais_Forfaits_ForfaitId1",
                table: "FichesFrais");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesFrais_LigneFrais_LignesFraisMois",
                table: "FichesFrais");

            migrationBuilder.DropForeignKey(
                name: "FK_LigneFrais_Visiteurs_VisiteurId",
                table: "LigneFrais");

            migrationBuilder.DropIndex(
                name: "IX_FichesFrais_EtatId1",
                table: "FichesFrais");

            migrationBuilder.DropIndex(
                name: "IX_FichesFrais_ForfaitId1",
                table: "FichesFrais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LigneFrais",
                table: "LigneFrais");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Visiteurs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Visiteurs");

            migrationBuilder.DropColumn(
                name: "EtatId1",
                table: "FichesFrais");

            migrationBuilder.DropColumn(
                name: "ForfaitId1",
                table: "FichesFrais");

            migrationBuilder.RenameTable(
                name: "LigneFrais",
                newName: "LignesFrais");

            migrationBuilder.RenameIndex(
                name: "IX_LigneFrais_VisiteurId",
                table: "LignesFrais",
                newName: "IX_LignesFrais_VisiteurId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Visiteurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ForfaitId",
                table: "FichesFrais",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EtatId",
                table: "FichesFrais",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LignesFrais",
                table: "LignesFrais",
                column: "Mois");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisiteurId = table.Column<int>(type: "int", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Visiteurs_VisiteurId",
                        column: x => x.VisiteurId,
                        principalTable: "Visiteurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichesFrais_EtatId",
                table: "FichesFrais",
                column: "EtatId");

            migrationBuilder.CreateIndex(
                name: "IX_FichesFrais_ForfaitId",
                table: "FichesFrais",
                column: "ForfaitId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VisiteurId",
                table: "AspNetUsers",
                column: "VisiteurId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_FichesFrais_Etats_EtatId",
                table: "FichesFrais",
                column: "EtatId",
                principalTable: "Etats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesFrais_Forfaits_ForfaitId",
                table: "FichesFrais",
                column: "ForfaitId",
                principalTable: "Forfaits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesFrais_LignesFrais_LignesFraisMois",
                table: "FichesFrais",
                column: "LignesFraisMois",
                principalTable: "LignesFrais",
                principalColumn: "Mois",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesFrais_Visiteurs_VisiteurId",
                table: "LignesFrais",
                column: "VisiteurId",
                principalTable: "Visiteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichesFrais_Etats_EtatId",
                table: "FichesFrais");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesFrais_Forfaits_ForfaitId",
                table: "FichesFrais");

            migrationBuilder.DropForeignKey(
                name: "FK_FichesFrais_LignesFrais_LignesFraisMois",
                table: "FichesFrais");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesFrais_Visiteurs_VisiteurId",
                table: "LignesFrais");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_FichesFrais_EtatId",
                table: "FichesFrais");

            migrationBuilder.DropIndex(
                name: "IX_FichesFrais_ForfaitId",
                table: "FichesFrais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LignesFrais",
                table: "LignesFrais");

            migrationBuilder.RenameTable(
                name: "LignesFrais",
                newName: "LigneFrais");

            migrationBuilder.RenameIndex(
                name: "IX_LignesFrais_VisiteurId",
                table: "LigneFrais",
                newName: "IX_LigneFrais_VisiteurId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Visiteurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Visiteurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Visiteurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ForfaitId",
                table: "FichesFrais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EtatId",
                table: "FichesFrais",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EtatId1",
                table: "FichesFrais",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForfaitId1",
                table: "FichesFrais",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LigneFrais",
                table: "LigneFrais",
                column: "Mois");

            migrationBuilder.UpdateData(
                table: "Visiteurs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Password" },
                values: new object[] { "rougierjo", "password" });

            migrationBuilder.CreateIndex(
                name: "IX_FichesFrais_EtatId1",
                table: "FichesFrais",
                column: "EtatId1");

            migrationBuilder.CreateIndex(
                name: "IX_FichesFrais_ForfaitId1",
                table: "FichesFrais",
                column: "ForfaitId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FichesFrais_Etats_EtatId1",
                table: "FichesFrais",
                column: "EtatId1",
                principalTable: "Etats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesFrais_Forfaits_ForfaitId1",
                table: "FichesFrais",
                column: "ForfaitId1",
                principalTable: "Forfaits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FichesFrais_LigneFrais_LignesFraisMois",
                table: "FichesFrais",
                column: "LignesFraisMois",
                principalTable: "LigneFrais",
                principalColumn: "Mois",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneFrais_Visiteurs_VisiteurId",
                table: "LigneFrais",
                column: "VisiteurId",
                principalTable: "Visiteurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
