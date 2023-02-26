using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema_Escolar.Migrations
{
    public partial class SistemaEscolar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Codigo_Escola = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_Escola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qtde_Turmas = table.Column<int>(type: "int", nullable: false),
                    Qtde_Alunos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Codigo_Escola);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Codigo_Turma = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_ESCOLA = table.Column<int>(type: "int", nullable: false),
                    ID_MATERIA = table.Column<int>(type: "int", nullable: false),
                    EscolaCodigo_Escola = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Codigo_Turma);
                    table.ForeignKey(
                        name: "FK_Turmas_Escolas_EscolaCodigo_Escola",
                        column: x => x.EscolaCodigo_Escola,
                        principalTable: "Escolas",
                        principalColumn: "Codigo_Escola",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    ID_ALUNO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_TURMA = table.Column<int>(type: "int", nullable: false),
                    Nome_Completo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data_Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_Cadastro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Codigo_Turma = table.Column<int>(type: "int", nullable: false),
                    TurmaCodigo_Turma = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.ID_ALUNO);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmaCodigo_Turma",
                        column: x => x.TurmaCodigo_Turma,
                        principalTable: "Turmas",
                        principalColumn: "Codigo_Turma",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaCodigo_Turma",
                table: "Alunos",
                column: "TurmaCodigo_Turma");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EscolaCodigo_Escola",
                table: "Turmas",
                column: "EscolaCodigo_Escola");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Escolas");
        }
    }
}
