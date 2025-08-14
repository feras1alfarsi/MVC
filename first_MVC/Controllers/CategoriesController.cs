using Microsoft.AspNetCore.Mvc;
using first_MVC.Data;
using first_MVC.Models;


namespace first_MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult <IEnumerable<Category>> GetAll()
        {
            var category = _context.Categories.ToList();
            return Ok (category);  // return JSON
        }


        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Category> category = _context.Categories.ToList();
            return View(category);
        }
    }
}
