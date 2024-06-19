using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRELLOBACK.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitreProjet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Listes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitreListe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listes_Projets_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cartes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitreCarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescriptionCarte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatutCarte = table.Column<int>(type: "int", nullable: false),
                    ListeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cartes_Listes_ListeId",
                        column: x => x.ListeId,
                        principalTable: "Listes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cartes_ListeId",
                table: "Cartes",
                column: "ListeId");

            migrationBuilder.CreateIndex(
                name: "IX_Listes_ProjetId",
                table: "Listes",
                column: "ProjetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cartes");

            migrationBuilder.DropTable(
                name: "Listes");

            migrationBuilder.DropTable(
                name: "Projets");
        }
    }
}
