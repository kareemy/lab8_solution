using Microsoft.EntityFrameworkCore;

namespace lab8_solution.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Patient> Patients {get; set;}
}