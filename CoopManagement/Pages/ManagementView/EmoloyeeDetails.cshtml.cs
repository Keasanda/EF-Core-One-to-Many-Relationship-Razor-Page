using CoopManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoopManagement.Pages.ManagementView
{
    public class EmoloyeeDetailsModel : PageModel
    {

        private readonly ManagementDbContext _managementDbContext;
        public EmoloyeeDetailsModel(ManagementDbContext managementDbContext)
        {

            _managementDbContext = managementDbContext;
        }

        public CoopManagement.Model.Management.Person EmployeeData { get; set; }
  


        public  async  Task <IActionResult>  OnGetAsync(int id)
        {
            EmployeeData = await _managementDbContext.Person.Where(x => x.PersonID == id)
              .Include(x => x.Address).FirstOrDefaultAsync();

            return Page();
        }
    }
}
