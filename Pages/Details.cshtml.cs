using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab8_solution.Models;

namespace lab8_solution.Pages;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<DetailsModel> _logger;

    // This DOES NOT need [BindProperty] because we are just
    // displaying the data, not reading it in from a form.
    public Patient Patient {get; set;} = default!;

    public DetailsModel(AppDbContext context, ILogger<DetailsModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var patient = _context.Patients.Find(id);
        if (patient == null)
        {
            return NotFound();
        }
        else
        {
            Patient = patient;
        }
        return Page();
    }
}