using Microsoft.EntityFrameworkCore;
using upload_image.Models;

namespace upload_image.Data
{  
    public class ApplicationDbContext : DbContext
    {  
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  
            : base(options)  
        {  
        }  
  
        public DbSet<Customer> Customers { get; set; }  
    }  
}  