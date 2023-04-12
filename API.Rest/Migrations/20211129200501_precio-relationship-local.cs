using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Rest.Migrations
{
    public partial class preciorelationshiplocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLocal",
                table: "PreciosProducto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreciosProducto_IdLocal",
                table: "PreciosProducto",
                column: "IdLocal");

            migrationBuilder.AddForeignKey(
                name: "FK_PreciosProducto_Locales_IdLocal",
                table: "PreciosProducto",
                column: "IdLocal",
                principalTable: "Locales",
                principalColumn: "IdLocal",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreciosProducto_Locales_IdLocal",
                table: "PreciosProducto");

            migrationBuilder.DropIndex(
                name: "IX_PreciosProducto_IdLocal",
                table: "PreciosProducto");

            migrationBuilder.DropColumn(
                name: "IdLocal",
                table: "PreciosProducto");
        }
    }
}
