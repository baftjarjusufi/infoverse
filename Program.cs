using Microsoft.EntityFrameworkCore;

using InfoVerse.Models.Domain;
using InfoVerse.Repositories.Implementation;
using InfoVerse.Repositories.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddTransient<IThemeRepository, ThemeRepository>(); //resolving our dependencies.
builder.Services.AddTransient<IArticleRepository, ArticleRepository>(); //resolving our dependencies.

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(
            options =>
            options.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
