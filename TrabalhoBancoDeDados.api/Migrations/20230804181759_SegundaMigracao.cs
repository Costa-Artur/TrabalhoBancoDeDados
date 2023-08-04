using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabalhoBancoDeDados.api.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cidades",
                columns: new[] { "Id", "Nome", "Uf" },
                values: new object[,]
                {
                    { 1, "Itajai", "SC" },
                    { 2, "Balneário Camboriu", "SC" },
                    { 3, "Penha", "SC" }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeId", "Endereco", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, 1, "Rua Tal", "Joao", "123456789123456789" },
                    { 2, 1, "Rua Tal", "Jorge", "123456789123456789" },
                    { 3, 2, "Rua Tal", "Aaa", "123456789123456789" },
                    { 4, 3, "Rua Tal", "Jorge", "123456789123456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cidades",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
