using Microsoft.EntityFrameworkCore;
using TutorialRedis.Model;

namespace TutorialRedis.Data;

public class DbContextClass: DbContext
{
    public DbContextClass(DbContextOptions<DbContextClass> options, DbSet<Product> products): base(options)
    {
        Products = products;
    }

    public DbSet<Product> Products
    {
        get;
        set;
    }
}