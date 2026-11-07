using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestorTareas.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Prioridad = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completada = table.Column<bool>(type: "bit", nullable: false),
                    CreadaEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Trabajo" },
                    { 2, "Estudio" },
                    { 3, "Personal" },
                    { 4, "Hogar" },
                    { 5, "Compras" }
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "Id", "CategoriaId", "Completada", "CreadaEn", "Descripcion", "FechaVencimiento", "Prioridad", "Titulo" },
                values: new object[,]
                {
                    { 1, 2, false, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Proyecto final de la materia", new DateTime(2026, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alta", "Entregar TP integrador de Blazor" },
                    { 2, 2, false, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Up, Down y snapshot", new DateTime(2026, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alta", "Repasar migraciones de EF Core" },
                    { 3, 2, false, new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Con commits convencionales", new DateTime(2026, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media", "Subir el proyecto a GitHub" },
                    { 4, 1, false, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resumen de actividades", new DateTime(2026, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media", "Armar el informe mensual" },
                    { 5, 1, true, new DateTime(2026, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baja", "Responder correos pendientes" },
                    { 6, 3, false, new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caminata de 30 minutos", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baja", "Hacer ejercicio" },
                    { 7, 3, false, new DateTime(2026, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media", "Llamar a la familia" },
                    { 8, 4, false, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocina y baño", new DateTime(2026, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Media", "Limpiar la casa" },
                    { 9, 4, false, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baja", "Arreglar la canilla" },
                    { 10, 5, false, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verdulería y almacén", new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alta", "Comprar insumos de la semana" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_CategoriaId",
                table: "Tareas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_Prioridad",
                table: "Tareas",
                column: "Prioridad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
