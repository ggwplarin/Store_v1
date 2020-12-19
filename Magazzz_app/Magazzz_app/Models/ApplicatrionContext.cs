using Microsoft.EntityFrameworkCore;
namespace Magazzz_app.Models
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options)
        : base(options) { }
        
    }
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options)
        : base(options) { }

    }
}