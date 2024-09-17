using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwindHCI.Models.NW;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindHCI.Pages
{
    public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly NorthwindContext _context;

    // Initialize Categories with an empty list
    public List<Category> Categories { get; set; } = new List<Category>();

    [BindProperty]
    public Category NewCategory { get; set; } = new Category();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        _context = new NorthwindContext();  // Manual instantiation of NorthwindContext
    }

    public void OnGet()
    {
        // Retrieve only CategoryId and CategoryName for display
        Categories = _context.Categories
            .Where(c => c.CategoryName != null)
            .Select(c => new Category
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            })
            .ToList();

        _logger.LogInformation("Number of categories retrieved: {count}", Categories.Count);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Categories = _context.Categories.ToList();  // Re-fetch categories if form submission fails
            return Page();
        }

        // Add the new category to the database
        _context.Categories.Add(NewCategory);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");  // Refresh page after adding the new category
    }
}
}