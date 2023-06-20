using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCRUD2.Data;
using MVCCRUD2.Models;
using MVCCRUD2.Models.ViewModel;

namespace MVCCRUD2.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeesController(ApplicationContext context)
        {
            this.context = context;
        }



        [HttpGet]
        public async Task<IActionResult> Login()
        {
            // var employees = await mvcDemoDbContext.Employees.Where(x => x.RecStatus == 'A').OrderBy(x => x.Username).ToListAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Employee emp)
        {
            if (emp.Username == "Bipin" && emp.Password == "123")
            {
                // Authentication successful
                var employees = await context.Employees.Where(x => x.Username == emp.Username && x.Password == emp.Password).ToListAsync();
                return RedirectToAction("Index", "Employees", employees);
            }

            ModelState.AddModelError("", "Invalid username or password.");

            TempData["ErrorMessage"] = "Invalid username or password.";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            return View();
        }




        public IActionResult Index()
        {
            //EmpSkillsListViewModel empSkills = new EmpSkillsListViewModel();
            //empSkills.employees = context.Employees.ToList();
            //empSkills.skill = context.Skills.ToList();

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
                        }).Where(x => x.RecStatus == 'A').OrderBy(x => x.Username).ToList();

            return View(data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmpSkillSummaryModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                EmpId = addEmployeeRequest.EmpId,
                Username = addEmployeeRequest.Username,
                Password = addEmployeeRequest.Password,
                DOB = addEmployeeRequest.DOB,
                Email = addEmployeeRequest.Email,
                Address = addEmployeeRequest.Address,
                Phone = addEmployeeRequest.Phone,
                Gender = addEmployeeRequest.Gender,
                RecStatus = addEmployeeRequest.RecStatus
            };

            var skill = new Skill()
            {
                Java = addEmployeeRequest.Java,
                Python = addEmployeeRequest.Python,
                CPlusPlus = addEmployeeRequest.CPlusPlus
            };

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            await context.Skills.AddAsync(skill);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.EmpId == id);

            var skill = await context.Skills.FirstOrDefaultAsync(x => x.SkillId == id);

            if (employee != null && skill != null)
            {
                var viewModel = new UpdateEmployeeViewModel()
                {
                    EmpId = employee.EmpId,
                    Username = employee.Username,
                    Password = employee.Password,
                    DOB = employee.DOB,
                    Email = employee.Email,
                    Address = employee.Address,
                    Phone = employee.Phone,
                    Gender = employee.Gender,
                    Java = skill.Java,
                    Python = skill.Python,
                    CPlusPlus = skill.CPlusPlus,
                    RecStatus = employee.RecStatus,
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateEmployeeViewModel model)
        {
            var employee = await context.Employees.FindAsync(model.EmpId);

            var skill = await context.Skills.FindAsync(model.EmpId);

            if (employee != null && skill != null)
            {
                employee.Username = model.Username;
                employee.Password = model.Password;
                employee.DOB = model.DOB;
                employee.Email = model.Email;
                employee.Address = model.Address;
                employee.Phone = model.Phone;
                employee.Gender = model.Gender;
                skill.Python = model.Python;
                skill.Java = model.Java;
                skill.CPlusPlus = model.CPlusPlus;
                employee.RecStatus = model.RecStatus;

                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var employee = await context.Employees.FindAsync(id);

        //    var skill = await context.Skills.FindAsync(id);

        //    if (employee != null && skill != null)
        //    {
        //        employee.RecStatus = 'D';

        //        // for deleting a record use the below code. 
        //        // mvcDemoDbContext.Employees.Remove(employee);

        //        await context.SaveChangesAsync();

        //        return RedirectToAction("Index");
        //    }

        //    return RedirectToAction("Index");
        //}

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            

            if (employee != null)
            {
                employee.RecStatus = 'D';

                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}