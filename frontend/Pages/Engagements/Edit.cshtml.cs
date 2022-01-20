#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using frontend.Models;

namespace foundry_assessment_razor.Pages.Engagements
{
    public class EditModel : PageModel
    {
        private readonly FoundryAssessmentContext _context;

        public EditModel(FoundryAssessmentContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Engagement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngagementExists(Engagement.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EngagementExists(string id)
        {
            return _context.Engagement.Any(e => e.ID == id);
        }
    }
}
