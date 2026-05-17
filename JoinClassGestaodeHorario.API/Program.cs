using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Adicionar;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Atualizar;
using JoinClassGestaodeHorario.API.Aplicacao.Alunos.Excluir;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.AtualizarGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.CriarGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacao;
using JoinClassGestaodeHorario.API.Dados;
using JoinClassGestaodeHorario.API.Dados.Repositorios;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
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

//Injeção de dependência dos repositórios e casos de uso para Graduações
builder.Services.AddTransient<IGraduacaoRepositorio, GraduacaoRepositorio>();
builder.Services.AddTransient<ICriarGraduacaoUseCase, CriarGraduacaoUseCase>();
builder.Services.AddTransient<IAtualizarGraduacaoUseCase, AtualizarGraduacaoUseCase>();
builder.Services.AddTransient<IExcluirGraduacao, ExcluirGaduacaoUseCase>();

//Injeção de dependência dos repositórios e casos de uso para Alunos
builder.Services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddTransient<IAdicionarAlunoUseCase, AdicionarAlunoUseCase>();
builder.Services.AddTransient<IAtualizarAlunoUseCase, AtualizarAlunoUseCase>();
builder.Services.AddTransient<IExcluirAlunoUseCase, ExcluirAlunoUseCase>();

var app = builder.Build();

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
