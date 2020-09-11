using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Poulina.MSmachine.Data.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filiaire",
                columns: table => new
                {
                    id_filiaire = table.Column<Guid>(nullable: false),
                    label = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiaire", x => x.id_filiaire);
                });

            migrationBuilder.CreateTable(
                name: "Frournisseur",
                columns: table => new
                {
                    id_fournisseur = table.Column<Guid>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    adresse_fournisseur = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frournisseur", x => x.id_fournisseur);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    id_service = table.Column<Guid>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    id_filiaire = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.id_service);
                    table.ForeignKey(
                        name: "FK_Service_Filiaire_id_filiaire",
                        column: x => x.id_filiaire,
                        principalTable: "Filiaire",
                        principalColumn: "id_filiaire",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    id_machine = table.Column<Guid>(nullable: false),
                    label = table.Column<string>(nullable: true),
                    type_machine = table.Column<string>(nullable: true),
                    etat_machine = table.Column<string>(nullable: true),
                    id_fournisseur = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.id_machine);
                    table.ForeignKey(
                        name: "FK_Machine_Frournisseur_id_fournisseur",
                        column: x => x.id_fournisseur,
                        principalTable: "Frournisseur",
                        principalColumn: "id_fournisseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Machine_id_fournisseur",
                table: "Machine",
                column: "id_fournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Service_id_filiaire",
                table: "Service",
                column: "id_filiaire");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Machine");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Frournisseur");

            migrationBuilder.DropTable(
                name: "Filiaire");
        }
    }
}
