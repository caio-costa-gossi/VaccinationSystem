using VaccinationSystem.Api.Middlewares;
using VaccinationSystem.Api.Swagger;
using VaccinationSystem.Application;
using VaccinationSystem.Infrastructure;
using VaccinationSystem.Infrastructure.Auth;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Adicionar MediatR, FluentValidation e services da camada de Application
builder.Services.AddApplication();

// Adicionar AppDbContext, Unit of Work e repositórios
builder.Services.AddInfrastructure(builder.Configuration);

// Adicionar serviços de auth e JWT
builder.Services.AddAuthServices(builder.Configuration);

// Adicionar controllers
builder.Services.AddControllers();

// Adicionar informações para o Swagger
builder.Services.AddSwaggerGenWithAuth();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
