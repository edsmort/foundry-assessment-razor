#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using frontend.Models;
using Newtonsoft.Json;

namespace foundry_assessment_razor.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        public Employee Employee { get; set; }

        public Employee GetEmployee(string id)
        {
            using (var hc = new HttpClient())
            {
                var response = hc.GetAsync("http://localhost:3000/Employees/" + id);
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonResponse = result.Content.ReadAsStringAsync().Result;
                    System.Diagnostics.Debug.WriteLine(jsonResponse);
                    var convertedData = JsonConvert.DeserializeObject<Employee>(jsonResponse);
                    return convertedData;
                }
                return null;
            }
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = GetEmployee(id); 

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
