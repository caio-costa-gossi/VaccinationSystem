using Microsoft.OpenApi;
using VaccinationSystem.Api.Middlewares;
using VaccinationSystem.Application;
using VaccinationSystem.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Adicionar MediatR, FluentValidation e services da camada de Application
builder.Services.AddApplication();

// Adicionar AppDbContext e services da camada de Infrastructure
builder.Services.AddInfrastructure(builder.Configuration);

// Adicionar controllers
builder.Services.AddControllers();

// Adicionar informações do Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API para sistema de vacinação",
        Description = "API para gerenciar carteiras de vacinação feita em ASP.NET Core 10"
    });
});

WebApplication app = builder.Build();

// Configurar middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    // Swagger middleware
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
