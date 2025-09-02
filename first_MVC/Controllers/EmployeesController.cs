using first_MVC.Data;
using first_MVC.Models;
using first_MVC.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace first_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IRepository<Employee> _repository;

        //public EmployeesController(ApplicationDbContext context, IRepository<Employee> repository)
        //{
        //    _context = context;
        //    _repository = repository;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public EmployeesController(IRepository<Employee> repository)
        //{
        //    _repository = repository;
        //}

        //[HttpGet]
        //public ActionResult<IEnumerable<Employee>> GetAll()
        //{
        //    var employee = _context.Employees.ToList();
        //    return Ok(employee);  // return JSON
        //}


        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<Employee> employee = _context.Employees.ToList();
            IEnumerable<Employee> employee = _unitOfWork.Employees.FindAll();

            if (employee.Any())
            {
                TempData["Sucess"] = "تم جلب البينات بنجاح";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانتا لعرضها ";
            }

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
            if (employee.First_Name == "100")
            {
                ModelState.AddModelError("CustomError", "Name can not be Equal 100");
            }

            if (ModelState.IsValid)
            {
                //_context.Employees.Add(employee);
                //_context.SaveChanges();
                _unitOfWork.Employees.Add(employee);
                _unitOfWork.Save();
                TempData["Add"] = "تم الإنشاء بنجاح";
                return RedirectToAction("Index");

            }
            else
            {
                return View(employee);
            }
           
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var cat = _context.Employees.Find(Id);
            var cat = _unitOfWork.Employees.FindById(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {

            //_context.Employees.Update(employee);
            //_context.SaveChanges();
            _unitOfWork.Employees.Update(employee);
            _unitOfWork.Save();
            TempData["Update"] = "تم تحديث البينات بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //var cat = _context.Employees.Find(Id);
            var cat = _unitOfWork.Employees.FindById(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {

            //_context.Employees.Remove(employee);
            //_context.SaveChanges();
            _unitOfWork.Employees.Delete(employee);
            _unitOfWork.Save();
            TempData["Remove"] = "تم الحذف البينات بنجاح";
            return RedirectToAction("Index");
        }
    }
}
