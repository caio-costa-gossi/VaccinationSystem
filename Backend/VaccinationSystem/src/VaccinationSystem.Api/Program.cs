using Microsoft.OpenApi;
using VaccinationSystem.Application;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Adicionar mediatR e dependências na camada de Application
builder.Services.AddApplication();

builder.Services.AddControllers();

// Add Swagger information
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

// Configure the HTTP request pipeline.
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
