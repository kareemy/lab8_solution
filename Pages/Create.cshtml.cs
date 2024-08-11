using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab8_solution.Models;

namespace lab8_solution.Pages;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<CreateModel> _logger;
    [BindProperty]
    public Patient Patient {get; set;} = default!;

    public CreateModel(AppDbContext context, ILogger<CreateModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        // Perform server-side data validation
        // Required because client-side data validation cannot be guaranteed
        // If the model is invalid, return to the same page without modifying the db
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Server-side data validation succeeded. The Patient property is guaranteed
        // to be populated with the user input.
        // Add the Patient to the database.
        _context.Patients.Add(Patient);
        _context.SaveChanges(); // Save changes to the database.

        // Return to the Index page so we can see the results.
        return RedirectToPage("./Index");
    }
}