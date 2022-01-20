#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using frontend.Models;

namespace foundry_assessment_razor.Pages.Engagements
{
    public class DeleteModel : PageModel
    {
        private readonly FoundryAssessmentContext _context;

        public DeleteModel(FoundryAssessmentContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Engagement Engagement { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Engagement = await _context.Engagement.FirstOrDefaultAsync(m => m.ID == id);

            if (Engagement == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Engagement = await _context.Engagement.FindAsync(id);

            if (Engagement != null)
            {
                _context.Engagement.Remove(Engagement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
