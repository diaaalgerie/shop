using Microsoft.EntityFrameworkCore;

namespace shop.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<ResetPasswordRequest> resetPasswordRequests { get; set; }
        public DbSet<UserLoginRequest> userLoginRequests { get; set; }
        public DbSet<UserRegisterRequest> userRegisterRequests { get; set; }



    }
}
