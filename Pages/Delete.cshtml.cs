using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab8_solution.Models;

namespace lab8_solution.Pages;

public class DeleteModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<DeleteModel> _logger;

    [BindProperty]
    public Patient Patient {get; set;} = default!;

    public DeleteModel(AppDbContext context, ILogger<DeleteModel> logger)
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

    public IActionResult OnPost(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = _context.Patients.Find(id);
        if (student != null)
        {
            _context.Patients.Remove(student);
            _context.SaveChanges();
        }

        return RedirectToPage("./Index");
    }
}