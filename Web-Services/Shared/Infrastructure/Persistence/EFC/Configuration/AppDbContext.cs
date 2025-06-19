
using Web_Services.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Web_Services.ClientManagement.Domain.Model.Aggregates;
using Web_Services.InventoryManagement.Domain.Model.Aggregates;
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
        
        builder.UseSnakeCaseNamingConvention();
    }
}