using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Coordenadores.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Disciplinas.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Disponibilidades.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.AtualizarGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacaoUseCase;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Horarios.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Pessoas.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Professores.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Professores.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Professores.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Turmas.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Turmas.Criar;
using JoinClassGestaodeHorario.API.Aplicacao.Turmas.Excluir;
using JoinClassGestaodeHorario.API.Dados;
using JoinClassGestaodeHorario.API.Dados.Repositorios;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using JoinClassGestaodeHorario.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var cofiguracao = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "JoinClass WebAPI - .NET CORE 8",
        Version = "v1",
        Description = "API para gestão de horários de aulas"
    });
});

// Configuração do DBContext
builder.Services.AddDbContext<ApplicationDbContext>(opcao => opcao.UseNpgsql(cofiguracao.GetValue<string>("Settings:CONNECTION_STRING"),
o => o.UseRelationalNulls()));

//Injeção de dependência dos repositórios e casos de uso para Alunos
builder.Services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddTransient<IAdicionarAlunoUseCase, AdicionarAlunoUseCase>();
builder.Services.AddTransient<IAtualizarAlunoUseCase, AtualizarAlunoUseCase>();
builder.Services.AddTransient<IExcluirAlunoUseCase, ExcluirAlunoUseCase>();

// Injeção de dependência dos repositórios e casos de uso para Coordenadores
builder.Services.AddTransient<ICoordenadorRepositorio, CoordenadorRepositorio>();
builder.Services.AddTransient<IAdicionarCoordenadoresUseCase, AdicionarCoordenadorUseCase>();
builder.Services.AddTransient<IAtualizarCoordenadoresUseCase, AtualizarCoordenadorUseCase>();
builder.Services.AddTransient<IExcluirCoordenadorUseCase, ExcluirCoordenadorUseCase>();

// Injeção de dependência dos repositórios e casos de uso para Disciplinas
builder.Services.AddTransient<IDisciplinaRepositorio, DisciplinaRepositorio>();
builder.Services.AddTransient<IAtualizarDisciplinaUseCase, AtualizarDisciplinaUseCase>();
builder.Services.AddTransient<ICriarDisciplinaUseCase, CriarDisciplinaUseCase>();
builder.Services.AddTransient<IExcluirDisciplinaUseCase, ExcluirDisciplinaUseCase>();

//Injeção de dependência dos repositórios e casos de uso para Disponibilidades
builder.Services.AddTransient<IDisponibilidadeResitorio, DisponibilidadeRepositorio>();
builder.Services.AddTransient<IAtualizarDisponibilidadeUseCase, AtualizarDisponibilidadeUseCase>();
builder.Services.AddTransient<ICriarDisponibilidadeUseCase, DisponibilidadeUseCase>();
builder.Services.AddTransient<IExcluirDisponibilidadeUseCase, ExcluirDisponibilidadeUseCase>();

//Injeção de dependência dos repositórios e casos de uso para Graduações
builder.Services.AddTransient<IGraduacaoRepositorio, GraduacaoRepositorio>();
builder.Services.AddTransient<ICriarGraduacaoUseCase, CriarGraduacaoUseCase>();
builder.Services.AddTransient<IAtualizarGraduacaoUseCase, AtualizarGraduacaoUseCase>();
builder.Services.AddTransient<IExcluirGraduacaoUseCase, ExcluirGaduacaoUseCase>();

//Injeção de dependência dos repositórios e casos de uso para Horários
builder.Services.AddTransient<IHorarioRepositorio, HorarioRepositorio>();
builder.Services.AddTransient<ICriarHorarioUseCase, CriarHorarioUseCase>();
builder.Services.AddTransient<IAtualizarHorarioUseCase, AtualizarHorarioUseCase>();
builder.Services.AddTransient<IExcluirHorarioUseCase, ExcluirHorarioUseCase>();
builder.Services.AddTransient<GerarHorariosService>();

//Injeção de dependência dos repositórios e casos de uso para Pessoas
builder.Services.AddTransient<IPessoaRepositorio, PessoaRepositorio>();
builder.Services.AddTransient<IAdicionarPessoaUseCase, AdicionarPessoaUseCase>();
builder.Services.AddTransient<IAtualizarPessoaUseCase, AtualizarPessoaUseCase>();
builder.Services.AddTransient<IExcluirPessoaUseCase, ExcluirPessoaUseCase>();

// Injeção de dependência dos repositórios e casos de uso para Professores
builder.Services.AddTransient<IProfessorRepositorio, ProfessorRepositorio>();
builder.Services.AddTransient<IAdicionarProfessoresUseCase, AdicionarProfessorUseCase>();
builder.Services.AddTransient<IAtualizarProfessoresUseCase, AtualizarProfessorUseCase>();
builder.Services.AddTransient<IExcluirProfessorUseCase, ExcluirProfessorUseCase>();

// Injeção de dependência dos repositórios e casos de uso para Turma
builder.Services.AddTransient<ITurmaRepositorio, TurmaRepositorio>();
builder.Services.AddTransient<ICriarTurmaUseCase, CriarTurmaUseCase>();
builder.Services.AddTransient<IAtualizarTurmaUseCase, AtualizarTurmaUseCase>();
builder.Services.AddTransient<IExcluirTurmaUseCase, ExcluirTurmaUseCase>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "JoinClass API v1");

    // Opcional: Define o Swagger como a página inicial (ao acessar raiz /)
    // options.RoutePrefix = string.Empty; 
});

app.UseAuthorization();

app.MapControllers();

app.Run();
