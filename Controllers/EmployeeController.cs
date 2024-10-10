using interview.DB;
using interview.DTOs;
using interview.DTOs.Mappers;
using interview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace interview.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly appDbContext db;

        public EmployeeController(appDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await db.Employees.AsNoTracking().ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(NewEmployeeDto newEmployee)
        {
            await db.AddAsync(newEmployee.toEmployee());

            var resault = await db.SaveChangesAsync();

            if (resault != 0)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Error: Unable to save employee. Please try again";
            return View("Add", newEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await db.Employees.FindAsync(id);

            if (student is not null)
            {
                return View(student);
            }
            ViewBag.ErrorMessage = "Error: Unable to find employee. Please try again";
            return RedirectToAction("Index");


        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var oldEmployee = await db.Employees.FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (oldEmployee is not null)
            {
                oldEmployee.Email = employee.Email;
                oldEmployee.Name = employee.Name;
                oldEmployee.IsWorking = employee.IsWorking;
                oldEmployee.HaurlyWage = employee.HaurlyWage;

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Error: Unable to find employee. Please try again";
            return RedirectToAction("Edit", employee.Id);



        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee employee)
        {
            var oldEmployee = await db.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == employee.Id);
            if (oldEmployee is not null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ErrorMessage = "Error: Unable to find employee. Please try again";
            return RedirectToAction("Edit", employee.Id);



        }
    }
}
