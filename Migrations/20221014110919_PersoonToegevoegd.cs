using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Opdracht_week_6.Migrations
{
    public partial class PersoonToegevoegd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AantalLikes",
                table: "Attractie",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GastId",
                table: "Attractie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Geslacht",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attractie_GastId",
                table: "Attractie",
                column: "GastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractie_AspNetUsers_GastId",
                table: "Attractie",
                column: "GastId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractie_AspNetUsers_GastId",
                table: "Attractie");

            migrationBuilder.DropIndex(
                name: "IX_Attractie_GastId",
                table: "Attractie");

            migrationBuilder.DropColumn(
                name: "AantalLikes",
                table: "Attractie");

            migrationBuilder.DropColumn(
                name: "GastId",
                table: "Attractie");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Geslacht",
                table: "AspNetUsers");
        }
    }
}
