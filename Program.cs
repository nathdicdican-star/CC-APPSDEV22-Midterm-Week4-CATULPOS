using Microsoft.EntityFrameworkCore;
using StudentRosterApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext with SQLite provider
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=studentroster.db"));

var app = builder.Build();

// Enable Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

// Optional: redirect root URL to Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();