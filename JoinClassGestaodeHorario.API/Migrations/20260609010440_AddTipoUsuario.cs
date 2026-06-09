using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JoinClassGestaodeHorario.API.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:tipo_usuario", "aluno,professor,coordenador,diretor");

            migrationBuilder.CreateTable(
                name: "disciplina",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    carga_horaria = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disciplina", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    tipo_usuario = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "semestre",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    periodo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semestre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "aluno",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aluno", x => x.id);
                    table.ForeignKey(
                        name: "FK_aluno_pessoa_id",
                        column: x => x.id,
                        principalSchema: "public",
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "coordenador",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coordenador", x => x.id);
                    table.ForeignKey(
                        name: "FK_coordenador_pessoa_id",
                        column: x => x.id,
                        principalSchema: "public",
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professor",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor", x => x.id);
                    table.ForeignKey(
                        name: "FK_professor_pessoa_id",
                        column: x => x.id,
                        principalSchema: "public",
                        principalTable: "pessoa",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "graduacao",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_graduacao = table.Column<string>(type: "text", nullable: false),
                    duracao_graduacao = table.Column<int>(type: "integer", nullable: false),
                    qnt_aula_graduacao = table.Column<int>(type: "integer", nullable: false),
                    id_coordenador = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_graduacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_graduacao_coordenador_id_coordenador",
                        column: x => x.id_coordenador,
                        principalSchema: "public",
                        principalTable: "coordenador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "disponibilidade",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dia_semana = table.Column<string>(type: "text", nullable: false),
                    horario_inicio = table.Column<string>(type: "text", nullable: false),
                    horario_fim = table.Column<string>(type: "text", nullable: false),
                    id_professor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disponibilidade", x => x.id);
                    table.ForeignKey(
                        name: "FK_disponibilidade_professor_id_professor",
                        column: x => x.id_professor,
                        principalSchema: "public",
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professor_disciplina",
                schema: "public",
                columns: table => new
                {
                    id_professor = table.Column<int>(type: "integer", nullable: false),
                    id_disciplina = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professor_disciplina", x => new { x.id_professor, x.id_disciplina });
                    table.ForeignKey(
                        name: "FK_professor_disciplina_disciplina_id_disciplina",
                        column: x => x.id_disciplina,
                        principalSchema: "public",
                        principalTable: "disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professor_disciplina_professor_id_professor",
                        column: x => x.id_professor,
                        principalSchema: "public",
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "titulacao",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipoTitulacao = table.Column<string>(type: "text", nullable: false),
                    id_professor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titulacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_titulacao_professor_id_professor",
                        column: x => x.id_professor,
                        principalSchema: "public",
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "matriz_curricular",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nomeMatrizCurricular = table.Column<string>(type: "text", nullable: false),
                    idGraduacao = table.Column<int>(type: "integer", nullable: false),
                    idSemestre = table.Column<int>(type: "integer", nullable: false),
                    idDisponibilidade = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matriz_curricular", x => x.id);
                    table.ForeignKey(
                        name: "FK_matriz_curricular_disponibilidade_idDisponibilidade",
                        column: x => x.idDisponibilidade,
                        principalSchema: "public",
                        principalTable: "disponibilidade",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matriz_curricular_graduacao_idGraduacao",
                        column: x => x.idGraduacao,
                        principalSchema: "public",
                        principalTable: "graduacao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_matriz_curricular_semestre_idSemestre",
                        column: x => x.idSemestre,
                        principalSchema: "public",
                        principalTable: "semestre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "turma",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_professor = table.Column<int>(type: "integer", nullable: false),
                    idMatrizCurricular = table.Column<int>(type: "integer", nullable: false),
                    MatrizCurricularid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turma", x => x.id);
                    table.ForeignKey(
                        name: "FK_turma_matriz_curricular_MatrizCurricularid",
                        column: x => x.MatrizCurricularid,
                        principalSchema: "public",
                        principalTable: "matriz_curricular",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_turma_matriz_curricular_idMatrizCurricular",
                        column: x => x.idMatrizCurricular,
                        principalSchema: "public",
                        principalTable: "matriz_curricular",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_turma_professor_id_professor",
                        column: x => x.id_professor,
                        principalSchema: "public",
                        principalTable: "professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "horario",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    dia_semana = table.Column<string>(type: "text", nullable: false),
                    horario_inicio = table.Column<string>(type: "text", nullable: false),
                    horario_fim = table.Column<string>(type: "text", nullable: false),
                    idTurma = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horario", x => x.id);
                    table.ForeignKey(
                        name: "FK_horario_turma_idTurma",
                        column: x => x.idTurma,
                        principalSchema: "public",
                        principalTable: "turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "turma_aluno",
                schema: "public",
                columns: table => new
                {
                    idTurma = table.Column<int>(type: "integer", nullable: false),
                    idAluno = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_turma_aluno", x => new { x.idTurma, x.idAluno });
                    table.ForeignKey(
                        name: "FK_turma_aluno_aluno_idAluno",
                        column: x => x.idAluno,
                        principalSchema: "public",
                        principalTable: "aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_turma_aluno_turma_idTurma",
                        column: x => x.idTurma,
                        principalSchema: "public",
                        principalTable: "turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_disponibilidade_id_professor",
                schema: "public",
                table: "disponibilidade",
                column: "id_professor");

            migrationBuilder.CreateIndex(
                name: "IX_graduacao_id_coordenador",
                schema: "public",
                table: "graduacao",
                column: "id_coordenador");

            migrationBuilder.CreateIndex(
                name: "IX_horario_idTurma",
                schema: "public",
                table: "horario",
                column: "idTurma");

            migrationBuilder.CreateIndex(
                name: "IX_matriz_curricular_idDisponibilidade",
                schema: "public",
                table: "matriz_curricular",
                column: "idDisponibilidade");

            migrationBuilder.CreateIndex(
                name: "IX_matriz_curricular_idGraduacao",
                schema: "public",
                table: "matriz_curricular",
                column: "idGraduacao");

            migrationBuilder.CreateIndex(
                name: "IX_matriz_curricular_idSemestre",
                schema: "public",
                table: "matriz_curricular",
                column: "idSemestre");

            migrationBuilder.CreateIndex(
                name: "IX_professor_disciplina_id_disciplina",
                schema: "public",
                table: "professor_disciplina",
                column: "id_disciplina");

            migrationBuilder.CreateIndex(
                name: "IX_titulacao_id_professor",
                schema: "public",
                table: "titulacao",
                column: "id_professor");

            migrationBuilder.CreateIndex(
                name: "IX_turma_id_professor",
                schema: "public",
                table: "turma",
                column: "id_professor");

            migrationBuilder.CreateIndex(
                name: "IX_turma_idMatrizCurricular",
                schema: "public",
                table: "turma",
                column: "idMatrizCurricular");

            migrationBuilder.CreateIndex(
                name: "IX_turma_MatrizCurricularid",
                schema: "public",
                table: "turma",
                column: "MatrizCurricularid");

            migrationBuilder.CreateIndex(
                name: "IX_turma_aluno_idAluno",
                schema: "public",
                table: "turma_aluno",
                column: "idAluno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "horario",
                schema: "public");

            migrationBuilder.DropTable(
                name: "professor_disciplina",
                schema: "public");

            migrationBuilder.DropTable(
                name: "titulacao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "turma_aluno",
                schema: "public");

            migrationBuilder.DropTable(
                name: "disciplina",
                schema: "public");

            migrationBuilder.DropTable(
                name: "aluno",
                schema: "public");

            migrationBuilder.DropTable(
                name: "turma",
                schema: "public");

            migrationBuilder.DropTable(
                name: "matriz_curricular",
                schema: "public");

            migrationBuilder.DropTable(
                name: "disponibilidade",
                schema: "public");

            migrationBuilder.DropTable(
                name: "graduacao",
                schema: "public");

            migrationBuilder.DropTable(
                name: "semestre",
                schema: "public");

            migrationBuilder.DropTable(
                name: "professor",
                schema: "public");

            migrationBuilder.DropTable(
                name: "coordenador",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "public");
        }
    }
}
