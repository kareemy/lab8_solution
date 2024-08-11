using Microsoft.EntityFrameworkCore;

namespace lab8_solution.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Patients.Any()) 
        {
            return;
        }

        context.Patients.AddRange(
            new Patient { FirstName = "Samantha", LastName = "Carter", AdmitDate = DateTime.Parse("10/01/2024"), SymptomDescription = "Severe migraines, Erratic behavior"},
            new Patient { FirstName = "Jack", LastName = "O'Neill", AdmitDate = DateTime.Parse("10/02/2024"), SymptomDescription = "Hallucinations, Memory loss"},
            new Patient { FirstName = "Daniel", LastName = "Jackson", AdmitDate = DateTime.Parse("10/04/2024"), SymptomDescription = "Seizures, Extreme mood swings"},
            new Patient { FirstName = "George", LastName = "Hammond", AdmitDate = DateTime.Parse("10/14/2024"), SymptomDescription = "Loss of motor control, Speech difficulties" },
            new Patient { FirstName = "Janet", LastName = "Fraiser", AdmitDate = DateTime.Parse("10/20/2024"), SymptomDescription = "Persistent dizziness, Glows in the dark" }
        );

        context.SaveChanges();
    }
}