using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Entities;

namespace MyAPI.Data
{
    public class MyDbContext :  DbContext   
    {
        public MyDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
        {
         
        }
        public DbSet<Apartments> Apartments { get; set;}
    }
}
