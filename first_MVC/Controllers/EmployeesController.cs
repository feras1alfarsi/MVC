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

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cat = _context.Employees.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {

            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cat = _context.Employees.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
