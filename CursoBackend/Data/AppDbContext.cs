using Microsoft.EntityFrameworkCore;

namespace CursoBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) 
        { 
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; } = default!;
    }
}
