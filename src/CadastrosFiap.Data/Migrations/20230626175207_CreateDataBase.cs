using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastrosFiap.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALUNOS",
                columns: table => new
                {
                    Id_Aluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Usuario = table.Column<string>(type: "varchar(45)", nullable: false),
                    Senha = table.Column<string>(type: "char(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNOS", x => x.Id_Aluno);
                });

            migrationBuilder.CreateTable(
                name: "TB_TURMAS",
                columns: table => new
                {
                    Id_Turma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Curso = table.Column<int>(type: "int", nullable: false),
                    Nome_Turma = table.Column<string>(type: "varchar(45)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TURMAS", x => x.Id_Turma);
                });

            migrationBuilder.CreateTable(
                name: "TB_ALUNOS_TURMAS",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNOS_TURMAS", x => new { x.AlunoId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_TB_ALUNOS_TURMAS_TB_ALUNOS_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "TB_ALUNOS",
                        principalColumn: "Id_Aluno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ALUNOS_TURMAS_TB_TURMAS_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "TB_TURMAS",
                        principalColumn: "Id_Turma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNOS_Id_Aluno",
                table: "TB_ALUNOS",
                column: "Id_Aluno",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNOS_TURMAS_TurmaId",
                table: "TB_ALUNOS_TURMAS",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TURMAS_Id_Turma",
                table: "TB_TURMAS",
                column: "Id_Turma",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALUNOS_TURMAS");

            migrationBuilder.DropTable(
                name: "TB_ALUNOS");

            migrationBuilder.DropTable(
                name: "TB_TURMAS");
        }
    }
}
