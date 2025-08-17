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

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cat = _context.Categories.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cat = _context.Categories.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
