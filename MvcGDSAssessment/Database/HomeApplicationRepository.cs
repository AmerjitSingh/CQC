public class HomeApplicationRepository : IHomeApplicationRepository
{

    private readonly SQLiteDBContext _context;
    public HomeApplicationRepository(SQLiteDBContext context)
    {
        _context = context;
    }
    public int Insert(HomeApplication entity)
    {
        _context.Set<HomeApplication>().Add(entity);
        return _context.SaveChanges();
    }
}