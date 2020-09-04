using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.MSmachine.Data.Migrations
{
    public partial class ajout_label_machine2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "état_machine",
                table: "Machine");

            migrationBuilder.AddColumn<string>(
                name: "etat_machine",
                table: "Machine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "etat_machine",
                table: "Machine");

            migrationBuilder.AddColumn<string>(
                name: "état_machine",
                table: "Machine",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
