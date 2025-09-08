using CSharpHerryWijayaMVC.Data;
using CSharpHerryWijayaMVC.Models;
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
            var modules = dbContext.Module.Include(m => m.Details).ToList();
            var vm = new ModuleIndexViewModel { Modules = modules };
            return View(vm);
        }
        public void ModuleCategoryContains()
        {
            var moduleCategory = dbContext.ModuleCategory.ToList();
        }

        [HttpPost]
        public IActionResult AddModule([FromBody] PersonRequest request)
        {
            var module = dbContext.Module
    .Include(m => m.Details)
    .ThenInclude(d => d.ModuleStats)
    .FirstOrDefault(m => m.Id == request.NewModuleId);
            var modulecategory = new List<string>();
            var moduledictionary = new Dictionary<string, (double Value, string Type)>();
            var existingModules = dbContext.Module
    .Include(m => m.Details)
    .ThenInclude(d => d.ModuleStats)
    .Where(m => request.SelectedModules.Contains(m.Id))
    .ToList();
            if (module == null)
                return Json(new { success = false, message = "Module not found" });

            if (request.SelectedModules.Contains(module.Id))
                return Json(new { success = false, message = "Already selected" });
            if (request.SelectedModules.Count() > 0)
            {
                var selectedModules = dbContext.Module
    .Include(m => m.ModuleCategory)
    .Where(m => request.SelectedModules.Contains(m.Id))
    .ToList();

                foreach (var sm in selectedModules)
                {
                    modulecategory.Add(sm.ModuleCategory.Name);
                }
               
            }
            if (modulecategory.Contains(module.ModuleCategory.Name))
                return Json(new { success = false, message = "Same category" });
            var moduledictionarySituational=new List<string>();
            // Add module effects to Person
            foreach (var m in existingModules.Append(module))
            {
                foreach (var detail in m.Details)
                {
                    if (moduledictionary.ContainsKey(detail.ModuleStats.Name))
                    {
                        // Get the existing tuple
                        var existing = moduledictionary[detail.ModuleStats.Name];

                        // Update Value, keep Type
                        moduledictionary[detail.ModuleStats.Name] = (
                            existing.Value + detail.ValueModifier,
                            detail.ValueModifierType
                        );
                    }
                    else
                    {
                        // Add new tuple
                        if (detail.ValueModifierType == "situational") {
                            moduledictionarySituational.Add(m.Description);
                        }
                        else
                        {
                            moduledictionary[detail.ModuleStats.Name] = (
                                detail.ValueModifier,
                                detail.ValueModifierType
                            );
                        }
                            
                    }
                }
            }

             request.SelectedModules.Add(module.Id);
           
            var modulestatsAjax = new List<string>();
            foreach (var i in moduledictionary)
            {
                if (i.Value.Type == "percentage")
                {
                    modulestatsAjax.Add($"{i.Key} {i.Value.Value}%");

                }
                else
                {
                    modulestatsAjax.Add($"{i.Key} {i.Value.Value}");

                }
            }
            foreach(var i in moduledictionarySituational)
            {
                modulestatsAjax.Add(i);
            }
            request.Description = modulestatsAjax;
            return Json(new { success = true, person = request });
        }


    }
}
