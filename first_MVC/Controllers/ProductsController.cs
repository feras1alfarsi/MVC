using first_MVC.Data;
using first_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var product = _context.Products.ToList();
            return Ok(product);  // return JSON
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Product> product = _context.Products.ToList();
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var cat = _context.Products.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var cat = _context.Products.Find(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}