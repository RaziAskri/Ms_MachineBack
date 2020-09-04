using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.MSmachine.Data.Migrations
{
    public partial class ajout_label_machine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "label",
                table: "Machine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "label",
                table: "Machine");
        }
    }
}
