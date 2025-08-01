using LaboratorioApplication.IServices;
using LaboratorioApplication.Mappings;
using LaboratorioDomain.IRepositories;
using LaboratorioApplication.Services;
using LaboratorioInfrastructure.Data;
using LaboratorioInfrastructure.MockData;
using LaboratorioInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// builder.Services.AddDbContext<BookshelfContext>(options =>
// {
//     // options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
//     options.EnableSensitiveDataLogging().LogTo(Console.WriteLine);
// });


var infraPath = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "LaboratorioInfrastructure", "Db"));
Directory.CreateDirectory(infraPath); // ensures folder exists

var dbPath = Path.Combine(infraPath, "bookshelf.db");
var connectionString = $"Data Source={dbPath}";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<BookshelfContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ILoanService, LoanService>();

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(MappingProfile).Assembly);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Seeding Data Base with Mock Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
