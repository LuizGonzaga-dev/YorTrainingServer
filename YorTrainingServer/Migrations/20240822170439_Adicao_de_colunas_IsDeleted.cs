using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YorTrainingServer.Migrations
{
    /// <inheritdoc />
    public partial class Adicao_de_colunas_IsDeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Funcionario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Filiais",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Academias",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Filiais");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Academias");
        }
    }
}
