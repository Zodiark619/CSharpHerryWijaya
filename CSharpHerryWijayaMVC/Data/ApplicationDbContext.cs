using CSharpHerryWijayaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpHerryWijayaMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
        }
       
    }
}
