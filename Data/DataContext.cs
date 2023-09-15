using Microsoft.EntityFrameworkCore;

namespace WebCRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Person> PersonsTable => Set<Person>();

    }
}
