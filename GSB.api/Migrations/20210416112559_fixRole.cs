using Microsoft.EntityFrameworkCore.Migrations;

namespace GSB.api.Migrations
{
    public partial class fixRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visiteurs_Roles_RoleId",
                table: "Visiteurs");

            migrationBuilder.DropIndex(
                name: "IX_Visiteurs_RoleId",
                table: "Visiteurs");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Visiteurs");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Roles_RoleId",
                table: "AspNetUsers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Roles_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RoleId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Visiteurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Visiteurs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Visiteurs_RoleId",
                table: "Visiteurs",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visiteurs_Roles_RoleId",
                table: "Visiteurs",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
