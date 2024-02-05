using ApplicationLayer.Dtos;
using ApplicationLayer.Service;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers;

[Route("api/[controller]/[action]")]
public class InventoryController : Controller
{
    private readonly InventoryService _inventoryService;
    private readonly ItemService _itemService;
    public InventoryController(InventoryService inventoryService, ItemService itemService)
    {
        _inventoryService = inventoryService;
        _itemService = itemService;
    }
    
   [HttpGet]
   public IActionResult GetInventory()
   {
       return Ok(_inventoryService.GetInventory());
   }
   
   
   [HttpPost]
   public IActionResult AddInventory([FromBody] Inventory inventory)
   {
       _inventoryService.AddInventory(inventory);
       return Ok();
   }
   [Route("{id:int}")]
   [HttpPost]
   public IActionResult DeleteInventory([FromRoute] int id)
   {
       _inventoryService.DeleteInventory(id);
       return Ok();
   }
   
   [HttpPatch]
   public IActionResult UpdateQuantity([FromBody] UpdateInventoryDto inventory)
   {
       _inventoryService.UpdateInventory(inventory);
       return Ok();
   }
   
   [HttpPost]
   public async Task<IActionResult> CreateItem([FromBody] ItemDto item)
   {
       var res = Item.Create(null,item.SKU,item.Name,item.Category,item.Price);
       await _itemService.AddItem(res);
       return Ok("Item created successfully.");
   }
   
   [HttpGet]
   public async Task<IActionResult> GetItems()
   {
       return Ok(await _itemService.GetItemsAsync());
   }
   
   
   
   
    
}