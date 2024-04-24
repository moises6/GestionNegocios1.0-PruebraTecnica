using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionNegocios_PruebraTecnica.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SucursalUsuario");

            migrationBuilder.DropTable(
                name: "Sucursal",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CadenaComercial",
                schema: "dbo");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "dbo",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "dbo",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                schema: "dbo",
                table: "Categoria",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "dbo",
                table: "Categoria",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "CadenaComercial",
                schema: "dbo",
                columns: table => new
                {
                    CadenaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioPropietarioId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadenaComercial", x => x.CadenaId);
                    table.ForeignKey(
                        name: "FK_CadenaComercial_AspNetUsers_UsuarioPropietarioId",
                        column: x => x.UsuarioPropietarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                schema: "dbo",
                columns: table => new
                {
                    SucursalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CadenaId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.SucursalId);
                    table.ForeignKey(
                        name: "FK_Sucursal_CadenaComercial_CadenaId",
                        column: x => x.CadenaId,
                        principalSchema: "dbo",
                        principalTable: "CadenaComercial",
                        principalColumn: "CadenaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                schema: "dbo",
                columns: table => new
                {
                    HorarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HoraApertura = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraCierre = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                    table.ForeignKey(
                        name: "FK_Horario_Sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalSchema: "dbo",
                        principalTable: "Sucursal",
                        principalColumn: "SucursalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "dbo",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "dbo",
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalSchema: "dbo",
                        principalTable: "Sucursal",
                        principalColumn: "SucursalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SucursalUsuario",
                columns: table => new
                {
                    SucursalUsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SucursalUsuario", x => x.SucursalUsuarioId);
                    table.ForeignKey(
                        name: "FK_SucursalUsuario_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SucursalUsuario_Sucursal_SucursalId",
                        column: x => x.SucursalId,
                        principalSchema: "dbo",
                        principalTable: "Sucursal",
                        principalColumn: "SucursalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CadenaComercial_UsuarioPropietarioId",
                schema: "dbo",
                table: "CadenaComercial",
                column: "UsuarioPropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_SucursalId",
                schema: "dbo",
                table: "Horario",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoriaId",
                schema: "dbo",
                table: "Item",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SucursalId",
                schema: "dbo",
                table: "Item",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_CadenaId",
                schema: "dbo",
                table: "Sucursal",
                column: "CadenaId");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalUsuario_SucursalId",
                table: "SucursalUsuario",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_SucursalUsuario_UsuarioId",
                table: "SucursalUsuario",
                column: "UsuarioId");
        }
    }
}
