
using Microsoft.EntityFrameworkCore;
using Web_Services.ClientManagement.Application.CommandServices;
using Web_Services.ClientManagement.Application.QueryServices;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.ClientManagement.Domain.Services;
using Web_Services.ClientManagement.Infrastructure.Repositories;
using Web_Services.InventoryManagement.Application.Internal.CommandServices;
using Web_Services.InventoryManagement.Application.Internal.QueryServices;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.InventoryManagement.Infrastructure.Repositories;
using Web_Services.Shared.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Verify Database Connection String
if (connectionString is null)
    // Stop the application if the connection string is not set.
    throw new Exception("Database connection string is not set.");

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
        });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration

/*
builder.Services.AddScoped<IFavoriteSourceRepository, FavoriteSourceRepository>();
builder.Services.AddScoped<IFavoriteSourceCommandService, FavoriteSourceCommandService>();
builder.Services.AddScoped<IFavoriteSourceQueryService, FavoriteSourceQueryService>();
*/
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientCommandService, ClientCommandService>();
builder.Services.AddScoped<IClientQueryService, ClientQueryService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

builder.Services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
builder.Services.AddScoped<IProductPriceCommandService, ProductPriceCommandService>();
builder.Services.AddScoped<IProductPriceQueryService, ProductPriceQueryService>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();
builder.Services.AddScoped<ISaleCommandService, SaleCommandService>();
builder.Services.AddScoped<ISaleQueryService, SaleQueryService>();

builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationCommandService, LocationCommandService>();
builder.Services.AddScoped<ILocationQueryService, LocationQueryService>();

builder.Services.AddScoped<IProductLocationRepository, ProductLocationRepository>();
builder.Services.AddScoped<IProductLocationCommandService, ProductLocationCommandService>();
builder.Services.AddScoped<IProductLocationQueryService, ProductLocationQueryService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();

builder.Services.AddScoped<IInventoryAdjustmentRepository, InventoryAdjustmentRepository>();
builder.Services.AddScoped<IInventoryAdjustmentCommandService, InventoryAdjustmentCommandService>();
builder.Services.AddScoped<IInventoryAdjustmentQueryService, InventoryAdjustmentQueryService>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();