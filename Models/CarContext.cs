using Microsoft.EntityFrameworkCore;

namespace se_dotnet_webapi.Models {
    public class CarContext : DbContext {
        public CarContext(DbContextOptions<CarContext> options) : base(options) {
            //Constructor
        }

        public DbSet<Car> Cars { get; set; }
    }
}