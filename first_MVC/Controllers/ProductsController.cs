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

    }
}