using Inventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Application.Repositories
{
    public interface IItemRepository
    {
        Task<Item?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<IReadOnlyList<Item>> GetAllAsync (CancellationToken ct);
        Task<Item> CreateAsync(Item item, CancellationToken ct);
        Task<bool> UpdateAsync(Item item, CancellationToken ct);
        Task<bool> DeleteAsync(Guid id, CancellationToken ct);
        
    }
}
