using CoopManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoopManagement.Pages.ManagementView
{
    public class EmoloyeeUpdateModel : PageModel
    {


        private readonly ManagementDbContext _managementDbContext;
        public EmoloyeeUpdateModel(ManagementDbContext managementDbContext)
        {

            _managementDbContext = managementDbContext;
        }


        [BindProperty]
        public CoopManagement.Model.Management.Person EmployeeToUpdate { get; set; }




        public async Task<IActionResult> OnGetAsync( int id)
        {

  EmployeeToUpdate   =   await  _managementDbContext.Person.Where(x => x.PersonID == id)
                .Include(x => x.Address).FirstOrDefaultAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            _managementDbContext.Person.Update(EmployeeToUpdate);
            await _managementDbContext.SaveChangesAsync();
            return Redirect("index");

        }
    }
}
