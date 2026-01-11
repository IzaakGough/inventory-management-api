using Inventory.Application.Repositories;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly InventoryDbContext _db;

        public ItemRepository(InventoryDbContext db)
        {
            _db = db;
        }

        public async Task<Item?> GetByIdAsync(Guid id, CancellationToken ct)
            => await _db.Items.FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<IReadOnlyList<Item>> GetAllAsync(CancellationToken ct)
            => await _db.Items.OrderBy(x => x.Name).ToListAsync(ct);

        public async Task<Item> CreateAsync(Item item, CancellationToken ct)
        {
            _db.Items.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public async Task<bool> UpdateAsync(Item item, CancellationToken ct)
        {
            var existing = await _db.Items.FirstOrDefaultAsync(x => x.Id == item.Id, ct);

            if (existing is null) return false;

            existing.Sku = item.Sku;
            existing.Name = item.Name;
            existing.Quantity = item.Quantity;
            existing.Location = item.Location;
            existing.UpdatedAt = DateTimeOffset.UtcNow;

            await _db.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            var existing = await _db.Items.FirstOrDefaultAsync(x => x.Id == id, ct);
            if (existing is null) return false;

            _db.Items.Remove(existing);
            await _db.SaveChangesAsync(ct);
            return true;
        }

    }
}
