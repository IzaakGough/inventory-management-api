using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Inventory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infrastructure.Persistence
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }
        public DbSet<Item> Items => Set<Item>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Sku).IsRequired().HasMaxLength(64);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(200);
                entity.HasIndex(x => x.Sku).IsUnique();
            });
        }
    }
}


