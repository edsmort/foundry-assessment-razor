#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using frontend.Models;

namespace foundry_assessment_razor.Pages.Engagements
{
    public class CreateModel : PageModel
    {
        private readonly FoundryAssessmentContext _context;

        public CreateModel(FoundryAssessmentContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Engagement Engagement { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Engagement.Add(Engagement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
