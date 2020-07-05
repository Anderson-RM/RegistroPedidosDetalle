using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroPedidosDetalle.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    Producto = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes", x => x.OrdenId);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Inventario = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "suplidores",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suplidores", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_suplidores_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "suplidores",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesDetalle_ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "ordenes",
                        principalColumn: "OrdenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_ClienteId",
                table: "OrdenesDetalle",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDetalle_OrdenId",
                table: "OrdenesDetalle",
                column: "OrdenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDetalle");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "suplidores");

            migrationBuilder.DropTable(
                name: "ordenes");
        }
    }
}
