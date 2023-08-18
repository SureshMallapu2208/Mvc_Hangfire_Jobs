using Microsoft.EntityFrameworkCore;
using Mvc.Models;

namespace Mvc
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts) { }

        public DbSet<Request> Requests { get; set; }
    }
}
