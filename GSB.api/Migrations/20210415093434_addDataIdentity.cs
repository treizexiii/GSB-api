using Microsoft.EntityFrameworkCore.Migrations;

namespace GSB.api.Migrations
{
    public partial class addDataIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "VisiteurId" },
                values: new object[] { "c7a9753a-972a-469f-b663-da19bcba24f7", 0, "0e426e2d-3be3-4156-8c0e-285d918cac5e", null, false, false, null, null, null, "password", null, null, false, "e4a84bbf-5cee-45b7-a767-43534f98081d", false, "rougierjo", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7a9753a-972a-469f-b663-da19bcba24f7");
        }
    }
}
