using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YorTrainingServer.Migrations
{
    /// <inheritdoc />
    public partial class Fix_ID_TabelaAcademia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Academias_AcademiaId1",
                table: "Filiais");

            migrationBuilder.DropIndex(
                name: "IX_Filiais_AcademiaId1",
                table: "Filiais");

            migrationBuilder.DropColumn(
                name: "AcademiaId1",
                table: "Filiais");

            migrationBuilder.AlterColumn<int>(
                name: "AcademiaId",
                table: "Academias",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_AcademiaId",
                table: "Filiais",
                column: "AcademiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Academias_AcademiaId",
                table: "Filiais",
                column: "AcademiaId",
                principalTable: "Academias",
                principalColumn: "AcademiaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Academias_AcademiaId",
                table: "Filiais");

            migrationBuilder.DropIndex(
                name: "IX_Filiais_AcademiaId",
                table: "Filiais");

            migrationBuilder.AddColumn<string>(
                name: "AcademiaId1",
                table: "Filiais",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AcademiaId",
                table: "Academias",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Filiais_AcademiaId1",
                table: "Filiais",
                column: "AcademiaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Academias_AcademiaId1",
                table: "Filiais",
                column: "AcademiaId1",
                principalTable: "Academias",
                principalColumn: "AcademiaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
