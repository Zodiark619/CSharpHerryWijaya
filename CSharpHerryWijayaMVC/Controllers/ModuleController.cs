using CSharpHerryWijayaMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpHerryWijayaMVC.Controllers
{
    public class ModuleController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ModuleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var module = dbContext.Module.Include(x=>x.Details).ToList();
            return View(module  );
        }
        [HttpPost]
        public IActionResult Add(int id)
        {
            var module = dbContext.Module.FirstOrDefault(m => m.Id == id);
            if (module == null)
            {
                return Json(new { success = false, message = "Module not found" });
            }

            // Example: add it to another table, or user’s collection
            // dbContext.UserModules.Add(new UserModule { UserId = 1, ModuleId = id });
            // dbContext.SaveChanges();

            return Json(new { success = true, name = module.Name });
        }
    }
}
