using Loja.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configura o banco de dados
builder.Services.AddDbContext<LojaDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();