using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.AtualizarGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.CriarGraduacao;
using JoinClassGestaodeHorario.API.Aplicacao.Graduacoes.ExcluirGraduacao;
using JoinClassGestaodeHorario.API.Dados;
using JoinClassGestaodeHorario.API.Dados.Repositorios;
using JoinClassGestaodeHorario.API.Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var cofiguracao = builder.Configuration;

// Configuração do DBContext
builder.Services.AddDbContext<ApplicationDbContext>(opcao => opcao.UseNpgsql(cofiguracao.GetValue<string>("Settings:CONNECTION_STRING"),
o => o.UseRelationalNulls()));

//Injeção de dependência dos repositórios e casos de uso
builder.Services.AddTransient<IGraduacaoRepositorio, GraduacaoRepositorio>();
builder.Services.AddTransient<ICriarGraduacaoUseCase, CriarGraduacaoUseCase>();
builder.Services.AddTransient<IAtualizarGraduacaoUseCase, AtualizarGraduacaoUseCase>();
builder.Services.AddTransient<IExcluirGraduacao, ExcluirGaduacaoUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
