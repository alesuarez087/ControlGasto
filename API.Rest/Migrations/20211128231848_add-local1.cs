using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Rest.Migrations
{
    public partial class addlocal1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto");

            //migrationBuilder.DropIndex(
            //    name: "IX_PreciosProducto_IdProducto",
            //    table: "PreciosProducto");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos");

            //migrationBuilder.DropIndex(
            //    name: "IX_MovimientoProductos_IdMovimiento",
            //    table: "MovimientoProductos");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto",
            //    column: "IdProducto");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos",
            //    column: "IdMovimiento");

            migrationBuilder.CreateTable(
                name: "Locales",
                columns: table => new
                {
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dirección = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locales", x => x.IdLocal);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Locales");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto",
            //    column: "Fecha");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos",
            //    column: "IdProducto");

            //migrationBuilder.CreateIndex(
            //    name: "IX_PreciosProducto_IdProducto",
            //    table: "PreciosProducto",
            //    column: "IdProducto");

            //migrationBuilder.CreateIndex(
            //    name: "IX_MovimientoProductos_IdMovimiento",
            //    table: "MovimientoProductos",
            //    column: "IdMovimiento");
        }
    }
}
