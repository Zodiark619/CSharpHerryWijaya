using CSharpHerryWijayaMVC.Data;
using CSharpHerryWijayaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpHerryWijayaMVC.Controllers
{
    public class ResearchController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ResearchController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var model = new ResearchViewModel
            {
                InventoryItem = dbContext.InventoryItem
            .Include(ii => ii.Item)
            .ToList(),

                Research = dbContext.Research
            .Include(r => r.Requirements)
            .ThenInclude(req => req.Item)
            .ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult StartResearch(int researchId)
        {
            var research = dbContext.Research
                .Include(r => r.Requirements)
                .ThenInclude(rr => rr.Item)
                .FirstOrDefault(r => r.Id == researchId);

            if (research == null)
                return Json(new { success = false, message = "Research not found." });

            // Load player inventory (example: PlayerId = 1 for now)
            var inventoryItems = dbContext.InventoryItem
                .Where(ii => ii.Inventory.Id == 1)
                .ToList();

            // Check requirements
            foreach (var req in research.Requirements)
            {
                var invItem = inventoryItems.FirstOrDefault(i => i.ItemId == req.ItemId);
                var currentQty = invItem?.Quantity ?? 0;

                if (currentQty < req.Quantity)
                {
                    return Json(new
                    {
                        success = false,
                        message = $"Not enough {req.Item.Name}. Need {req.Quantity}, have {currentQty}."
                    });
                }
            }

            // Deduct from inventory
            foreach (var req in research.Requirements)
            {
                var invItem = inventoryItems.FirstOrDefault(i => i.ItemId == req.ItemId);
                if (invItem != null)
                {
                    invItem.Quantity -= req.Quantity;
                }
            }

            dbContext.SaveChanges();

            // You could also save research progress with EndTime = DateTime.Now + research.Duration

            return Json(new { success = true, duration = research.Duration.TotalSeconds });
        }

    }
}
