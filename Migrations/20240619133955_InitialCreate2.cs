using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TRELLOBACK.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartes_Listes_ListeId",
                table: "Cartes");

            migrationBuilder.DropForeignKey(
                name: "FK_Listes_Projets_ProjetId",
                table: "Listes");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetId",
                table: "Listes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ListeId",
                table: "Cartes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cartes_Listes_ListeId",
                table: "Cartes",
                column: "ListeId",
                principalTable: "Listes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listes_Projets_ProjetId",
                table: "Listes",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cartes_Listes_ListeId",
                table: "Cartes");

            migrationBuilder.DropForeignKey(
                name: "FK_Listes_Projets_ProjetId",
                table: "Listes");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetId",
                table: "Listes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ListeId",
                table: "Cartes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cartes_Listes_ListeId",
                table: "Cartes",
                column: "ListeId",
                principalTable: "Listes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listes_Projets_ProjetId",
                table: "Listes",
                column: "ProjetId",
                principalTable: "Projets",
                principalColumn: "Id");
        }
    }
}
