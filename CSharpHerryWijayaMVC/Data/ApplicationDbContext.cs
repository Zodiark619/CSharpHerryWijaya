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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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


        }

    }
}
