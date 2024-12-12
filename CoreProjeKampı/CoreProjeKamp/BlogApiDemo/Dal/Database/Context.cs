using BlogApiDemo.Dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.Dal.Database
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-VM4NR9R\\SQLEXPRESS;database=coreprojekampapi;integrated security=true;");
        }
        public DbSet<Person> persons { get; set; }
    }
}
