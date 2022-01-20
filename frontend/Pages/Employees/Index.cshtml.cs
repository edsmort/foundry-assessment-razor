#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using frontend.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace foundry_assessment_razor.Pages.Employees
{
    public class IndexModel : PageModel
    {
        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            using (var hc = new HttpClient())
            {
                var response = hc.GetAsync("http://localhost:3000/employees");
                response.Wait();
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var jsonResponse = result.Content.ReadAsStringAsync().Result;
                    var convertedData = JsonConvert.DeserializeObject<List<Employee>>(jsonResponse);
                    Employee = convertedData;
                }
            }
        }
    }
}
