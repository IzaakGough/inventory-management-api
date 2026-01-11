using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Sku { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public string? Location { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;


    }
}
