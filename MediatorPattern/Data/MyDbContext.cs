using MediatorPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorPattern.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
