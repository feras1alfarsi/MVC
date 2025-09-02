using first_MVC.Data;
using first_MVC.Filters;
using first_MVC.Models;
using first_MVC.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Mono.TextTemplating;


namespace first_MVC.Controllers
{
    [SessionAuthorize]
    public class CategoriesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //private readonly IRepository<Category> _repository;

        //public CategoriesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //    
        //}

        //public CategoriesController(ApplicationDbContext context, IRepository<Category> repository)
        //{
        //    _context = context;
        //    _repository = repository;
        //}

        private readonly IUnitOfWork _unitOfWork;
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //[HttpGet]
        //public ActionResult <IEnumerable<Category>> GetAll()
        //{
        //    var category = _context.Categories.ToList();
        //    return Ok (category);  // return JSON
        //}


        [HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<Category> category = _context.Categories.ToList().Where(e => e.Id < 50);
            IEnumerable<Category> category = _unitOfWork.Categories.FindAll();

            if (category.Any())
            {
                TempData["Sucess"] = "تم جلب البينات بنجاح";
            }
            else
            {
                TempData["Error"] = "لا توجد بيانتا لعرضها ";
            }
                return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        //[HttpPost]
        //public IActionResult Create(Category category)
        //{


        //    try
        //    {
        //        if (category.Name == "100")
        //        {
        //            ModelState.AddModelError("CustomError", "Name can not be Equal 100");
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            _context.Categories.Add(category);
        //            _context.SaveChanges();
        //            TempData["Add"] = "تم الإنشاء بنجاح";
        //            return RedirectToAction("Index");

        //        }
        //        else
        //        {
        //            return View(category);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", "حدث خطأ أثناء إضافة البيانات"+ ex.Message);
        //        return View(category);
        //    }

        //}

        [HttpPost]
        public IActionResult Create(Category category)
        {


            try
            {
                if (category.Name == "100")
                {
                    ModelState.AddModelError("CustomError", "Name can not be Equal 100");
                }

                if (ModelState.IsValid)
                {
                    //_context.Categories.Add(category);
                    //_context.SaveChanges();
                    _unitOfWork.Categories.Add(category);
                    _unitOfWork.Save();
                    TempData["Add"] = "تم الإنشاء بنجاح";
                    return RedirectToAction("Index");

                }
                else
                {
                    return View(category);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "حدث خطأ أثناء إضافة البيانات" + ex.Message);
                return View(category);
            }

        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var cat = _context.Categories.Find(Id);
            var cat = _unitOfWork.Categories.FindById(Id); 
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            //_context.Categories.Update(category);
            //_context.SaveChanges();
            _unitOfWork.Categories.Update(category);
            _unitOfWork.Save();
            TempData["Update"] = "تم تحديث البينات بنجاح";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            //var cat = _context.Categories.Find(Id);
            var cat = _unitOfWork.Categories.FindById(Id);
            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {

            //_context.Categories.Remove(category);
            //_context.SaveChanges();
            _unitOfWork.Categories.Delete(category);
            _unitOfWork.Save();
            TempData["Remove"] = "تم الحذف البينات بنجاح";
            return RedirectToAction("Index");
        }
    }
}
