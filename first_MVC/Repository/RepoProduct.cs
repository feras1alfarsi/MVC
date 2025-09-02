using first_MVC.Data;
using first_MVC.Models;
using first_MVC.Repository.Base;
using Microsoft.EntityFrameworkCore;
namespace first_MVC.Repository

{
    public class RepoProduct : MainRepository<Product>, IRepoProduct
    {
        private readonly ApplicationDbContext _context;
        public RepoProduct(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Product> FindAllproducts()
        {
            IEnumerable<Product> products = _context.Products.Include(e => e.Category).AsNoTracking().ToList();
            return products;
        }

        
    }
}
