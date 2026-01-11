using System.ComponentModel.DataAnnotations;

namespace Inventory.Api.Models;
public record CreateItemRequest(
        [Required, MaxLength(64)] string Sku,
        [Required, MaxLength(200)] string Name,
        [Range(0, int.MaxValue)] int Quantity,
        string? Location
);

public record UpdateItemRequest(
    [Required, MaxLength(64)] string Sku,
    [Required, MaxLength(200)] string Name,
    [Range(0, int.MaxValue)] int Quantity,
    string? Location
);






