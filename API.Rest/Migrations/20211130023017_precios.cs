using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace API.Rest.Migrations
{
    public partial class precios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "PreciosProducto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdLocal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciosProducto", x => new { x.IdProducto, x.Fecha, x.IdLocal });
                    table.ForeignKey(
                        name: "FK_PreciosProducto_Productos_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreciosProducto_Locales_IdLocal",
                        column: x => x.IdLocal,
                        principalTable: "Locales",
                        principalColumn: "IdLocal",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
