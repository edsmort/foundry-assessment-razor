#nullable disable
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using frontend.Models;
using Newtonsoft.Json;

namespace foundry_assessment_razor.Pages.Clients
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Client Client { get; set; }

        public void CreateClient(string name)
        {
            using (var hc = new HttpClient())
            {
                var client = new
                {
                    name = name
                };
                string updated = JsonConvert.SerializeObject(client);
                HttpContent payload = new StringContent(updated, Encoding.UTF8, "application/json");
                var response = hc.PostAsync("http://localhost:3000/clients", payload);
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

            CreateClient(Client.Name);

            return RedirectToPage("./Index");
        }
    }
}
