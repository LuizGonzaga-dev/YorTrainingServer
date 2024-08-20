using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YorTrainingServer.Migrations
{
    /// <inheritdoc />
    public partial class Tabela_Funcionarios_Relações : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Filiais_FilialId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_FilialId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "FilialId",
                table: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Filiais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoFuncionario = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionario_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FilialFuncionario",
                columns: table => new
                {
                    FiliaisFilialId = table.Column<int>(type: "int", nullable: false),
                    FuncionariosFuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilialFuncionario", x => new { x.FiliaisFilialId, x.FuncionariosFuncionarioId });
                    table.ForeignKey(
                        name: "FK_FilialFuncionario_Filiais_FiliaisFilialId",
                        column: x => x.FiliaisFilialId,
                        principalTable: "Filiais",
                        principalColumn: "FilialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilialFuncionario_Funcionario_FuncionariosFuncionarioId",
                        column: x => x.FuncionariosFuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_EnderecoId",
                table: "Filiais",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FilialFuncionario_FuncionariosFuncionarioId",
                table: "FilialFuncionario",
                column: "FuncionariosFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Enderecos_EnderecoId",
                table: "Filiais",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Enderecos_EnderecoId",
                table: "Filiais");

            migrationBuilder.DropTable(
                name: "FilialFuncionario");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Filiais_EnderecoId",
                table: "Filiais");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Filiais");

            migrationBuilder.AddColumn<int>(
                name: "FilialId",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_FilialId",
                table: "Enderecos",
                column: "FilialId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Filiais_FilialId",
                table: "Enderecos",
                column: "FilialId",
                principalTable: "Filiais",
                principalColumn: "FilialId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
