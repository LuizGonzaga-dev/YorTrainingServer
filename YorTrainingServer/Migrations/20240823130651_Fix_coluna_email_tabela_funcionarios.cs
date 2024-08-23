using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YorTrainingServer.Migrations
{
    /// <inheritdoc />
    public partial class Fix_coluna_email_tabela_funcionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilialFuncionario_Funcionario_FuncionariosFuncionarioId",
                table: "FilialFuncionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Enderecos_EnderecoId",
                table: "Funcionario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario");

            migrationBuilder.RenameTable(
                name: "Funcionario",
                newName: "Funcionarios");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Funcionarios",
                newName: "Email");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionario_EnderecoId",
                table: "Funcionarios",
                newName: "IX_Funcionarios_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilialFuncionario_Funcionarios_FuncionariosFuncionarioId",
                table: "FilialFuncionario",
                column: "FuncionariosFuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilialFuncionario_Funcionarios_FuncionariosFuncionarioId",
                table: "FilialFuncionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Enderecos_EnderecoId",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Funcionario");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Funcionario",
                newName: "email");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionario",
                newName: "IX_Funcionario_EnderecoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilialFuncionario_Funcionario_FuncionariosFuncionarioId",
                table: "FilialFuncionario",
                column: "FuncionariosFuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Enderecos_EnderecoId",
                table: "Funcionario",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "EnderecoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
