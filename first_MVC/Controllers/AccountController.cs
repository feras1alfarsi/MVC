using first_MVC.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace first_MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var emp = _unitOfWork.Employees.Login(username, password);

            if(emp != null)
            {
                HttpContext.Session.SetString("User", emp.Username);
                HttpContext.Session.SetInt32("Id", emp.Id);
                // In a real application, you would set up authentication here
                return RedirectToAction("Index", "Home");
            }
            

            //if (username == "admin" && password == "123")
            //{
            //    HttpContext.Session.SetString("User", username);
            //    //HttpContext.Session.SetInt32("Id", 100);
            //    // In a real application, you would set up authentication here
            //    return RedirectToAction("Index", "Home");
            //}
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }
    }
}
