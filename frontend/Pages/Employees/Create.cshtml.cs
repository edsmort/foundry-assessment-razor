#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using frontend.Models;
using Newtonsoft.Json;
using System.Text;

namespace foundry_assessment_razor.Pages.Employees
{
    public class CreateModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }
        
        public void CreateEmployee(string name)
        {
            using (var hc = new HttpClient())
            {
                var client = new
                {
                    name = name
                };
                string updated = JsonConvert.SerializeObject(client);
                HttpContent payload = new StringContent(updated, Encoding.UTF8, "application/json");
                var response = hc.PostAsync("http://localhost:3000/employees", payload);
                response.Wait();
            }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CreateEmployee(Employee.Name);

            return RedirectToPage("./Index");
        }
    }
}
