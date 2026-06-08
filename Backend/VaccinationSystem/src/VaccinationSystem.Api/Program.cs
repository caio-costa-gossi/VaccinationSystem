using VaccinationSystem.Api.Middlewares;
using VaccinationSystem.Api.Swagger;
using VaccinationSystem.Application;
using VaccinationSystem.Infrastructure;
using VaccinationSystem.Infrastructure.Auth;
using VaccinationSystem.Infrastructure.Persistence;
using VaccinationSystem.Infrastructure.Persistence.Seeder;

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

// Adicionar permissionamento para CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

WebApplication app = builder.Build();

// Configurar DB
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
    DbSeeder.Seed(db);
}

// Configurar middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    // Swagger middleware
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
