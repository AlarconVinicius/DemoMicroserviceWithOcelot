using Microsoft.EntityFrameworkCore;
using ProductWebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};Encrypt=False;TrustServerCertificate=False";


builder.Services.AddDbContext<ProductDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var dbContextBase = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
if (dbContextBase.Database.GetPendingMigrations().Any())
{
	dbContextBase.Database.Migrate();
}

app.Run();
