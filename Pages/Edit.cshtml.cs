using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab8_solution.Models;
using Microsoft.EntityFrameworkCore;

namespace lab8_solution.Pages;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<EditModel> _logger;

    // A Patient property that will be edited
    // in a form, so [BindProperty] is needed
    [BindProperty]
    public Patient Patient {get; set;} = default!;

    public EditModel(AppDbContext context, ILogger<EditModel> logger)
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

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Patient).State = EntityState.Modified;
        _context.SaveChanges();

        return RedirectToPage("./Index");
    }
}