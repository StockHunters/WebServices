using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

using Microsoft.EntityFrameworkCore;
using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.ClientManagement.Domain.Model.ValueObjects;
using Web_Services.InventoryManagement.Domain.Model.Aggregates;
using Web_Services.OrganizationManagement.Domain.Model.Aggregates;
using Web_Services.SystemManagement.Domain.Model.Aggregate;

using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Web_Services.IAM.Domain.Model.Aggregates;
using Web_Services.Procurement.Domain.Model.Aggregates;

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
        
        builder.Entity<Plan>().HasKey(f => f.Id);
        builder.Entity<Plan>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(f => f.Name).IsRequired();
        builder.Entity<Plan>().Property(f => f.Description).IsRequired();
        builder.Entity<Plan>().Property(f => f.Feature).IsRequired();
        builder.Entity<Plan>().Property(f => f.Price).IsRequired();
        
        builder.Entity<Organization>().HasKey(f => f.Id);
        builder.Entity<Organization>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Organization>().Property(f => f.Name).IsRequired();
        builder.Entity<Organization>().Property(f => f.ContactEmail).IsRequired();
        builder.Entity<Organization>().Property(f => f.PlanId).IsRequired();
        
        builder.Entity<UserAccount>().HasKey(f => f.Id);
        builder.Entity<UserAccount>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<UserAccount>().Property(f => f.OrganizationId).IsRequired();
        builder.Entity<UserAccount>().Property(f => f.UserId).IsRequired();
        builder.Entity<UserAccount>().Property(f => f.Email).IsRequired();
        builder.Entity<UserAccount>().Property(f => f.FirstName).IsRequired();
        builder.Entity<UserAccount>().Property(f => f.LastName).IsRequired();
        builder.Entity<UserAccount>().Property(f => f.ProfileImageUrl).IsRequired();
        builder.Entity<UserAccount>().Property(f => f.Role).IsRequired();
      
              builder.Entity<product_suppliers>().HasKey(f => f.id);
        builder.Entity<product_suppliers>().Property(f => f.product_id).IsRequired();
        builder.Entity<product_suppliers>().Property(f => f.supplier_id).IsRequired();
        builder.Entity<product_suppliers>().Property(f => f.supply_price).IsRequired();
        builder.Entity<product_suppliers>().Property(f => f.created_at).IsRequired();
        
        builder.Entity<purchases>().HasKey(f => f.id);
        builder.Entity<purchases>().Property(f => f.supplier_id).IsRequired();
        builder.Entity<purchases>().Property(f => f.product_id).IsRequired();
        builder.Entity<purchases>().Property(f => f.order_id).IsRequired();
        builder.Entity<purchases>().Property(f => f.quantity).IsRequired();
        builder.Entity<purchases>().Property(f => f.purchase_date).IsRequired();
        builder.Entity<purchases>().Property(f => f.status).IsRequired();
        builder.Entity<purchases>().Property(f => f.user_id).IsRequired();
        builder.Entity<purchases>().Property(f => f.location_id).IsRequired();
        builder.Entity<purchases>().Property(f => f.created_at).IsRequired();
        builder.Entity<purchases>().Property(f => f.updated_at).IsRequired();
        
        builder.Entity<purchase_orders>().HasKey(f => f.id);
        builder.Entity<purchase_orders>().Property(f => f.supplier_id).IsRequired();
        builder.Entity<purchase_orders>().Property(f => f.user_id).IsRequired();
        builder.Entity<purchase_orders>().Property(f => f.location_id).IsRequired();
        builder.Entity<purchase_orders>().Property(f => f.order_date).IsRequired();
        builder.Entity<purchase_orders>().Property(f => f.status).IsRequired();
        builder.Entity<purchase_orders>().Property(f => f.created_at).IsRequired();
        builder.Entity<purchase_orders>().Property(f => f.updated_at).IsRequired();
        
        builder.Entity<purchase_order_items>().HasKey(f => f.id);
        builder.Entity<purchase_order_items>().Property(f => f.order_id).IsRequired();
        builder.Entity<purchase_order_items>().Property(f => f.product_id).IsRequired();
        builder.Entity<purchase_order_items>().Property(f => f.quantity).IsRequired();
        builder.Entity<purchase_order_items>().Property(f => f.unit_price).IsRequired();
        builder.Entity<purchase_order_items>().Property(f => f.created_at).IsRequired();
        
        builder.Entity<lots>().HasKey(f => f.id);
        builder.Entity<lots>().Property(f => f.product_id).IsRequired();
        builder.Entity<lots>().Property(f => f.purchase_id).IsRequired();
        builder.Entity<lots>().Property(f => f.lot_number).IsRequired();
        builder.Entity<lots>().Property(f => f.purchase_date).IsRequired();
        builder.Entity<lots>().Property(f => f.expiration_date).IsRequired();
        builder.Entity<lots>().Property(f => f.created_at).IsRequired();
        
        // IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        builder.UseSnakeCaseNamingConvention();
    }
}