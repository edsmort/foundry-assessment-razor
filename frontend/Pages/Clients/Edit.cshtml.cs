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
using Newtonsoft.Json;
using System.Text;

namespace foundry_assessment_razor.Pages.Clients
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Client Client { get; set; }

        public Client GetClient(string id)
        {
            using (var hc = new HttpClient())
            {
                var response = hc.GetAsync("http://localhost:3000/clients/" + id);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonResponse = result.Content.ReadAsStringAsync().Result;
                    System.Diagnostics.Debug.WriteLine(jsonResponse);
                    var convertedData = JsonConvert.DeserializeObject<Client>(jsonResponse);
                    return convertedData;
                }
                return null;
            }
        }

        public void EditClient(string id, string name)
        {
            using (var hc = new HttpClient())
            {
                var client = new
                {
                    name = name
                };
                string updated = JsonConvert.SerializeObject(client);
                HttpContent payload = new StringContent(updated, Encoding.UTF8, "application/json");
                var response = hc.PutAsync("http://localhost:3000/clients/" + id, payload);
                response.Wait();
            }
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = GetClient(id); 

            if (Client == null)
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

            EditClient(Client.ID, Client.Name);

            return RedirectToPage("./Index");
        }
    }
}
