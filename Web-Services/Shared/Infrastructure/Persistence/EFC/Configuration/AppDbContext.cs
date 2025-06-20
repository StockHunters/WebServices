
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

using Microsoft.EntityFrameworkCore;
using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.ValueObjects;
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
        
        builder.Entity<Sale>().HasKey(f => f.Id);
        builder.Entity<Sale>().Property(f => f.ProductId).IsRequired();
        builder.Entity<Sale>().Property(f => f.ClientId).IsRequired();
        builder.Entity<Sale>().Property(f => f.UserId).IsRequired();
        builder.Entity<Sale>().Property(f => f.LocationId).IsRequired();
        builder.Entity<Sale>().Property(f => f.Date)
            .HasConversion(
                v => v.Date,          // SaleDate → DateTime
                v => new SaleDate(v)   // DateTime → SaleDate
            )
            .IsRequired();

        builder.Entity<Sale>().Property(f => f.Quantity)
            .HasConversion(
                v => v.Quantity,              // SaleQuantity → int
                v => new SaleQuantity(v)   // int → SaleQuantity
            )
            .IsRequired();

        builder.Entity<Sale>().Property(f => f.Status)
            .HasConversion(
                v => v.Status,             // SaleStatus → bool
                v => new SaleStatus(v)    // bool → SaleStatus
            )
            .IsRequired();
        
        builder.Entity<Location>().HasKey(f => f.Id);
        builder.Entity<Location>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Location>().Property(f => f.OrganizationId).IsRequired();
        builder.Entity<Location>().Property(f => f.Name).IsRequired();
        builder.Entity<Location>().OwnsOne(f => f.Address, n =>
        {
            n.WithOwner().HasForeignKey("Id"); // Asegura que se usa la misma PK de Location
            n.Property(f => f.Address).IsRequired();
            n.Property(f => f.City).IsRequired();
            n.Property(f => f.Country).IsRequired();
        });
        
        builder.Entity<ProductLocation>().HasKey(f => f.Id);
        builder.Entity<ProductLocation>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ProductLocation>().Property(f => f.ProductId).IsRequired();
        builder.Entity<ProductLocation>().Property(f => f.LocationId).IsRequired();
        builder.Entity<ProductLocation>().Property(f => f.Stock).IsRequired();

        builder.Entity<Category>().HasKey(f => f.Id);
        builder.Entity<Category>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(f => f.Name).IsRequired();
        builder.Entity<Category>().Property(f => f.Description).IsRequired();
        
        builder.Entity<InventoryAdjustment>().HasKey(f => f.Id);
        builder.Entity<InventoryAdjustment>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<InventoryAdjustment>().Property(f => f.ProductId).IsRequired();
        builder.Entity<InventoryAdjustment>().Property(f => f.LocationId).IsRequired();
        builder.Entity<InventoryAdjustment>().Property(f => f.Quantity).IsRequired();
        builder.Entity<InventoryAdjustment>().Property(f => f.Reason).IsRequired();
        builder.Entity<InventoryAdjustment>().Property(f => f.UserId).IsRequired();
        builder.Entity<InventoryAdjustment>().Property(f => f.AdjustmentDate).IsRequired();
        

        
        builder.UseSnakeCaseNamingConvention();
    }
}