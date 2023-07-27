using ASP.NET_Core_Lernen.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ASP.NET_Core_Lernen.Data
{
    public class TestDB : DbContext
    {
        public TestDB(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
