using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web_Services.ClientManagement.Application.CommandServices;
using Web_Services.ClientManagement.Application.QueryServices;
using Web_Services.ClientManagement.Domain.Repositories;
using Web_Services.ClientManagement.Domain.Services;
using Web_Services.ClientManagement.Infrastructure.Repositories;
using Web_Services.IAM.Application.Internal.CommandServices;
using Web_Services.IAM.Application.Internal.OutboundServices;
using Web_Services.IAM.Application.Internal.QueryServices;
using Web_Services.IAM.Domain.Repositories;
using Web_Services.IAM.Domain.Services;
using Web_Services.IAM.Infrastructure.Hashing.BCrypt.Services;
using Web_Services.IAM.Infrastructure.Persistence.EFC.Repositories;
using Web_Services.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using Web_Services.IAM.Infrastructure.Tokens.JWT.Configuration;
using Web_Services.IAM.Infrastructure.Tokens.JWT.Services;
using Web_Services.IAM.Interfaces.ACL;
using Web_Services.IAM.Interfaces.ACL.Services;
using Web_Services.InventoryManagement.Application.Internal.CommandServices;
using Web_Services.InventoryManagement.Application.Internal.QueryServices;
using Web_Services.InventoryManagement.Domain.Repositories;
using Web_Services.InventoryManagement.Domain.Services;
using Web_Services.InventoryManagement.Infrastructure.Repositories;
using Web_Services.OrganizationManagement.Application.Internal.CommandServices;
using Web_Services.OrganizationManagement.Application.Internal.QueryServices;
using Web_Services.OrganizationManagement.Domain.Repositories;
using Web_Services.OrganizationManagement.Domain.Services;
using Web_Services.OrganizationManagement.Infrastructure.Persistence.EFC.Repositories;
using Web_Services.Shared.Domain.Repositories;
using Web_Services.Shared.Infrastructure.Interfaces.ASP.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;
using Web_Services.Shared.Infrastructure.Persistence.EFC.Repositories;


using Web_Services.Procurement.Application.Internal.CommandServices;
using Web_Services.Procurement.Application.Internal.QueryServices;
using Web_Services.Procurement.Domain.Repositories;
using Web_Services.Procurement.Domain.Services;
using Web_Services.Procurement.Infrastructure.Repositories;
using Web_Services.SystemManagement.Application.Internal.CommandServices;
using Web_Services.SystemManagement.Application.Internal.QueryServices;
using Web_Services.SystemManagement.Domain.Repositories;
using Web_Services.SystemManagement.Domain.Services;
using Web_Services.SystemManagement.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllPolicy",
        policy => policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "ACME.LearningCenterPlatform.API",
            Version = "v1",
            Description = "ACME Learning Center Platform API",
            TermsOfService = new Uri("https://acme-learning.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "ACME Studios",
                Email = "contact@acme.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });
    options.EnableAnnotations();
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

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddScoped<IPlanCommandService, PlanCommandService>();
builder.Services.AddScoped<IPlanQueryService, PlanQueryService>();

builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IOrganizationCommandService, OrganizationCommandService>();
builder.Services.AddScoped<IOrganizationQueryService, OrganizationQueryService>();

builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<IUserAccountCommandService, UserAccountCommandService>();
builder.Services.AddScoped<IUserAccountQueryService,UserAccountQueryService>();

builder.Services.AddScoped<IProductSupplierRepository, ProductSupplierRepository>();
builder.Services.AddScoped<IProductSupplierCommandService, ProductSupplierCommandService>();
builder.Services.AddScoped<IProductSupplierQueryService, ProductSupplierQueryService>();

builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();
builder.Services.AddScoped<IPurchaseCommandService, PurchaseCommandService>();
builder.Services.AddScoped<IPurchaseQueryService, PurchaseQueryService>();

builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderCommandService, PurchaseOrderCommandService>();
builder.Services.AddScoped<IPurchaseOrderQueryService, PurchaseOrderQueryService>();

builder.Services.AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();
builder.Services.AddScoped<IPurchaseOrderItemCommandService, PurchaseOrderItemCommandService>();
builder.Services.AddScoped<IPurchaseOrderItemQueryService, PurchaseOrderItemQueryService>();

builder.Services.AddScoped<ILotRepository, LotRepository>();
builder.Services.AddScoped<ILotCommandService, LotCommandService>();
builder.Services.AddScoped<ILotQueryService, LotQueryService>();

// IAM Bounded Context Injection Configuration

// TokenSettings Configuration

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply CORS Policy
app.UseCors("AllowAllPolicy");

// Add Authorization Middleware to Pipeline
app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();