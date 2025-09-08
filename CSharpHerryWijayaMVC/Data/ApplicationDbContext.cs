using CSharpHerryWijayaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpHerryWijayaMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Research> Research { get; set; }
        public DbSet<ResearchRequirement> ResearchRequirement { get; set; }


        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryItem> InventoryItem { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<ModuleDetails> ModuleDetails { get; set; }
        public DbSet<Descendant> Descendant { get; set; }
        public DbSet<ModuleCategory> ModuleCategory { get; set; }
        public DbSet<ModuleStats> ModuleStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //module,moduledetails,descendant
            var modulecategory=new List<ModuleCategory>()
            {
                new ModuleCategory
                {
                    Id=1,
                    Name="None"
                },
                new ModuleCategory
                {
                    Id=2,
                    Name="Defense"
                },
                new ModuleCategory
                {
                    Id=3,
                    Name="Battle"
                },
                new ModuleCategory
                {
                    Id=4,
                    Name="Support Tech"
                },
                new ModuleCategory
                {
                    Id=5,
                    Name="Transcendent"
                },
            };
            var modulestat=new List<ModuleStats>()
            {
                new ModuleStats
                {
                    Id = 1,
                    Name="DEF"
                },
                new ModuleStats
                {
                    Id = 2,
                    Name="Skill Effect Range"
                },
                new ModuleStats
                {
                    Id = 3,
                    Name="Toxic Skill Power"
                },
                new ModuleStats
                {
                    Id = 4,
                    Name="All Attribute Resistances"
                },
                new ModuleStats
                {
                    Id = 5,
                    Name="-"
                },
                new ModuleStats
                {
                    Id = 6,
                    Name="Max Shield"
                },
            };  
            var descendant=new List<Descendant>()
            {
                new Descendant
                {
                    Id = 1,
                    Name="Freyna"
                },
                new Descendant
                {
                    Id = 2,
                    Name="Serena"
                },
                new Descendant
                {
                    Id = 3,
                    Name="Ines"
                },
            };
            var module=new List<Module>()
            {
                new Module
                {
                    Id=1,
                    Name="Shield Conversion (DEF)",
                    Description="DEF +166.80%, Max Shield -36.50%",
                    ModuleCategoryId=2
                    ,
                    DescendantId=null,
                },
                new Module
                {
                    Id=2,
                    Name="Toxic Specialist",
                    Description="Toxic Skill Power +81.20%",
                     ModuleCategoryId=3
                    ,
                    DescendantId=null,
                },
                new Module
                {
                    Id=3,
                    Name="Polygenic Antibody",
                    Description="All Attribute Resistances +640.80",
                    ModuleCategoryId=1
                    ,
                    DescendantId=null,
                },
                new Module
                {
                    Id=4,
                    Name="An Iron Will",
                    Description="When Shield is at 0%, DEF +128.30%",
                     ModuleCategoryId=4
                    ,
                    DescendantId=null,
                },
                new Module
                {
                    Id=5,
                    Name="Contagion",
                    Description="When an enemy inflicted with Room 0 Trauma is killed, a contagion of Room 0 Trauma surrounds it.",
                    ModuleCategoryId=5,
                    DescendantId=1,
                },
                new Module
                {
                    Id=6,
                    Name="Arche Acceleration",
                    Description="Skill Speed & Range Increase Modifier +19.20%",
                   ModuleCategoryId=1,
                    DescendantId=null

                },
            };
            var moduledetail = new List<ModuleDetails>()
            {
                new ModuleDetails
                {
                    Id=1,
                    ModuleId=1,
                    ValueModifier=166.8,
                    ValueModifierType="percentage",
                    ModuleStatsId=1
                },
                new ModuleDetails
                {
                    Id=2,
                    ModuleId=1,
                    ValueModifier=-36.5,
                    ValueModifierType="percentage",
                                        ModuleStatsId=6


                },
                new ModuleDetails
                {
                    Id=3,
                    ModuleId=2,
                    ValueModifier=81.2,
                    ValueModifierType="percentage",
                                       ModuleStatsId=3


                },
                new ModuleDetails
                {
                    Id=4,
                    ModuleId=3,
                    ValueModifier=640.8,
                    ValueModifierType="raw",
                                        ModuleStatsId=4


                },
                new ModuleDetails
                {
                    Id=5,
                    ModuleId=4,
                    ValueModifier=0,
                    ValueModifierType="situational",
                                       ModuleStatsId=5


                },
                new ModuleDetails
                {
                    Id=6,
                    ModuleId=5,
                    ValueModifier=0,
                    ValueModifierType="situational",
                                        ModuleStatsId=5


                },
                new ModuleDetails
                {
                    Id=7,
                    ModuleId=6,
                    ValueModifier=19.2,
                    ValueModifierType="percentage",
                                       ModuleStatsId=2


                },
            };
            //inventory,inventoryitem
            var inventoryitem=new List<InventoryItem>()
            {
                new InventoryItem{
                Id = 1,
                InventoryId=1,
                ItemId = 1,
                Quantity = 200,
                },
                new InventoryItem{
                Id = 2,
                InventoryId=1,

                ItemId = 2,
                Quantity = 200,
                },
                new InventoryItem{
                Id = 3,
                InventoryId=1,

                ItemId = 3,
                Quantity = 200,
                },
                new InventoryItem{
                Id = 4,
                InventoryId=1,

                ItemId = 4,
                Quantity = 200,
                },
                new InventoryItem{
                Id = 5,
                InventoryId=1,

                ItemId = 5,
                Quantity = 200,
                },
                new InventoryItem{
                Id = 6,
                InventoryId=1,

                ItemId = 6,
                Quantity = 200,
                },
                new InventoryItem{
                Id = 7,
                InventoryId=1,

                ItemId = 7,
                Quantity = 200,
                },
                
            };
            var inventory=new Inventory { Id=1 };
            //item
            var items = new List<Item>()
            {
                new Item{Id=1,Name="Murky Energy Residue"}, //8
                new Item{Id=2,Name="Mixed Energy Residue"},//8
                new Item{Id=3,Name="Macromolecule Biogel"},//22
                new Item{Id=4,Name="Advanced Neural Circuit"}, //18
                new Item{Id=5,Name="Crystallization Catalyst Blueprint"}, //1
                new Item{Id=6,Name="Superalloy"}, //50
                new Item{Id=7,Name="Liquid Metal"},  //250
                new Item{Id=8,Name="High Precision Exchange Components"}, //250
            };
            //research,researchrequirement
            var researchRequirement=new List<ResearchRequirement>()
            {
      new ResearchRequirement{Id=1,ResearchId=1,ItemId=1,Quantity=8  },
                           new ResearchRequirement{Id=2,ResearchId=1,ItemId=2,Quantity=8  },
                           new ResearchRequirement{Id=3,ResearchId=1,ItemId=3,Quantity=22  },
                           new ResearchRequirement{Id=4,ResearchId=1,ItemId=4,Quantity=18  },
                           new ResearchRequirement{Id=5,ResearchId=1,ItemId=5,Quantity=1  },
                           //
                           new ResearchRequirement{Id=6,ResearchId=2,ItemId=6,Quantity=50  },
                           new ResearchRequirement{Id=7,ResearchId=3,ItemId=7,Quantity=250  },
                           new ResearchRequirement{Id=8,ResearchId=4,ItemId=8,Quantity=250  },
                          
            };
            var research = new List<Research>()
                {
                    new Research()
                    {
                        Id=1,
                        Name="Crystallization Catalyst",
                        Duration=TimeSpan.FromSeconds(100),
                        
                    },
                    new Research()
                    {
                        Id=2,
                        Name="Phase Exchanger", //preicion
                        Duration=TimeSpan.FromSeconds(10),
                       
                    },
                     new Research()
                    {
                        Id=3,
                        Name="Precision Phase Exchanger", //preicion
                        Duration=TimeSpan.FromSeconds(40),
                       
                    },
                      new Research()
                    {
                        Id=4,
                        Name="Precision Phase Exchanger", //preicion
                        Duration=TimeSpan.FromSeconds(40),
                        
                    },
                };


            modelBuilder.Entity<Item>().HasData(items);
            modelBuilder.Entity<Research>().HasData(research);
            modelBuilder.Entity<ResearchRequirement>().HasData(researchRequirement);
            modelBuilder.Entity<Inventory>().HasData(inventory);
            modelBuilder.Entity<InventoryItem>().HasData(inventoryitem);
            modelBuilder.Entity<Module>().HasData(module);
            modelBuilder.Entity<ModuleDetails>().HasData(moduledetail);
            modelBuilder.Entity<Descendant>().HasData(descendant);
            modelBuilder.Entity<ModuleStats>().HasData(modulestat);
            modelBuilder.Entity<ModuleCategory>().HasData(modulecategory);


        }

    }
}
