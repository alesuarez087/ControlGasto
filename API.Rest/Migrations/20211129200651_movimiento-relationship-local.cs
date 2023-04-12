using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Rest.Migrations
{
    public partial class movimientorelationshiplocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLocal",
                table: "Movimientos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IdLocal",
                table: "Movimientos",
                column: "IdLocal");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Locales_IdLocal",
                table: "Movimientos",
                column: "IdLocal",
                principalTable: "Locales",
                principalColumn: "IdLocal",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Locales_IdLocal",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_IdLocal",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "IdLocal",
                table: "Movimientos");
        }
    }
}
