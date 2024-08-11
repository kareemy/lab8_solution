using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab8_solution.Models;

namespace lab8_solution.Pages;

public class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly ILogger<IndexModel> _logger;
    public List<Patient> Patients {get; set;} = default!;

    public IndexModel(AppDbContext context, ILogger<IndexModel> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void OnGet()
    {
        Patients = _context.Patients.ToList();
    }
}
