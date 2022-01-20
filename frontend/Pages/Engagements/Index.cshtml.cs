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
    public class IndexModel : PageModel
    {
        private readonly FoundryAssessmentContext _context;

        public IndexModel(FoundryAssessmentContext context)
        {
            _context = context;
        }

        public IList<Engagement> Engagement { get;set; }

        public async Task OnGetAsync()
        {
            Engagement = await _context.Engagement.ToListAsync();
        }
    }
}
