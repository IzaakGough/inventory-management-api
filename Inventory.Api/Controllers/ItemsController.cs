using Inventory.Api.Models;
using Inventory.Application.Repositories;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers;

[ApiController]
[Route("api/items")]

    public class ItemsController : ControllerBase
{
    private readonly IItemRepository _repo;

    public ItemsController(IItemRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var items = await _repo.GetAllAsync(ct);
        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var item = await _repo.GetByIdAsync(id, ct);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateItemRequest request, CancellationToken ct)
    {
        var created = await _repo.CreateAsync(new Item
        {
            Sku = request.Sku,
            Name = request.Name,
            Quantity = request.Quantity,
            Location = request.Location

        }, ct);

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateItemRequest request, CancellationToken ct)
    {
        var item = await _repo.GetByIdAsync(id, ct);
        if (item is null) return NotFound();

        item.Name = request.Name;
        item.Quantity = request.Quantity;
        item.Location = request.Location;

        await _repo.UpdateAsync(item, ct);
        return NoContent();
    }



    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var ok = await _repo.DeleteAsync(id, ct);
        return ok ? NoContent() : NotFound();
    }
}

