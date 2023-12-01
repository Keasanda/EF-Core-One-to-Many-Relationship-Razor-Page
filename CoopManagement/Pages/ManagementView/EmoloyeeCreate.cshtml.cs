using CoopManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static CoopManagement.Model.Management;

namespace CoopManagement.Pages.ManagementView
{
    public class EmoloyeeCreatesModel : PageModel
    {

        private readonly ManagementDbContext _managementDbContext;
        public EmoloyeeCreatesModel(ManagementDbContext managementDbContext)
        {

            _managementDbContext = managementDbContext;
        }




        [BindProperty]
        public CoopManagement.Model.Management.Person NewEmployee { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _managementDbContext.Person.Add(NewEmployee);
            await _managementDbContext.SaveChangesAsync();

            return Redirect("Index");
        }

    }
}
