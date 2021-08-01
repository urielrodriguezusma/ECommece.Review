using Ecommerce.Core;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrasctrucure
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Product> Products { get; set; }
    }
}
