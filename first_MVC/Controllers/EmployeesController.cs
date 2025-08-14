using first_MVC.Data;
using first_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController (ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
            var employee = _context.Employees.ToList();
            return Ok(employee);  // return JSON
        }


        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Employee> employee = _context.Employees.ToList();
            return View(employee);
        }
    }
}
