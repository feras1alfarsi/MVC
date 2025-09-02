using first_MVC.Data;
using first_MVC.Dtos;
using first_MVC.Models;
using first_MVC.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace first_MVC.Controllers
{
    public class ProductsController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IRepository<Product> _repository;
        //private readonly IRepository<Category> _repository_Category;
        //private readonly IRepoProduct _repoProduct;

        //public ProductsController(ApplicationDbContext context, IRepository<Product> repository)
        //{
        //    _context = context;
        //    _repository = repository;
        //}

        //public ProductsController( IRepository<Category> repository_Category, IRepoProduct repoProduct)
        //{


        //    _repository_Category = repository_Category;
        //    _repoProduct = repoProduct;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Product>> GetAll()
        //{

        //    var product = _context.Products.ToList();
        //    return Ok(product);  // return JSON
        //}

        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<Product> product = _context.Products.Include(p => p.Category).ToList(); 
            //IEnumerable<Product> product = _repository.FindAll();
            IEnumerable<Product> product = _unitOfWork.Products.FindAllproducts();


            if (product.Any())
            {
                TempData["Sucess"] = "تم جلب البينات بنجاح";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانتا لعرضها ";
            }
            return View(product);
        }

        [HttpGet]
        //public IActionResult GetAll2()
        //{
        //    IEnumerable<ProductDto> product = 
        //        _context.Products
        //        .Include(p => p.Category)
        //        .AsNoTracking()
        //        .Select(p => new ProductDto
        //        {
        //            Id = p.Id,
        //            ProductName = p.Name,
        //            Price = p.Price,
        //            CategoryId = p.CategoryId,
        //            CategoryName = p.Name
                    
        //        })
        //        .ToList();

        //    return Ok(product);
        //}


        private void CreateCategorySelectList()
        {
            //List<CategoryDto> categories = new List<CategoryDto>
            //{
            //   // new CategoryDto{Id=0, Name="Select Category"},
            //    new CategoryDto{Id=1, Name="iPhone 15 Pro Max"},
            //    new CategoryDto{Id=2, Name="Samsung Galaxy S24 Ultra"},
            //    new CategoryDto{Id=3, Name="Google Pixel 8 Pro"},
            //    new CategoryDto{Id=4, Name="OnePlus 12"},
            //    new CategoryDto{Id=5, Name="Xiaomi 13 Ultr"},
            //    new CategoryDto{Id=6, Name="Sony Xperia 1 V"},
            //    new CategoryDto{Id=7, Name="Motorola Edge 40 Pro"},
            //    new CategoryDto{Id=8, Name="Oppo Find X6 Pro"},
            //    new CategoryDto{Id=9, Name="Huawei Mate 60 Pro"},
            //    new CategoryDto{Id=10, Name="Asus ROG Phone 7"},
            //};

            //List<Category> categories = _context.Categories.ToList();
            IEnumerable<Category> categories = _unitOfWork.Categories.FindAll();
            SelectList selectListItems = new SelectList(categories, "Id", "Name", 0);
            ViewBag.Categories = selectListItems;
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateCategorySelectList();


            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            try
            {
                if (product.Name == "100")
                {
                    ModelState.AddModelError("CustomError", "Name can not be Equal 100");
                }

                if (ModelState.IsValid)
                {
                    //_context.Products.Add(product);
                    //_context.SaveChanges();
                    _unitOfWork.Products.Add(product);
                    _unitOfWork.Save();
                    TempData["Add"] = "تم الإنشاء بنجاح";
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(product);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ أثناء إضافة البيانات" + ex.Message);
                return View(product);
            }
            
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var cat = _context.Products.Find(Id);
            var cat = _unitOfWork.Products.FindById(Id);
            CreateCategorySelectList();
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {

            //_context.Products.Update(product);
            //_context.SaveChanges();
            _unitOfWork.Products.Update(product);
            _unitOfWork.Save();
            TempData["Update"] = "تم تحديث البينات بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //var cat = _context.Products.Find(Id);
            var cat = _unitOfWork.Products.FindById(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {

            //_context.Products.Remove(product);
            //_context.SaveChanges();
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Save();
            TempData["Remove"] = "تم الحذف البينات بنجاح";
            return RedirectToAction("Index");
        }

    }
}