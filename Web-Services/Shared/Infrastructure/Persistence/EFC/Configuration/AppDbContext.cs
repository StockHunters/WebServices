
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Aggregates;

namespace Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /*
        builder.Entity<FavoriteSource>().HasKey(f => f.Id);
        builder.Entity<FavoriteSource>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<FavoriteSource>().Property(f => f.SourceId).IsRequired();
        builder.Entity<FavoriteSource>().Property(f => f.NewsApiKey).IsRequired();
        */
        
        builder.Entity<Client>().HasKey(f => f.Id);
        builder.Entity<Client>().Property(f => f.FirstName).IsRequired();
        builder.Entity<Client>().Property(f => f.LastName).IsRequired();
        builder.Entity<Client>().Property(f => f.Phone).IsRequired();
        builder.Entity<Client>().Property(f => f.Email).IsRequired();
        builder.Entity<Client>().Property(f => f.RegistrationDate).ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(f => f.Dni).IsRequired();
        builder.Entity<Client>().Property(f => f.Status).ValueGeneratedOnAdd();
        builder.Entity<Client>().Property(f => f.Company).IsRequired();
        
        builder.Entity<Product>().HasKey(f => f.Id);
        builder.Entity<Product>().Property(f => f.Name).IsRequired();
        builder.Entity<Product>().Property(f => f.ImageUrl).IsRequired();
        builder.Entity<Product>().Property(f => f.Stock).IsRequired();
        builder.Entity<Product>().Property(f => f.CategoryId).IsRequired();
        
        builder.Entity<ProductPrice>().HasKey(f => f.Id);
        builder.Entity<ProductPrice>().Property(f => f.ProductId).IsRequired();
        builder.Entity<ProductPrice>().Property(f => f.Price).IsRequired();
        builder.Entity<ProductPrice>().Property(f => f.Discount).IsRequired();
        builder.Entity<ProductPrice>().Property(f => f.EffectiveDate).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}