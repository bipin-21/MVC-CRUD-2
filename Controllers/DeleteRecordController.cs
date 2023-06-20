using Microsoft.AspNetCore.Mvc;
using MVCCRUD2.Data;
using MVCCRUD2.Models.ViewModel;

namespace MVCCRUD2.Controllers
{
    public class DeleteRecordController : Controller
    {
        private readonly ApplicationContext context;

        public DeleteRecordController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var data = (from e in context.Employees
                        join s in context.Skills
                        on e.EmpId equals s.SkillId
                        select new EmpSkillSummaryModel
                        {
                            EmpId = e.EmpId,
                            Username = e.Username,
                            Password = e.Password,
                            Email = e.Email,
                            DOB = e.DOB,
                            Address = e.Address,
                            Phone = e.Phone,
                            Gender = e.Gender,
                            RecStatus = e.RecStatus,
                            Java = s.Java,
                            Python = s.Python,
                            CPlusPlus = s.CPlusPlus
                        }).Where(x => x.RecStatus == 'D').OrderBy(x => x.Username).ToList();

            return View(data);
        }

        public async Task<IActionResult> Recover(int id)
        {
            var deletedRecord = context.Employees.FirstOrDefault(x => x.EmpId == id);
            
            if (deletedRecord != null)
            {
                deletedRecord.RecStatus = 'A';
                context.Employees.Update(deletedRecord);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.EmpId == id);

            if (employee != null)
            {
                employee.RecStatus = 'D';

                // for deleting a record use the below code. 
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
