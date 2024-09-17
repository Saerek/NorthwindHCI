using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthwindHCI.Models.NW;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindHCI.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly NorthwindContext _context;

        public Category? Category { get; set; }

        public DetailsModel()
        {
            _context = new NorthwindContext();  // Manual instantiation of NorthwindContext
        }

        // Fetch the category details based on the provided CategoryId
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Category = await _context.Categories
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            if (Category == null)
            {
                return NotFound();  // If category is not found
            }

            return Page();
        }
    }
}
