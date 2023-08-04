using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrabalhoBancoDeDados.api.Migrations
{
    /// <inheritdoc />
    public partial class QuartaMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CidadeId", "Endereco", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 5, 1, "Rua Osni José Jacinto, São Vicente", "Miguel Campos", "966924839966924839" },
                    { 6, 1, "Rua Hercílio Luz, Centro", "Leonardo Marques", "922898441922898441" },
                    { 7, 1, "Rua Fábio Cesário Pereira, São Judas", "Mirela Rodrigues", "975617754975617754" },
                    { 8, 1, "Avenida Osvaldo Reis, Fazendinha", "Elisandra Vasconcelos", "908015364908015364" },
                    { 9, 1, "Rua Cilina Vechi Merizio, Limoeiro", "Marina Medina", "989277760989277760" },
                    { 10, 1, "Rua Nelson Augusto da Silva Schiefler, Barra do Rio", "Tereza Ramos", "917230087917230087" },
                    { 11, 2, "Rua Januário Pedro Ferreira, Barra", "Suzana Bosco", "967190866967190866" },
                    { 12, 2, "Avenida Atlântica 640, Centro", "Letícia Figueiredo", "927389821927389821" },
                    { 13, 2, "Rua Jordânia, Nações", "Fabiano Rezende", "917230087917230087" },
                    { 14, 3, "Rua das Paineiras, Progresso", "Renan Cardoso", "987380006987380006" },
                    { 15, 3, "Rua Celso Boos, Progresso", "Luiz Matos", "941919104941919104" },
                    { 16, 3, "Rua Alfredo Boehringer, Badenfurt", "Clara Corrêa", "970872835970872835" },
                    { 17, 1, "Rua Alfredo Boehringer, Badenfurt", "Clara Almeida", "970872835970872835" },
                    { 18, 1, "Rua Alfredo Boehringer, Badenfurt", "Clara Tres", "970872835970872835" },
                    { 19, 1, "Rua Alfredo Boehringer, Badenfurt", "Clara Quatro", "970872835970872835" },
                    { 20, 1, "Rua Elizabeth Montibeller dos Santos, Cordeiros", "Vinícius Carmo", "913618797913618797" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 20);

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
    }
}
