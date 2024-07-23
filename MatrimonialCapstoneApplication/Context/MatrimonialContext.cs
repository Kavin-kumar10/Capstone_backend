using Microsoft.EntityFrameworkCore;

namespace MatrimonialCapstoneApplication.Context
{
    public class MatrimonialContext : DbContext
    {
        public MatrimonialContext(DbContextOptions<MatrimonialContext> options): base(options) { 
        
        }
    }
}
