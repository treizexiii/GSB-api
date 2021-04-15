using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GSB.api.Migrations
{
    public partial class addcommercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "adresse",
                table: "Visiteurs",
                newName: "Adresse");

            migrationBuilder.AlterColumn<int>(
                name: "CodePostal",
                table: "Visiteurs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSortie",
                table: "Visiteurs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Visiteurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 1, "Comptable" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Libelle" },
                values: new object[] { 2, "Commercial" });

            migrationBuilder.InsertData(
                table: "Visiteurs",
                columns: new[] { "Id", "Adresse", "CodePostal", "DateEmbauche", "DateSortie", "Email", "Login", "Nom", "Password", "Prenom", "RoleId", "Ville" },
                values: new object[] { 1, "6 rue de Viroflay", 75015, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jonathan.rougier@hotmail.fr", "rougierjo", "Rougier", "password", "Jonathan", 2, "Paris" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Visiteurs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DateSortie",
                table: "Visiteurs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Visiteurs");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Visiteurs");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Visiteurs");

            migrationBuilder.RenameColumn(
                name: "Adresse",
                table: "Visiteurs",
                newName: "adresse");

            migrationBuilder.AlterColumn<string>(
                name: "CodePostal",
                table: "Visiteurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
