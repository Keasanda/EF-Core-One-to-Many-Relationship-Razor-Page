using CoopManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoopManagement.Pages.ManagementView
{
    public class EmoloyeeDeleteModel : PageModel
    {


        private readonly ManagementDbContext _managementDbContext;
        public EmoloyeeDeleteModel(ManagementDbContext managementDbContext)
        {

            _managementDbContext = managementDbContext;
        }

        public CoopManagement.Model.Management.Person NewEmployee { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            NewEmployee = await _managementDbContext.Person.Where(x => x.PersonID == id)
                .Include(x => x.Address).FirstOrDefaultAsync();

            return Page();

        }


        public async Task<IActionResult> OnPostAsync(int id)
        {

            var employeeToDelete = await _managementDbContext.Person.Where(x =>  x.PersonID == id)
                .Include(x => x.Address) .FirstOrDefaultAsync();

            _managementDbContext.Person.Remove(employeeToDelete);
            await _managementDbContext.SaveChangesAsync();
            return Redirect("index");
        }
    }
}
