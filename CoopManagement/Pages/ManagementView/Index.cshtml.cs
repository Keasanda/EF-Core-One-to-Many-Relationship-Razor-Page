using CoopManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoopManagement.Pages.ManagementView
{

    public class IndexModel : PageModel
    {
        private readonly ManagementDbContext _managementDbContext;
        public IndexModel(ManagementDbContext managementDbContext)
        {
            _managementDbContext = managementDbContext;
        }

        public string SearchTerm { get; set; }
        public List<CoopManagement.Model.Management.Person> AllPeople { get; set; }

        public async Task<IActionResult> OnGetAsync(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                AllPeople = await _managementDbContext.Person.ToListAsync();
            }
            else
            {
                AllPeople = await _managementDbContext.Person
                    .Where(p => p.Name.Contains(searchTerm) || p.Surname.Contains(searchTerm))
                    .ToListAsync();
            }

            return Page();
        }
    }
 


}
