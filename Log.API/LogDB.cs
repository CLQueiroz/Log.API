using Log.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Log.API
{
    public class LogDB : DbContext
    {
        public LogDB(DbContextOptions<LogDB> options) : base(options) { }
        public DbSet<LogModelView> Logs { get; set; }
    }
}
