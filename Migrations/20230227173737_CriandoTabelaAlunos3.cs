using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class CriandoTabelaAlunos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    ID_Escola = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Escola = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.ID_Escola);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    ID_Materia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Materia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Professor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.ID_Materia);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    ID_Turma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Escola = table.Column<int>(type: "int", nullable: false),
                    Nome_Turma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome_Escola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EscolaID_Escola = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.ID_Turma);
                    table.ForeignKey(
                        name: "FK_Turmas_Escolas_EscolaID_Escola",
                        column: x => x.EscolaID_Escola,
                        principalTable: "Escolas",
                        principalColumn: "ID_Escola",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    ID_Aluno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Turma = table.Column<int>(type: "int", nullable: false),
                    ID_Escola = table.Column<int>(type: "int", nullable: false),
                    Ano_Letivo = table.Column<int>(type: "int", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_Cadastro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurmaID_Turma = table.Column<int>(type: "int", nullable: true),
                    EscolaID_Escola = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.ID_Aluno);
                    table.ForeignKey(
                        name: "FK_Alunos_Escolas_EscolaID_Escola",
                        column: x => x.EscolaID_Escola,
                        principalTable: "Escolas",
                        principalColumn: "ID_Escola",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmaID_Turma",
                        column: x => x.TurmaID_Turma,
                        principalTable: "Turmas",
                        principalColumn: "ID_Turma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TurmaMateria",
                columns: table => new
                {
                    ID_Turma = table.Column<int>(type: "int", nullable: false),
                    ID_Materia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaMateria", x => new { x.ID_Turma, x.ID_Materia });
                    table.ForeignKey(
                        name: "FK_TurmaMateria_Materias_ID_Materia",
                        column: x => x.ID_Materia,
                        principalTable: "Materias",
                        principalColumn: "ID_Materia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurmaMateria_Turmas_ID_Turma",
                        column: x => x.ID_Turma,
                        principalTable: "Turmas",
                        principalColumn: "ID_Turma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EscolaID_Escola",
                table: "Alunos",
                column: "EscolaID_Escola");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaID_Turma",
                table: "Alunos",
                column: "TurmaID_Turma");

            migrationBuilder.CreateIndex(
                name: "IX_TurmaMateria_ID_Materia",
                table: "TurmaMateria",
                column: "ID_Materia");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EscolaID_Escola",
                table: "Turmas",
                column: "EscolaID_Escola");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "TurmaMateria");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Escolas");
        }
    }
}
