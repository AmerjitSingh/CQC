using Microsoft.EntityFrameworkCore;


public class SQLiteDBContext : DbContext
{

    public SQLiteDBContext(DbContextOptions<SQLiteDBContext> options)
            : base(options)
    {
    }

    public DbSet<HomeApplication> HomeApplication { get; set; }
}