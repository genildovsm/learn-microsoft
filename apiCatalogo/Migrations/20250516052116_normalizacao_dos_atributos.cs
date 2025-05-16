using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class normalizacao_dos_atributos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_CategoriasId",
                table: "tbProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_PRODUTOS_NOME",
                table: "tbProdutos",
                newName: "ix_produtos_nome");

            migrationBuilder.RenameIndex(
                name: "IX_CATEGORIAS_NOME",
                table: "tbCategorias",
                newName: "ix_categorias_nome");

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "imUrl",
                keyValue: null,
                column: "imUrl",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "imUrl",
                table: "tbProdutos",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dtCadastro",
                table: "tbProdutos",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 2,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 3,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 4,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 5,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 6,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 7,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 8,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 9,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 10,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 11,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 12,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 13,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 14,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 15,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 16,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 17,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 18,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 19,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 20,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 21,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 22,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 23,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 24,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 25,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 26,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 27,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 28,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 29,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 30,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 31,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 32,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 33,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 34,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 35,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 36,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 37,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 38,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 39,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 40,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 41,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 42,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 43,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 44,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 45,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 46,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 47,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 48,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 49,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 50,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 51,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 52,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 53,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 54,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 55,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 56,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 57,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 58,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 59,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 60,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 61,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 62,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 63,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 64,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 65,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 66,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 67,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 68,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 69,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 70,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 71,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 72,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 73,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 74,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 75,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 76,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 77,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 78,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 79,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 80,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 81,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 82,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 83,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 84,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 85,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 86,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 87,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 88,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 89,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 90,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 91,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 92,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 93,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 94,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 95,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 96,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 97,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 98,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 99,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 100,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.CreateIndex(
                name: "ix_produtos_descricao",
                table: "tbProdutos",
                column: "dsProduto",
                filter: "[nome] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_categorias_categoriasId",
                table: "tbProdutos",
                column: "categoriaId",
                principalTable: "tbCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categorias_categoriasId",
                table: "tbProdutos");

            migrationBuilder.DropIndex(
                name: "ix_produtos_descricao",
                table: "tbProdutos");

            migrationBuilder.RenameIndex(
                name: "ix_produtos_nome",
                table: "tbProdutos",
                newName: "IX_PRODUTOS_NOME");

            migrationBuilder.RenameIndex(
                name: "ix_categorias_nome",
                table: "tbCategorias",
                newName: "IX_CATEGORIAS_NOME");

            migrationBuilder.AlterColumn<string>(
                name: "imUrl",
                table: "tbProdutos",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "dtCadastro",
                table: "tbProdutos",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2025, 5, 16, 2, 21, 14, 924, DateTimeKind.Local).AddTicks(7314));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 1,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 2,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 3,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 4,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 5,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 6,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 7,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 8,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 9,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 10,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 11,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 12,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 13,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 14,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 15,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 16,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 17,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 18,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 19,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 20,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 21,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 22,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 23,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 24,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 25,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 26,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 27,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 28,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 29,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 30,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 31,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 32,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 33,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 34,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 35,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 36,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 37,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 38,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 39,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 40,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 41,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 42,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 43,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 44,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 45,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 46,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 47,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 48,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 49,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 50,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 51,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 52,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 53,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 54,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 55,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 56,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 57,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 58,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 59,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 60,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 61,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 62,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 63,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 64,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 65,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 66,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 67,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 68,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 69,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 70,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 71,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 72,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 73,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 74,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 75,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 76,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 77,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 78,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 79,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 80,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 81,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 82,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 83,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 84,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 85,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 86,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 87,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 88,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 89,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 90,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 91,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 92,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 93,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 94,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 95,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 96,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 97,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 98,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 99,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.UpdateData(
                table: "tbProdutos",
                keyColumn: "Id",
                keyValue: 100,
                column: "dtCadastro",
                value: new DateTime(2025, 5, 15, 0, 58, 11, 443, DateTimeKind.Local).AddTicks(3244));

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_CategoriasId",
                table: "tbProdutos",
                column: "categoriaId",
                principalTable: "tbCategorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
