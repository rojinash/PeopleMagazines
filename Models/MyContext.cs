using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){
        }

        public DbSet<Person> People {get; set;}
        public DbSet<Magazine> Magazines {get; set;}
        public DbSet<Subscription> Subscriptions {get; set;}

    }
}