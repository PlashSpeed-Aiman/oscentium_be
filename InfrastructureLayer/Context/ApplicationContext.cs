using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Context;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure your entity properties, relationships, and constraints here
        
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(i => i.Item)
                .WithOne(e => e.Inventory)
                .HasForeignKey<Item>(i => i.InventoryId)
                .OnDelete(DeleteBehavior.SetNull);
                ;
            // Add more configurations as needed
        });
        
        modelBuilder.Entity<SaleItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            
            entity.HasOne(si => si.Sale)
                .WithMany(s => s.SaleItems)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.SetNull);

            // Add more configurations as needed
            entity.HasOne(si => si.Item)
                .WithMany()
                .HasForeignKey(si => si.ItemId)
                .OnDelete(DeleteBehavior.SetNull);
            
        });
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        // Configure your connection string here
        optionsBuilder.UseNpgsql("Host=localhost;Port=5555;Database=application;Username=postgres;Password=12345",b => b.MigrationsAssembly("WebApplication2"));
    }
}