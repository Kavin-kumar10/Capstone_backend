using MatrimonialCapstoneApplication.Modals;
using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Context
{
    public class MatrimonialContext : DbContext
    {
        public MatrimonialContext(DbContextOptions<MatrimonialContext> options): base(options) { 
        
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
