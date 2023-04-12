using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Rest.Migrations
{
    public partial class addLocal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos");

            //migrationBuilder.DropIndex(
            //    name: "IX_MovimientoProductos_IdMovimiento",
            //    table: "MovimientoProductos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Unidad",
                table: "MovimientoProductos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto",
            //    column: "IdProducto");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos",
            //    column: "IdMovimiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Unidad",
                table: "MovimientoProductos",
                type: "decimal(18,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_PreciosProducto",
            //    table: "PreciosProducto",
            //    column: "Fecha");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_MovimientoProductos",
            //    table: "MovimientoProductos",
            //    column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoProductos_IdMovimiento",
                table: "MovimientoProductos",
                column: "IdMovimiento");
        }
    }
}
