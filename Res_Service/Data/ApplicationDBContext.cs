using Microsoft.EntityFrameworkCore;

namespace Res_Service.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Models.Server> Servers { get; set; }
        public DbSet<Models.Cashier> Cashiers { get; set; }
        public DbSet<Models.Chef> Chefs { get; set; }

    }
}
