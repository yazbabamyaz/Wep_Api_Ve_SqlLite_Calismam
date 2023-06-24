using Microsoft.EntityFrameworkCore;

namespace Apis.Models
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options)
        {
            Database.EnsureCreated();//Context için Database var mı yok mu 
        }
        public DbSet<Book> Books{ get; set; }
    }
}
