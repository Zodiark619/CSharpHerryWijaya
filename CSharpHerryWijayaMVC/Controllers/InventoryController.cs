using CSharpHerryWijayaMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpHerryWijayaMVC.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public InventoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var inventory = dbContext.Inventory
            .Include(i => i.Items)
                .ThenInclude(ii => ii.Item)
            .ToList();

            return View(inventory);
        }
        [HttpPost]
        public IActionResult IncreaseQuantity(int inventoryItemId, int amount)
        {
            var item = dbContext.InventoryItem.FirstOrDefault(ii => ii.Id == inventoryItemId);
            if (item == null)
            {
                return Json(new { success = false });
            }
            item.Quantity += amount;
            dbContext.SaveChanges();

            return Json(new { success = true, newQuantity = item.Quantity });
        }
    }
}
