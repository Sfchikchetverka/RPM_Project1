using System.Data.Entity;
namespace RPM_Project1
{
    public class AppContext : DbContext
    {
        public AppContext() : base("DbConnection") { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }

}
