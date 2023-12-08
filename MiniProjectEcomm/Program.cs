using Microsoft.EntityFrameworkCore;
using MiniProjectEcomm.Data;
using MiniProjectEcomm.Repositories;
using MiniProjectEcomm.Services;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddCors(Options => Options.AddDefaultPolicy(
    builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

var ConnectionStrings = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(ConnectionStrings));

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();
app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
