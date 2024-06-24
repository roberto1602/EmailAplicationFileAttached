using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataRepository
{
    public class ContextMain(DbContextOptions<ContextMain> options) : DbContext(options)
    {
        public DbSet<Departamento> Departamentos { get; set;}
        public DbSet<User> Users { get; set;}
    }
}
