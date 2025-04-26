using Microsoft.EntityFrameworkCore;
using Spendsmart.Models;

namespace SpendSmart.Models
{
    public class SpendSmartDbContext:DbContext
    {
        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext>options) : base(options)
        {
        }

       
        public DbSet<Expense> Expenses { get; set; }

       
    }
}
